using UnityEngine;
using UnityEngine.UI;
using DailyWord.Core;

namespace DailyWord.UI
{
    /// <summary>
    /// Controls the Main Menu screen.
    /// Handles button interactions and navigation.
    /// Attach to the MainMenuCanvas root or a dedicated controller object.
    /// </summary>
    public sealed class MainMenuController : MonoBehaviour
    {
        [Header("Primary Action")]
        [SerializeField] private Button todaysPuzzleButton;

        [Header("Secondary Navigation")]
        [SerializeField] private Button statisticsButton;
        [SerializeField] private Button historyButton;
        [SerializeField] private Button settingsButton;

        private void Start()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            if (todaysPuzzleButton != null)
            {
                todaysPuzzleButton.onClick.AddListener(OnTodaysPuzzlePressed);
            }

            if (statisticsButton != null)
            {
                statisticsButton.onClick.AddListener(OnStatisticsPressed);
            }

            if (historyButton != null)
            {
                historyButton.onClick.AddListener(OnHistoryPressed);
            }

            if (settingsButton != null)
            {
                settingsButton.onClick.AddListener(OnSettingsPressed);
            }
        }

        private void OnDestroy()
        {
            if (todaysPuzzleButton != null)
            {
                todaysPuzzleButton.onClick.RemoveListener(OnTodaysPuzzlePressed);
            }

            if (statisticsButton != null)
            {
                statisticsButton.onClick.RemoveListener(OnStatisticsPressed);
            }

            if (historyButton != null)
            {
                historyButton.onClick.RemoveListener(OnHistoryPressed);
            }

            if (settingsButton != null)
            {
                settingsButton.onClick.RemoveListener(OnSettingsPressed);
            }
        }

        private void OnTodaysPuzzlePressed()
        {
            SceneNavigator.LoadGame();
        }

        private void OnStatisticsPressed()
        {
            Debug.Log("[MainMenu] İstatistikler — henüz uygulanmadı.");
        }

        private void OnHistoryPressed()
        {
            Debug.Log("[MainMenu] Bulmaca Geçmişi — henüz uygulanmadı.");
        }

        private void OnSettingsPressed()
        {
            Debug.Log("[MainMenu] Ayarlar — henüz uygulanmadı.");
        }
    }
}
