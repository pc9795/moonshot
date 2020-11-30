using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class PauseScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Continue()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.Resume();
        }

        // ReSharper disable once UnusedMember.Global
        public void Restart()
        {
            GameManager.Resume();
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.RestartCurrLevel();
        }

        // ReSharper disable once UnusedMember.Global
        public void Controls()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.Controls);
        }

        // ReSharper disable once UnusedMember.Global
        public void Help()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.Help);
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.ReturnToMainMenuConfirm);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}