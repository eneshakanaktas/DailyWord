using UnityEngine;

namespace DailyWord.UI
{
    /// <summary>
    /// Adjusts the attached RectTransform to fit within the device safe area.
    /// Handles notches, rounded corners, and status bars on mobile devices.
    /// Attach to a full-screen UI panel that should respect safe area boundaries.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaHandler : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect lastSafeArea;
        private Vector2Int lastScreenSize;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            ApplySafeArea();
        }

        private void Update()
        {
            if (HasScreenChanged())
            {
                ApplySafeArea();
            }
        }

        private bool HasScreenChanged()
        {
            Rect currentSafeArea = Screen.safeArea;
            Vector2Int currentScreenSize = new Vector2Int(Screen.width, Screen.height);

            if (currentSafeArea != lastSafeArea || currentScreenSize != lastScreenSize)
            {
                return true;
            }

            return false;
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;
            lastSafeArea = safeArea;
            lastScreenSize = new Vector2Int(Screen.width, Screen.height);

            if (Screen.width <= 0 || Screen.height <= 0)
            {
                return;
            }

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }
    }
}
