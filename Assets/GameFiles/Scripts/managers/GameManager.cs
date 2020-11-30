using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            Init();
        }


        private void Init()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            AudioManager.Instance.Play(AudioTrack.StartScreen);
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