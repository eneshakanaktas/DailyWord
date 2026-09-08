using System;
using System.Globalization;
using System.Text;

namespace DailyWord.Data
{
    public enum WordValidationStatus
    {
        Valid,
        Empty,
        InvalidLength,
        Whitespace,
        UnsupportedCharacter,
        NonCanonical
    }

    public readonly struct WordValidationResult
    {
        public WordValidationStatus Status { get; }
        public string CanonicalWord { get; }
        public bool IsValid => Status == WordValidationStatus.Valid;

        public WordValidationResult(WordValidationStatus status, string canonicalWord)
        {
            Status = status;
            CanonicalWord = canonicalWord;
        }
    }

    public static class TurkishWordRules
    {
        private static readonly CultureInfo TurkishCulture = CultureInfo.GetCultureInfo("tr-TR");
        private const string TurkishAlphabet = "abcçdefgğhıijklmnoöprsştuüvyz";

        public static string Normalize(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.Normalize(NormalizationForm.FormC).ToLower(TurkishCulture);
        }

        public static WordValidationResult ValidateInput(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new WordValidationResult(WordValidationStatus.Empty, string.Empty);
            }

            if (ContainsWhitespace(value))
            {
                return new WordValidationResult(WordValidationStatus.Whitespace, string.Empty);
            }

            string canonicalWord = Normalize(value);
            if (canonicalWord.Length != 5)
            {
                return new WordValidationResult(WordValidationStatus.InvalidLength, canonicalWord);
            }

            foreach (char letter in canonicalWord)
            {
                if (TurkishAlphabet.IndexOf(letter) < 0)
                {
                    return new WordValidationResult(WordValidationStatus.UnsupportedCharacter, canonicalWord);
                }
            }

            return new WordValidationResult(WordValidationStatus.Valid, canonicalWord);
        }

        public static WordValidationResult ValidateCanonicalDataWord(string value)
        {
            WordValidationResult result = ValidateInput(value);
            if (!result.IsValid)
            {
                return result;
            }

            if (!string.Equals(value, result.CanonicalWord, StringComparison.Ordinal))
            {
                return new WordValidationResult(WordValidationStatus.NonCanonical, result.CanonicalWord);
            }

            return result;
        }

        private static bool ContainsWhitespace(string value)
        {
            foreach (char character in value)
            {
                if (char.IsWhiteSpace(character))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
