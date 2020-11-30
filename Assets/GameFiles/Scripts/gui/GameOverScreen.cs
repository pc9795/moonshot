using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class GameOverScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Restart()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.RestartCurrLevel();
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            GameManager.OpenMainMenu();
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}