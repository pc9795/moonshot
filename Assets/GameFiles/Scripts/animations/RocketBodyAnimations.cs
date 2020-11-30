using GameFiles.Scripts.objects;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.animations
{
    public class RocketBodyAnimations : MonoBehaviour
    {
        public Animator RocketBodyAnimator;

        private Rocket _rocket;

        private void Start()
        {
            _rocket = GetComponentInParent<Rocket>();
        }
        
        public void BlastAnimation()
        {
            RocketBodyAnimator.SetBool(MoonShotAnimator.Parameters.Alive, false);
        }

        // ReSharper disable once UnusedMember.Global
        // Animation Event at the end of Blast Animation
        public void OnBlastAnimationEnd()
        {
            _rocket.LoseLevel();
        }
    }
}