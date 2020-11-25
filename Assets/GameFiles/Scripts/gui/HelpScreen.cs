using GameFiles.Scripts.managers;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class HelpScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Back()
        {
            _guiManager.NavigateToPrevScreen();
        }
    }
}