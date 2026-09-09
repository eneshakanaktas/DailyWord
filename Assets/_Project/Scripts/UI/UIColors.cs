using UnityEngine;

namespace DailyWord.UI
{
    /// <summary>
    /// Central color palette constants for the DailyWord UI.
    /// Premium, minimal, calm theme.
    /// </summary>
    public static class UIColors
    {
        // Background
        public static readonly Color Background = HexColor("1A1A2E");
        public static readonly Color SurfaceDark = HexColor("16213E");
        public static readonly Color Surface = HexColor("2D2D44");

        // Primary accent — warm gold
        public static readonly Color Primary = HexColor("E2B714");
        public static readonly Color PrimaryHover = HexColor("F5CC3B");

        // Text
        public static readonly Color TextPrimary = HexColor("F5F5F5");
        public static readonly Color TextSecondary = HexColor("8B8B9E");
        public static readonly Color TextOnPrimary = HexColor("1A1A2E");

        // Secondary buttons
        public static readonly Color SecondaryButton = HexColor("2D2D44");
        public static readonly Color SecondaryButtonHover = HexColor("3D3D5C");
        public static readonly Color SecondaryButtonText = HexColor("C8C8D8");

        // Utility
        private static Color HexColor(string hex)
        {
            ColorUtility.TryParseHtmlString("#" + hex, out Color color);
            return color;
        }
    }
}
