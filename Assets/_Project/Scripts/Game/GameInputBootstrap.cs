using UnityEngine;
using UnityEngine.SceneManagement;

namespace DailyWord.Game
{
    public static class GameInputBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void BootstrapGameScene()
        {
            if (SceneManager.GetActiveScene().name != "Game")
            {
                return;
            }

            if (Object.FindAnyObjectByType<GameInputController>() != null)
            {
                return;
            }

            GameObject boardObject = GameObject.Find("Board");
            GameObject keyboardObject = GameObject.Find("Keyboard");
            if (boardObject == null || keyboardObject == null)
            {
                return;
            }

            GameBoardView boardView = boardObject.GetComponent<GameBoardView>();
            if (boardView == null)
            {
                boardView = boardObject.AddComponent<GameBoardView>();
            }

            TurkishKeyboardController keyboardController = keyboardObject.GetComponent<TurkishKeyboardController>();
            if (keyboardController == null)
            {
                keyboardController = keyboardObject.AddComponent<TurkishKeyboardController>();
            }

            Transform parent = boardObject.transform.parent;
            GameObject controllerObject = new GameObject("GameInputController");
            if (parent != null)
            {
                controllerObject.transform.SetParent(parent, false);
            }

            GameInputController inputController = controllerObject.AddComponent<GameInputController>();
            inputController.Configure(boardView, keyboardController);
        }
    }
}
