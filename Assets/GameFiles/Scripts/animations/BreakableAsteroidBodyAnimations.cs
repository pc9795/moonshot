using GameFiles.Scripts.objects;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.animations
{
    public class BreakableAsteroidBodyAnimations : MonoBehaviour
    {
        public Animator BreakableAsteroidBodyAnimator;

        private BreakableAsteroid _breakableAsteroid;

        private void Start()
        {
            _breakableAsteroid = GetComponentInParent<BreakableAsteroid>();
        }

        public void BlastAnimation()
        {
            BreakableAsteroidBodyAnimator.SetBool(MoonShotAnimator.Parameters.Alive, false);
        }

        // ReSharper disable once UnusedMember.Global
        // Animation Event at the end of Blast Animation
        public void OnBlastAnimationEnd()
        {
            Destroy(_breakableAsteroid.gameObject);
        }

        // ReSharper disable once UnusedMember.Global
        // Animation Evnet on Blast Animation
        public void OnBlastAnimationDisappearSprite()
        {
            _breakableAsteroid.RemoveSprite();
        }
    }
}