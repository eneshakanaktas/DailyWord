using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DailyWord.Game
{
    public sealed class TurkishKeyboardController : MonoBehaviour
    {
        private static readonly string[][] KeyboardRows =
        {
            new[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "Ğ", "Ü" },
            new[] { "A", "S", "D", "F", "G", "H", "J", "K", "L", "Ş", "İ" },
            new[] { "Z", "X", "C", "V", "B", "N", "M", "Ö", "Ç" }
        };

        public static readonly string[] LetterOrder =
        {
            "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "Ğ", "Ü",
            "A", "S", "D", "F", "G", "H", "J", "K", "L", "Ş", "İ",
            "Z", "X", "C", "V", "B", "N", "M", "Ö", "Ç"
        };

        private static readonly HashSet<string> ValidLetters = new HashSet<string>(LetterOrder, StringComparer.Ordinal);
        private readonly List<ButtonBinding> bindings = new List<ButtonBinding>();

        public event Action<string> LetterPressed;
        public event Action BackspacePressed;
        public event Action EnterPressed;

        private void Start()
        {
            EnsureExpectedKeys();
            BindButtons();
        }

        private void OnDestroy()
        {
            UnbindButtons();
        }

        public void BindButtons()
        {
            UnbindButtons();

            foreach (Button button in GetComponentsInChildren<Button>(true))
            {
                KeyKind keyKind = ResolveKey(button, out string value);
                if (keyKind == KeyKind.Unknown)
                {
                    continue;
                }

                UnityAction action = CreateAction(keyKind, value);
                button.onClick.AddListener(action);
                bindings.Add(new ButtonBinding(button, action));
            }
        }

        private UnityAction CreateAction(KeyKind keyKind, string value)
        {
            switch (keyKind)
            {
                case KeyKind.Letter:
                    return () => LetterPressed?.Invoke(value);
                case KeyKind.Backspace:
                    return () => BackspacePressed?.Invoke();
                case KeyKind.Enter:
                    return () => EnterPressed?.Invoke();
                default:
                    return null;
            }
        }

        private void UnbindButtons()
        {
            foreach (ButtonBinding binding in bindings)
            {
                if (binding.Button != null && binding.Action != null)
                {
                    binding.Button.onClick.RemoveListener(binding.Action);
                }
            }

            bindings.Clear();
        }

        private static KeyKind ResolveKey(Button button, out string value)
        {
            value = GetButtonText(button);

            if (ValidLetters.Contains(value))
            {
                return KeyKind.Letter;
            }

            string normalizedName = button.name.ToUpperInvariant();
            string normalizedValue = value.ToUpperInvariant();

            if (normalizedName.Contains("BACKSPACE") || normalizedValue == "⌫" || normalizedValue == "DEL")
            {
                value = string.Empty;
                return KeyKind.Backspace;
            }

            if (normalizedName.Contains("ENTER") || normalizedValue == "ENTER")
            {
                value = string.Empty;
                return KeyKind.Enter;
            }

            value = string.Empty;
            return KeyKind.Unknown;
        }

        private static string GetButtonText(Button button)
        {
            TMP_Text text = button.GetComponentInChildren<TMP_Text>(true);
            return text == null ? string.Empty : text.text.Trim();
        }

        private void EnsureExpectedKeys()
        {
            for (int rowIndex = 0; rowIndex < KeyboardRows.Length; rowIndex++)
            {
                Transform row = transform.Find($"Row{rowIndex + 1}");
                if (row == null)
                {
                    continue;
                }

                foreach (string letter in KeyboardRows[rowIndex])
                {
                    EnsureKey(row, letter, 65f, 100f);
                }
            }

            Transform row3 = transform.Find("Row3");
            if (row3 != null)
            {
                EnsureKey(row3, "⌫", 100f, 100f, "Key_Backspace");
                EnsureKey(row3, "ENTER", 120f, 100f, "Key_Enter");
            }
        }

        private static void EnsureKey(Transform row, string label, float width, float height, string objectName = null)
        {
            if (FindButtonByLabel(row, label) != null)
            {
                return;
            }

            Button template = row.GetComponentInChildren<Button>(true);
            GameObject keyObject;
            if (template != null)
            {
                keyObject = Instantiate(template.gameObject, row);
                keyObject.name = objectName ?? KeyNameForLetter(label);
            }
            else
            {
                keyObject = CreateButtonObject(row, objectName ?? KeyNameForLetter(label));
            }

            LayoutElement layoutElement = keyObject.GetComponent<LayoutElement>();
            if (layoutElement == null)
            {
                layoutElement = keyObject.AddComponent<LayoutElement>();
            }

            layoutElement.preferredWidth = width;
            layoutElement.preferredHeight = height;

            TMP_Text text = keyObject.GetComponentInChildren<TMP_Text>(true);
            if (text != null)
            {
                text.text = label;
                text.fontSize = label == "ENTER" ? 28f : 32f;
                text.alignment = TextAlignmentOptions.Center;
                text.color = Color.white;
            }
        }

        private static Button FindButtonByLabel(Transform row, string label)
        {
            foreach (Button button in row.GetComponentsInChildren<Button>(true))
            {
                TMP_Text text = button.GetComponentInChildren<TMP_Text>(true);
                if (text != null && text.text.Trim() == label)
                {
                    return button;
                }
            }

            return null;
        }

        private static GameObject CreateButtonObject(Transform parent, string objectName)
        {
            GameObject keyObject = new GameObject(objectName, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button), typeof(LayoutElement));
            keyObject.transform.SetParent(parent, false);

            GameObject textObject = new GameObject("Text (TMP)", typeof(RectTransform), typeof(CanvasRenderer), typeof(TextMeshProUGUI));
            textObject.transform.SetParent(keyObject.transform, false);

            RectTransform textRect = textObject.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;

            return keyObject;
        }

        private static string KeyNameForLetter(string letter)
        {
            switch (letter)
            {
                case "Ğ":
                    return "Key_Ğ";
                case "Ü":
                    return "Key_Ü";
                case "Ş":
                    return "Key_Ş";
                case "İ":
                    return "Key_İ";
                case "Ö":
                    return "Key_Ö";
                case "Ç":
                    return "Key_Ç";
                case "⌫":
                    return "Key_Backspace";
                default:
                    return $"Key_{letter}";
            }
        }

        private enum KeyKind
        {
            Unknown,
            Letter,
            Backspace,
            Enter
        }

        private readonly struct ButtonBinding
        {
            public Button Button { get; }
            public UnityAction Action { get; }

            public ButtonBinding(Button button, UnityAction action)
            {
                Button = button;
                Action = action;
            }
        }
    }
}
