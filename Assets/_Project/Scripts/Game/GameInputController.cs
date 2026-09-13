using System;
using UnityEngine;

namespace DailyWord.Game
{
    public sealed class GameInputController : MonoBehaviour
    {
        [SerializeField] private GameBoardView boardView;
        [SerializeField] private TurkishKeyboardController keyboardController;

        private GameInputState inputState;

        public event Action<string, int> RowSubmitted;

        public GameInputState InputState => inputState;

        private void Awake()
        {
            ResolveReferences();
            inputState = new GameInputState();
        }

        private void OnEnable()
        {
            BindKeyboard();
        }

        private void OnDisable()
        {
            UnbindKeyboard();
        }

        public void Configure(GameBoardView board, TurkishKeyboardController keyboard)
        {
            boardView = board;
            keyboardController = keyboard;
        }

        public void HandleLetter(string letter)
        {
            if (inputState == null)
            {
                inputState = new GameInputState();
            }

            if (inputState.TryAddLetter(letter, out int row, out int column))
            {
                boardView?.SetLetter(row, column, letter);
            }
        }

        public void HandleBackspace()
        {
            if (inputState != null && inputState.TryBackspace(out int row, out int column))
            {
                boardView?.ClearLetter(row, column);
            }
        }

        public void HandleEnter()
        {
            if (inputState == null || !inputState.TryGetCurrentGuess(out string guess))
            {
                return;
            }

            RowSubmitted?.Invoke(guess, inputState.ActiveRow);
            Debug.Log($"[GameInput] Row ready for evaluation: {guess}");
        }

        public bool AdvanceRowAfterEvaluation()
        {
            return inputState != null && inputState.TryAdvanceRow();
        }

        private void ResolveReferences()
        {
            if (boardView == null)
            {
                boardView = FindAnyObjectByType<GameBoardView>();
            }

            if (keyboardController == null)
            {
                keyboardController = FindAnyObjectByType<TurkishKeyboardController>();
            }
        }

        private void BindKeyboard()
        {
            if (keyboardController == null)
            {
                return;
            }

            keyboardController.LetterPressed += HandleLetter;
            keyboardController.BackspacePressed += HandleBackspace;
            keyboardController.EnterPressed += HandleEnter;
        }

        private void UnbindKeyboard()
        {
            if (keyboardController == null)
            {
                return;
            }

            keyboardController.LetterPressed -= HandleLetter;
            keyboardController.BackspacePressed -= HandleBackspace;
            keyboardController.EnterPressed -= HandleEnter;
        }
    }
}
