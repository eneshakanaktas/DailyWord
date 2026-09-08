using System;
using System.Collections.Generic;
using UnityEngine;

namespace DailyWord.Data
{
    [Serializable]
    public sealed class WordListDefinition
    {
        public string version;
        public string[] words;
    }

    public sealed class WordListFormatException : Exception
    {
        public WordListFormatException(string message) : base(message)
        {
        }
    }

    public sealed class WordList
    {
        private readonly string[] words;
        private readonly HashSet<string> wordSet;

        public string Version { get; }
        public IReadOnlyList<string> Words => words;
        public int Count => words.Length;

        public WordList(string version, IEnumerable<string> sourceWords)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                throw new WordListFormatException("Word list version cannot be empty.");
            }

            if (sourceWords == null)
            {
                throw new WordListFormatException("Word list words cannot be null.");
            }

            Version = version;
            wordSet = new HashSet<string>(StringComparer.Ordinal);
            List<string> validatedWords = new List<string>();

            foreach (string sourceWord in sourceWords)
            {
                WordValidationResult result = TurkishWordRules.ValidateCanonicalDataWord(sourceWord);
                if (!result.IsValid)
                {
                    throw new WordListFormatException(
                        $"Invalid word list entry '{sourceWord}' ({result.Status}).");
                }

                if (!wordSet.Add(sourceWord))
                {
                    throw new WordListFormatException($"Duplicate word list entry '{sourceWord}'.");
                }

                validatedWords.Add(sourceWord);
            }

            if (validatedWords.Count == 0)
            {
                throw new WordListFormatException("Word list cannot be empty.");
            }

            words = validatedWords.ToArray();
        }

        public bool Contains(string value)
        {
            WordValidationResult result = TurkishWordRules.ValidateInput(value);
            return result.IsValid && wordSet.Contains(result.CanonicalWord);
        }

        public string GetWord(int index)
        {
            if (index < 0 || index >= words.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return words[index];
        }
    }

    public static class WordListLoader
    {
        public static WordList Load(TextAsset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            return LoadJson(asset.text);
        }

        public static WordList LoadJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new WordListFormatException("Word list JSON cannot be empty.");
            }

            WordListDefinition definition = JsonUtility.FromJson<WordListDefinition>(json);
            if (definition == null)
            {
                throw new WordListFormatException("Word list JSON could not be parsed.");
            }

            return new WordList(definition.version, definition.words);
        }
    }
}
