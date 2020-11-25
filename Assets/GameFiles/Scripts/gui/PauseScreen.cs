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
            _guiManager.NavigateTo(GuiScreen.InGame);
        }

        // ReSharper disable once UnusedMember.Global
        public void Restart()
        {
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.RestartCurrLevel();
        }

        // ReSharper disable once UnusedMember.Global
        public void Controls()
        {
            _guiManager.NavigateTo(GuiScreen.Controls);
        }

        // ReSharper disable once UnusedMember.Global
        public void Help()
        {
            _guiManager.NavigateTo(GuiScreen.Help);
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
            _guiManager.NavigateTo(GuiScreen.ReturnToMainMenuConfirm);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}