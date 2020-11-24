using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class StartScreen : MonoBehaviour
    {
        public GameObject MainMenuScreen;
        public GameObject ThisScreen;
        public GameObject QuitConfirmScreen;

        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void StartGame()
        {
            ThisScreen.SetActive(false);
            MainMenuScreen.SetActive(true);
            _guiManager.SetCurrScreen(GuiScreen.MainMenu);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            ThisScreen.SetActive(false);
            QuitConfirmScreen.SetActive(true);
            _guiManager.SetCurrScreen(GuiScreen.QuitConfirm);
        }
    }
}