using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private void Awake()
        {
            Init();
        }


        private void Init()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public static void Quit()
        {
            Debug.Log("Quit!");
            Application.Quit();
        }

        public static void ContinueGame()
        {
            Debug.Log("Continue!");
            //todo implement
        }

        public static void NewGame()
        {
            LevelManager.Instance.LoadFirstLevel();
        }

        public static void Pause()
        {
            Time.timeScale = 0f;
        }

        public static void Resume()
        {
            Time.timeScale = 1f;
        }

        public static void RestartCurrLevel()
        {
            LevelManager.Instance.Reload();
        }

        public static void NextLevel()
        {
            LevelManager.Instance.NextLevel();
        }

        public static void OpenMainMenu()
        {
            LevelManager.Instance.OpenMainMenu();
        }
    }
}