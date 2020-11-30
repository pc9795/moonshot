using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class MainMenuScreen : MonoBehaviour
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
            GameManager.ContinueGame();
        }

        // ReSharper disable once UnusedMember.Global
        public void NewGame()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.NewGame();
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
        public void Quit()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}