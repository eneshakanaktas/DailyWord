using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace DailyWord.Data
{
    public sealed class DailyPuzzleSelection
    {
        public DateTime Date { get; }
        public string WordListVersion { get; }
        public int WordIndex { get; }
        public string Word { get; }
        public string PuzzleId { get; }

        public DailyPuzzleSelection(
            DateTime date,
            string wordListVersion,
            int wordIndex,
            string word,
            string puzzleId)
        {
            Date = date;
            WordListVersion = wordListVersion;
            WordIndex = wordIndex;
            Word = word;
            PuzzleId = puzzleId;
        }
    }

    public sealed class DailyPuzzleSelector
    {
        private readonly WordList wordList;

        public DailyPuzzleSelector(WordList wordList)
        {
            this.wordList = wordList ?? throw new ArgumentNullException(nameof(wordList));
        }

        public DailyPuzzleSelection Select(DateTime date)
        {
            DateTime calendarDate = date.Date;
            int wordIndex = CalculateIndex(calendarDate, wordList.Version, wordList.Count);
            string word = wordList.GetWord(wordIndex);
            string dateKey = calendarDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string puzzleId = $"{wordList.Version}:{dateKey}:{wordIndex}";

            return new DailyPuzzleSelection(
                calendarDate,
                wordList.Version,
                wordIndex,
                word,
                puzzleId);
        }

        private static int CalculateIndex(DateTime date, string version, int wordCount)
        {
            string selectionKey = $"{version}|{date:yyyy-MM-dd}";
            byte[] keyBytes = Encoding.UTF8.GetBytes(selectionKey);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] digest = sha256.ComputeHash(keyBytes);
                uint hash = ((uint)digest[0] << 24)
                    | ((uint)digest[1] << 16)
                    | ((uint)digest[2] << 8)
                    | digest[3];
                return (int)(hash % (uint)wordCount);
            }
        }
    }
}
