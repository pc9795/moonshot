using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class GuiManager : MonoBehaviour
    {
        public GameObject PauseScreen;

        private bool _paused;
        private GuiScreen _currScreen;
        private GuiScreen _prevScreen;

        private void Awake()
        {
            _prevScreen = GuiScreen.InGame;
            _currScreen = GuiScreen.Start;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_paused)
                {
                    PauseScreen.SetActive(true);
                    GameManager.Pause();
                }
                else
                {
                    PauseScreen.SetActive(false);
                    GameManager.Resume();
                }

                _paused = !_paused;
            }
        }

        public GuiScreen GetPrevScreen()
        {
            return _prevScreen;
        }

        public GuiScreen GetCurrScreen()
        {
            return _currScreen;
        }

        public void SetCurrScreen(GuiScreen currScreen)
        {
            _prevScreen = _currScreen;
            _currScreen = currScreen;
        }
    }
}