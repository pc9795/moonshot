using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class StartScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void StartGame()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.MainMenu);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}