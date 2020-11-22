using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class GuiManager : MonoBehaviour
    {
        public GameObject GameOverScreen;
        public GameObject mainMenuScreen;
        public GameObject startScreen;
        public GameObject pauseScreen;

        // ReSharper disable once UnusedMember.Global
        public void Restart()
        {
            Debug.Log("Restart!");
            GameOverScreen.SetActive(false);
            GameManager.Restart();
        }

        // ReSharper disable once UnusedMember.Global
        public void MainMenu()
        {
            GameOverScreen.SetActive(false);
            //todo implement
        }

        // ReSharper disable once UnusedMember.Global
        public void Quit()
        {
            Debug.Log("Quit!");
            Application.Quit();
        }

        // ReSharper disable once UnusedMember.Global
        public void StartGame()
        {
            startScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }
}