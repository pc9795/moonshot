using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class ReturnToMainMenuConfirmScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Yes()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            GameManager.OpenMainMenu();
        }

        // ReSharper disable once UnusedMember.Global
        public void No()
        {
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            _guiManager.NavigateToPrevScreen();
        }
    }
}
