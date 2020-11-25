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
        private GuiScreen _currScreen;
        private GuiScreen _prevScreen;
        private Dictionary<GuiScreen, GameObject> _screenEnumToGameObject;

        private void Awake()
        {
            _prevScreen = GuiScreen.InGame;
            _currScreen = GuiScreen.Start;
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
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_paused)
                {
                    PauseScreen.SetActive(true);
                    GameManager.Pause();
                }
                else
                {
                    PauseScreen.SetActive(false);
                    GameManager.Resume();
                }

                _paused = !_paused;
            }
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

        public static void Quit()
        {
            GameManager.Quit();
        }
    }
}