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
            _guiManager.NavigateTo(GuiScreen.MainMenu);
        }

        // ReSharper disable once UnusedMember.Global
        public void No()
        {
            _guiManager.NavigateToPrevScreen();
        }
    }
}
