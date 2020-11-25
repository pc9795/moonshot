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
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.ContinueGame();
        }

        // ReSharper disable once UnusedMember.Global
        public void NewGame()
        {
            _guiManager.NavigateTo(GuiScreen.InGame);
            GameManager.NewGame();
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
        public void Quit()
        {
            GameManager.Quit();
        }
    }
}