using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFiles.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public Rocket Player;
        public GameObject Boundary;

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

        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void Quit()
        {
            Debug.Log("Quit!"); //todo remove
            Application.Quit();
        }

        public static void NewGame()
        {
            Debug.Log("New Game!"); //todo remove
            //todo implement
        }
    }
}