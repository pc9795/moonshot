using UnityEngine;

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
    }
}