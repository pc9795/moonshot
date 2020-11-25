using GameFiles.Scripts.managers;
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
        }

        // ReSharper disable once UnusedMember.Global
        public void Restart()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public void Controls()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public void Help()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
        }
    }
}