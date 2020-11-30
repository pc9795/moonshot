using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class RocketFire : MonoBehaviour
    {
        public Animator RocketFireAnimator;

        public void LaunchFireAnimation()
        {
            RocketFireAnimator.SetBool(MoonShotAnimator.Parameters.LaunchFire, true);
        }

        // ReSharper disable once UnusedMember.Global
        // Animation Event at the end of LaunchFire Animation
        public void OnLaunchFireAnimationEnd()
        {
            RocketFireAnimator.SetBool(MoonShotAnimator.Parameters.LaunchFire, false);
        }
    }
}