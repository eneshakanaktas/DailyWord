using System;

namespace DailyWord.Game
{
    public sealed class GameInputState
    {
        private readonly string[,] letters;

        public int RowCount { get; }
        public int ColumnCount { get; }
        public int ActiveRow { get; private set; }
        public int ActiveColumn { get; private set; }
        public bool IsComplete => ActiveRow >= RowCount;
        public bool IsCurrentRowFull => !IsComplete && ActiveColumn == ColumnCount;

        public GameInputState(int rowCount = 6, int columnCount = 5)
        {
            if (rowCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            }

            if (columnCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }

            RowCount = rowCount;
            ColumnCount = columnCount;
            letters = new string[rowCount, columnCount];
        }

        public bool TryAddLetter(string letter, out int row, out int column)
        {
            row = ActiveRow;
            column = ActiveColumn;

            if (IsComplete || IsCurrentRowFull || string.IsNullOrEmpty(letter))
            {
                return false;
            }

            letters[row, column] = letter;
            ActiveColumn++;
            return true;
        }

        public bool TryBackspace(out int row, out int column)
        {
            row = ActiveRow;
            column = ActiveColumn - 1;

            if (IsComplete || ActiveColumn <= 0)
            {
                return false;
            }

            ActiveColumn--;
            column = ActiveColumn;
            letters[row, column] = string.Empty;
            return true;
        }

        public bool TryGetCurrentGuess(out string guess)
        {
            guess = string.Empty;

            if (!IsCurrentRowFull)
            {
                return false;
            }

            string[] rowLetters = new string[ColumnCount];
            for (int column = 0; column < ColumnCount; column++)
            {
                rowLetters[column] = letters[ActiveRow, column] ?? string.Empty;
            }

            guess = string.Concat(rowLetters);
            return true;
        }

        public bool TryAdvanceRow()
        {
            if (!IsCurrentRowFull)
            {
                return false;
            }

            ActiveRow++;
            ActiveColumn = 0;
            return !IsComplete;
        }

        public string GetLetter(int row, int column)
        {
            if (row < 0 || row >= RowCount)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (column < 0 || column >= ColumnCount)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            return letters[row, column] ?? string.Empty;
        }
    }
}
