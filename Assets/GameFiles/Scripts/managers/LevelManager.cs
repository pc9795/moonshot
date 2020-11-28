using System.Collections.Generic;
using GameFiles.Scripts.plain.objects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFiles.Scripts.managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        private List<string> _levels;
        private int _currLevelIndex;
        private GuiManager _guiManager;
        private bool _startScreenOpened;

        private void Awake()
        {
            Init();
            _levels = new List<string>
            {
                "GameFiles/Scenes/Begin",
                "GameFiles/Scenes/Level 1",
                "GameFiles/Scenes/Level 2",
                "GameFiles/Scenes/Level 3",
                "GameFiles/Scenes/Level 4",
                "GameFiles/Scenes/End"
            };
            _currLevelIndex = GameManager.Instance.DevMode ? GameManager.Instance.DevModeCurrLevel : 0;
            _startScreenOpened = false;
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

        public void OpenMainMenu()
        {
            _currLevelIndex = 0;
            SceneManager.LoadScene(_levels[_currLevelIndex]);
        }

        public GuiScreen GetStartingPrevScreenForCurrLevel()
        {
            return _currLevelIndex == 0 || _currLevelIndex == _levels.Count - 1 ? GuiScreen.InGame : GuiScreen.MainMenu;
        }

        public GuiScreen GetStartingCurrScreenForCurrLevel()
        {
            if (_currLevelIndex != 0)
                return _currLevelIndex == _levels.Count - 1 ? GuiScreen.GameCompletion : GuiScreen.InGame;
            if (_startScreenOpened) return GuiScreen.MainMenu;
            _startScreenOpened = true;
            return GuiScreen.Start;
        }
    }
}