using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class StartScreen : MonoBehaviour
    {
        public GameObject MainMenuScreen;
        public GameObject ThisScreen;

        // ReSharper disable once UnusedMember.Global
        public void StartGame()
        {
            ThisScreen.SetActive(false);
            MainMenuScreen.SetActive(true);
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            GameManager.Quit();
        }
    }
}