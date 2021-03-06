﻿using System.Collections.Generic;
using GameFiles.Scripts.plain.objects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFiles.Scripts.managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public bool DevMode;
        public int DevModeCurrLevel;
        public int LevelsCount = 10;

        private List<string> _levels;
        private int _currLevelIndex;
        private GuiManager _guiManager;
        private bool _startScreenOpened;

        private void Awake()
        {
            Init();
            InitLevels();
            _startScreenOpened = false;
            _currLevelIndex = DevMode ? DevModeCurrLevel : 0;
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

        private void InitLevels()
        {
            _levels = new List<string>
            {
                "GameFiles/Scenes/Begin",
            };
            for (var i = 1; i <= LevelsCount; i++)
            {
                _levels.Add("GameFiles/Scenes/Level " + i);
            }

            _levels.Add("GameFiles/Scenes/End");
        }

        public int GetCurrLevel()
        {
            return _currLevelIndex;
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
            if (_currLevelIndex == 0)
            {
                return GuiScreen.GameCompletion;
            }

            return _currLevelIndex == _levels.Count - 1 ? GuiScreen.InGame : GuiScreen.MainMenu;
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