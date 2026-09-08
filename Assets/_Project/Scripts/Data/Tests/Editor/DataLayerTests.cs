using System;
using NUnit.Framework;

namespace DailyWord.Data.Tests
{
    public sealed class TurkishWordRulesTests
    {
        [Test]
        public void Normalize_PreservesTurkishIAndDotlessI()
        {
            Assert.That(TurkishWordRules.Normalize("I"), Is.EqualTo("ı"));
            Assert.That(TurkishWordRules.Normalize("İ"), Is.EqualTo("i"));
            Assert.That(TurkishWordRules.Normalize("i"), Is.EqualTo("i"));
            Assert.That(TurkishWordRules.Normalize("ı"), Is.EqualTo("ı"));
        }

        [Test]
        public void Normalize_PreservesTurkishDiacritics()
        {
            Assert.That(TurkishWordRules.Normalize("ŞĞÇÖÜ"), Is.EqualTo("şğçöü"));
        }

        [Test]
        public void ValidateInput_AcceptsCasingAndReturnsCanonicalWord()
        {
            WordValidationResult result = TurkishWordRules.ValidateInput("KİTAP");

            Assert.That(result.IsValid, Is.True);
            Assert.That(result.CanonicalWord, Is.EqualTo("kitap"));
        }

        [TestCase("")]
        [TestCase("kalem ")]
        [TestCase("kale")]
        [TestCase("kalemler")]
        [TestCase("qwert")]
        public void ValidateInput_RejectsMalformedWords(string value)
        {
            Assert.That(TurkishWordRules.ValidateInput(value).IsValid, Is.False);
        }

        [Test]
        public void ValidateInput_RejectsWhitespaceExplicitly()
        {
            Assert.That(
                TurkishWordRules.ValidateInput("kit ap").Status,
                Is.EqualTo(WordValidationStatus.Whitespace));
        }
    }

    public sealed class WordListTests
    {
        [Test]
        public void LoadJson_PreservesOrderAndSupportsCanonicalLookup()
        {
            WordList wordList = WordListLoader.LoadJson(
                "{\"version\":\"test-1\",\"words\":[\"kalem\",\"şehir\"]}");

            Assert.That(wordList.Version, Is.EqualTo("test-1"));
            Assert.That(wordList.GetWord(0), Is.EqualTo("kalem"));
            Assert.That(wordList.Contains("ŞEHİR"), Is.True);
        }

        [Test]
        public void Constructor_RejectsDuplicateWords()
        {
            Assert.Throws<WordListFormatException>(
                () => new WordList("test-1", new[] { "kalem", "kalem" }));
        }

        [Test]
        public void Constructor_RejectsNonCanonicalSourceWords()
        {
            Assert.Throws<WordListFormatException>(
                () => new WordList("test-1", new[] { "Kalem" }));
        }
    }

    public sealed class DailyPuzzleSelectorTests
    {
        private static WordList CreateWordList(string version)
        {
            return new WordList(version, new[] { "kalem", "kitap", "şehir", "güneş" });
        }

        [Test]
        public void Select_SameDateAndDatasetProducesSamePuzzle()
        {
            DailyPuzzleSelector selector = new DailyPuzzleSelector(CreateWordList("test-1"));
            DateTime date = new DateTime(2026, 9, 8);

            DailyPuzzleSelection first = selector.Select(date);
            DailyPuzzleSelection second = selector.Select(date.AddHours(12));

            Assert.That(second.PuzzleId, Is.EqualTo(first.PuzzleId));
            Assert.That(second.Word, Is.EqualTo(first.Word));
        }

        [Test]
        public void Select_UsesDateAndDatasetVersionInPuzzleId()
        {
            DateTime date = new DateTime(2026, 9, 8);
            DailyPuzzleSelection first = new DailyPuzzleSelector(CreateWordList("test-1")).Select(date);
            DailyPuzzleSelection nextDay = new DailyPuzzleSelector(CreateWordList("test-1")).Select(date.AddDays(1));
            DailyPuzzleSelection nextVersion = new DailyPuzzleSelector(CreateWordList("test-2")).Select(date);

            Assert.That(nextDay.PuzzleId, Is.Not.EqualTo(first.PuzzleId));
            Assert.That(nextVersion.PuzzleId, Is.Not.EqualTo(first.PuzzleId));
        }
    }
}
