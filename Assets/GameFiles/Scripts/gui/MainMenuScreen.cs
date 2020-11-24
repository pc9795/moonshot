using GameFiles.Scripts.managers;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class MainMenuScreen : MonoBehaviour
    {
        public GameObject ThisScreen;
        public GameObject ControlsScreen;
        public GameObject HelpScreen;

        // ReSharper disable once UnusedMember.Global
        public void Continue()
        {
            Debug.Log("Continue!"); //todo remove
            //todo implement
        }

        // ReSharper disable once UnusedMember.Global
        public void NewGame()
        {
            ThisScreen.SetActive(false);
            GameManager.NewGame();
        }

        // ReSharper disable once UnusedMember.Global
        public void Controls()
        {
            ThisScreen.SetActive(false);
            ControlsScreen.SetActive(true);
        }

        // ReSharper disable once UnusedMember.Global
        public void Help()
        {
            ThisScreen.SetActive(false);
            HelpScreen.SetActive(true);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            GameManager.Quit();
        }
    }
}