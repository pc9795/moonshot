using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class ControlsScreen : MonoBehaviour
    {
        public GameObject ThisScreen;
        public GameObject MainMenuScreen;

        // ReSharper disable once UnusedMember.Global
        public void Back()
        {
            ThisScreen.SetActive(false);
            MainMenuScreen.SetActive(true);
        }
    }
}