using GameFiles.Scripts.animations;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class BreakableAsteroid : MonoBehaviour
    {
        private BreakableAsteroidBodyAnimations _breakableAsteroidBodyAnimations;
        private bool _blasting;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider2D;

        private void Start()
        {
            _breakableAsteroidBodyAnimations = GetComponentInChildren<BreakableAsteroidBodyAnimations>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void Blast()
        {
            _blasting = true;
            _collider2D.isTrigger = true; // Ignore further collisions
            _breakableAsteroidBodyAnimations.BlastAnimation();
        }

        public bool IsBlasting()
        {
            return _blasting;
        }

        public void RemoveSprite()
        {
            _spriteRenderer.sprite = null;
        }
    }
}