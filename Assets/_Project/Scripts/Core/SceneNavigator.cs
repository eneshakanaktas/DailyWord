using UnityEngine.SceneManagement;

namespace DailyWord.Core
{
    /// <summary>
    /// Minimal static utility for scene transitions.
    /// Not a singleton — just a static helper.
    /// </summary>
    public static class SceneNavigator
    {
        private const string MainMenuScene = "MainMenu";
        private const string GameScene = "Game";

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuScene);
        }

        public static void LoadGame()
        {
            SceneManager.LoadScene(GameScene);
        }
    }
}
