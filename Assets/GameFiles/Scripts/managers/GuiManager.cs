using System.Collections.Generic;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class GuiManager : MonoBehaviour
    {
        public GameObject StartScreen;
        public GameObject MainMenuScreen;
        public GameObject HelpScreen;
        public GameObject ControlsScreen;
        public GameObject PauseScreen;
        public GameObject GameCompletionScreen;
        public GameObject GameOverScreen;
        public GameObject ReturnToMainMenuConfirmScreen;
        public GameObject QuitConfirmScreen;

        private bool _paused;
        public GuiScreen _currScreen;
        public GuiScreen _prevScreen;
        private Dictionary<GuiScreen, GameObject> _screenEnumToGameObject;

        private void Start()
        {
            _screenEnumToGameObject = new Dictionary<GuiScreen, GameObject>()
            {
                {GuiScreen.Start, StartScreen},
                {GuiScreen.MainMenu, MainMenuScreen},
                {GuiScreen.Help, HelpScreen},
                {GuiScreen.Controls, ControlsScreen},
                {GuiScreen.Pause, PauseScreen},
                {GuiScreen.GameCompletion, GameCompletionScreen},
                {GuiScreen.GameOver, GameOverScreen},
                {GuiScreen.ReturnToMainMenuConfirm, ReturnToMainMenuConfirmScreen},
                {GuiScreen.QuitConfirm, QuitConfirmScreen}
            };
            _prevScreen = LevelManager.Instance.GetStartingPrevScreenForCurrLevel();
            _currScreen = LevelManager.Instance.GetStartingCurrScreenForCurrLevel();
            if (_currScreen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[_currScreen].SetActive(true);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && EscAllowed())
            {
                if (!_paused)
                {
                    NavigateTo(GuiScreen.Pause);
                    GameManager.Pause();
                }
                else
                {
                    NavigateTo(GuiScreen.InGame);
                    GameManager.Resume();
                }

                _paused = !_paused;
            }
        }

        private bool EscAllowed()
        {
            return _currScreen == GuiScreen.InGame || _currScreen == GuiScreen.Pause;
        }

        public void NavigateTo(GuiScreen screen)
        {
            _prevScreen = _currScreen;
            if (_currScreen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[_currScreen].SetActive(false);
            }

            if (screen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[screen].SetActive(true);
            }

            _currScreen = screen;
        }

        public void NavigateToPrevScreen()
        {
            if (_currScreen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[_currScreen].SetActive(false);
            }

            if (_prevScreen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[_prevScreen].SetActive(true);
            }

            GuiScreen temp = _prevScreen;
            _prevScreen = _currScreen;
            _currScreen = temp;
        }
    }
}