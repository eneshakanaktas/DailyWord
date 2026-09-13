using DailyWord.Game;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace DailyWord.EditorTools
{
    public static class GameScene3CSetup
    {
        private const string GameScenePath = "Assets/_Project/Scenes/Game.unity";

        private static readonly string[][] KeyboardRows =
        {
            new[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "Ğ", "Ü" },
            new[] { "A", "S", "D", "F", "G", "H", "J", "K", "L", "Ş", "İ" },
            new[] { "Z", "X", "C", "V", "B", "N", "M", "Ö", "Ç" }
        };

        [MenuItem("DailyWord/Setup/Apply Stage 3C Game Input")]
        public static void Apply()
        {
            EditorSceneManager.OpenScene(GameScenePath);

            GameObject safeArea = GameObject.Find("SafeAreaPanel");
            GameObject board = GameObject.Find("Board");
            GameObject keyboard = GameObject.Find("Keyboard");

            if (safeArea == null || board == null || keyboard == null)
            {
                throw new MissingReferenceException("Game scene requires SafeAreaPanel, Board, and Keyboard before Stage 3C setup.");
            }

            EnsureComponent<GameBoardView>(board);
            EnsureComponent<TurkishKeyboardController>(keyboard);
            GameInputController inputController = EnsureInputController(safeArea.transform);
            inputController.Configure(board.GetComponent<GameBoardView>(), keyboard.GetComponent<TurkishKeyboardController>());

            EnsureKeyboardRows(keyboard.transform);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }

        private static void EnsureKeyboardRows(Transform keyboard)
        {
            for (int rowIndex = 0; rowIndex < KeyboardRows.Length; rowIndex++)
            {
                Transform row = keyboard.Find($"Row{rowIndex + 1}");
                if (row == null)
                {
                    continue;
                }

                foreach (string letter in KeyboardRows[rowIndex])
                {
                    EnsureKey(row, KeyNameForLetter(letter), letter, 65f, 100f);
                }
            }

            Transform row3 = keyboard.Find("Row3");
            if (row3 != null)
            {
                EnsureKey(row3, "Key_Backspace", "⌫", 100f, 100f);
                EnsureKey(row3, "Key_Enter", "ENTER", 120f, 100f);
            }
        }

        private static void EnsureKey(Transform row, string objectName, string label, float width, float height)
        {
            if (FindButtonByLabelOrName(row, objectName, label) != null)
            {
                return;
            }

            Button template = row.GetComponentInChildren<Button>(true);
            GameObject keyObject;
            if (template != null)
            {
                keyObject = Object.Instantiate(template.gameObject, row);
                keyObject.name = objectName;
            }
            else
            {
                keyObject = CreateButtonObject(row, objectName);
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

        private static Button FindButtonByLabelOrName(Transform row, string objectName, string label)
        {
            foreach (Button button in row.GetComponentsInChildren<Button>(true))
            {
                if (button.name == objectName)
                {
                    return button;
                }

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

        private static T EnsureComponent<T>(GameObject target) where T : Component
        {
            T component = target.GetComponent<T>();
            if (component == null)
            {
                component = target.AddComponent<T>();
            }

            return component;
        }

        private static GameInputController EnsureInputController(Transform safeArea)
        {
            Transform existing = safeArea.Find("GameInputController");
            if (existing == null)
            {
                GameObject controllerObject = new GameObject("GameInputController");
                controllerObject.transform.SetParent(safeArea, false);
                return controllerObject.AddComponent<GameInputController>();
            }

            return EnsureComponent<GameInputController>(existing.gameObject);
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
                default:
                    return $"Key_{letter}";
            }
        }
    }
}
