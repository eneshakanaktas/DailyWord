using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DailyWord.Game
{
    public sealed class GameBoardView : MonoBehaviour
    {
        private const int DefaultRowCount = 6;
        private const int DefaultColumnCount = 5;

        private TMP_Text[] letterTexts;

        public int RowCount => DefaultRowCount;
        public int ColumnCount => DefaultColumnCount;

        private void Awake()
        {
            CacheTiles();
        }

        public void SetLetter(int row, int column, string letter)
        {
            TMP_Text text = GetText(row, column);
            if (text != null)
            {
                text.text = letter ?? string.Empty;
            }
        }

        public void ClearLetter(int row, int column)
        {
            SetLetter(row, column, string.Empty);
        }

        public void ClearAllLetters()
        {
            EnsureTilesCached();

            foreach (TMP_Text text in letterTexts)
            {
                if (text != null)
                {
                    text.text = string.Empty;
                }
            }
        }

        private TMP_Text GetText(int row, int column)
        {
            EnsureTilesCached();

            if (row < 0 || row >= RowCount || column < 0 || column >= ColumnCount)
            {
                return null;
            }

            return letterTexts[(row * ColumnCount) + column];
        }

        private void EnsureTilesCached()
        {
            if (letterTexts == null || letterTexts.Length == 0)
            {
                CacheTiles();
            }
        }

        private void CacheTiles()
        {
            List<TileEntry> tiles = new List<TileEntry>();

            foreach (Transform child in transform)
            {
                if (!TryParseTileNumber(child.name, out int tileNumber))
                {
                    continue;
                }

                TMP_Text letterText = FindLetterText(child);
                if (letterText != null)
                {
                    tiles.Add(new TileEntry(tileNumber, letterText));
                }
            }

            tiles.Sort((left, right) => left.Number.CompareTo(right.Number));
            letterTexts = new TMP_Text[DefaultRowCount * DefaultColumnCount];

            int count = Mathf.Min(letterTexts.Length, tiles.Count);
            for (int index = 0; index < count; index++)
            {
                letterTexts[index] = tiles[index].Text;
            }
        }

        private static bool TryParseTileNumber(string objectName, out int tileNumber)
        {
            tileNumber = 0;

            if (string.IsNullOrEmpty(objectName) || !objectName.StartsWith("Tile_", StringComparison.Ordinal))
            {
                return false;
            }

            return int.TryParse(objectName.Substring("Tile_".Length), out tileNumber);
        }

        private static TMP_Text FindLetterText(Transform tile)
        {
            Transform directLetter = tile.Find("Letter");
            if (directLetter != null && directLetter.TryGetComponent(out TMP_Text directText))
            {
                return directText;
            }

            return tile.GetComponentInChildren<TMP_Text>(true);
        }

        private readonly struct TileEntry
        {
            public int Number { get; }
            public TMP_Text Text { get; }

            public TileEntry(int number, TMP_Text text)
            {
                Number = number;
                Text = text;
            }
        }
    }
}
