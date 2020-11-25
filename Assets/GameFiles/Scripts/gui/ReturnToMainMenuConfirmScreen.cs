using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class ReturnToMainMenuConfirmScreen : MonoBehaviour
    {
        private GuiManager _guiManager;

        private void Start()
        {
            _guiManager = FindObjectOfType<GuiManager>();
        }

        // ReSharper disable once UnusedMember.Global
        public void Yes()
        {
            GameManager.OpenMainMenu();
        }

        // ReSharper disable once UnusedMember.Global
        public void No()
        {
            _guiManager.NavigateToPrevScreen();
        }
    }
}
