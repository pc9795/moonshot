using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class ConfigManager : MonoBehaviour
    {
        public static ConfigManager Instance;

        public float BulletSpeed = 1f;
        public int BulletDuration = 3;

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