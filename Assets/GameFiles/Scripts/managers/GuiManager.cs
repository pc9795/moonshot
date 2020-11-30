using System;
using System.Collections.Generic;
using GameFiles.Scripts.plain.objects;
using UnityEngine;
using UnityEngine.UI;

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
        public GameObject LevelCompleteScreen;
        public GameObject Hud;
        public GameObject BoostsHud;
        public GameObject DropshipsHud;
        public GameObject BulletsHud;

        private bool _paused;
        private GuiScreen _currScreen;
        private GuiScreen _prevScreen;
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
                {GuiScreen.QuitConfirm, QuitConfirmScreen},
                {GuiScreen.LevelComplete, LevelCompleteScreen}
            };
            _prevScreen = LevelManager.Instance.GetStartingPrevScreenForCurrLevel();
            _currScreen = LevelManager.Instance.GetStartingCurrScreenForCurrLevel();
            if (_currScreen != GuiScreen.InGame)
            {
                _screenEnumToGameObject[_currScreen].SetActive(true);
            }

            PlayMusic();
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

            Hud.SetActive(_currScreen == GuiScreen.InGame);
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
            PlayMusic();
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
            PlayMusic();
        }

        private void PlayMusic()
        {
            var prevAudioTrack = GetAudioTrackFromScreen(_prevScreen);
            var currAudioTrack = GetAudioTrackFromScreen(_currScreen);
            if (prevAudioTrack.Equals(currAudioTrack))
            {
                return;
            }

            AudioManager.Instance.Stop(prevAudioTrack);
            AudioManager.Instance.Play(currAudioTrack);
        }

        private static string GetAudioTrackFromScreen(GuiScreen screen)
        {
            switch (screen)
            {
                case GuiScreen.Start:
                case GuiScreen.MainMenu:
                    return AudioTrack.StartScreen;
                case GuiScreen.Pause:
                case GuiScreen.ReturnToMainMenuConfirm:
                case GuiScreen.InGame:
                    return AudioTrack.InGame;
                case GuiScreen.Help:
                case GuiScreen.Controls:
                case GuiScreen.QuitConfirm:
                case GuiScreen.LevelComplete:
                    return LevelManager.Instance.GetCurrLevel() == 0 ? AudioTrack.StartScreen : AudioTrack.InGame;
                case GuiScreen.GameOver:
                    return AudioTrack.GameOver;
                case GuiScreen.GameCompletion:
                    return AudioTrack.GameCompletion;
                default:
                    throw new SystemException(screen + " not mapped!");
            }
        }

        public void UpdateBoostsInHud(int boosts)
        {
            BoostsHud.GetComponentInChildren<Text>().text = boosts.ToString();
        }

        public void MakeBoostsNotAvailableInHud()
        {
            BoostsHud.GetComponentInChildren<Text>().text = "Recharging...";
        }

        public void UpdateDropshipsInHud(int dropships)
        {
            DropshipsHud.GetComponentInChildren<Text>().text = dropships.ToString();
        }

        public void MakeDropshipsNotAvailableInHud()
        {
            DropshipsHud.GetComponentInChildren<Text>().text = "Recharging...";
        }

        public void UpdateBulletsInHud(int bullets)
        {
            BulletsHud.GetComponentInChildren<Text>().text = bullets.ToString();
        }

        public void MakeBulletsNotAvailableInHud()
        {
            BulletsHud.GetComponentInChildren<Text>().text = "Recharging...";
        }
    }
}