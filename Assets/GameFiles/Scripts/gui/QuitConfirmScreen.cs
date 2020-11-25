using GameFiles.Scripts.managers;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class QuitConfirmScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Yes()
        {
            GuiManager.Quit();
        }

        // ReSharper disable once UnusedMember.Global
        public void No()
        {
            _guiManager.NavigateToPrevScreen();
        }
    }
}