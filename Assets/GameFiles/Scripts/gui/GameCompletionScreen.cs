using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class GameCompletionScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
            GameManager.OpenMainMenu();
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            _guiManager.NavigateTo(GuiScreen.QuitConfirm);
        }
    }
}