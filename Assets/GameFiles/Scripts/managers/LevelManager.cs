using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFiles.Scripts.managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        private List<string> _levels;
        private int _currLevelIndex;

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
            _levels = new List<string> {"GameFiles/Scenes/Begin", "GameFiles/Scenes/Level 1", "GameFiles/Scenes/Level 2"};
            _currLevelIndex = 0;
        }

        public void NextLevel()
        {
            _currLevelIndex++;
            SceneManager.LoadScene(_levels[_currLevelIndex]);
        }

        public void Reload()
        {
            SceneManager.LoadScene(_levels[_currLevelIndex]);
        }

        public void LoadFirstLevel()
        {
            _currLevelIndex = 1;
            SceneManager.LoadScene(_levels[_currLevelIndex]);
        }
    }
}