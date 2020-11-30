using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.gui
{
    public class LevelCompleteScreen : MonoBehaviour
    {
        // ReSharper disable once UnusedMember.Global
        public void Continue()
        {
            AudioManager.Instance.Stop(AudioTrack.ReachMoon);
            AudioManager.Instance.Play(AudioTrack.UiButtonCick);
            GameManager.Resume();
            if (LevelManager.Instance.DevMode)
            {
                GameManager.RestartCurrLevel();
            }
            else
            {
                GameManager.NextLevel();
            }
        }
    }
}