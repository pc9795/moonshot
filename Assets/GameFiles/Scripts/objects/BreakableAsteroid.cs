using GameFiles.Scripts.animations;
using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class BreakableAsteroid : MonoBehaviour
    {
        public bool Movable;
        public float Stride = 1f;
        public float HorizontalInterpolationValue = 8f;
        public bool TopToBottom;
        public bool LeftToRight;
        public bool MovingRight;
        public bool MovingBottom;

        private BreakableAsteroidBodyAnimations _breakableAsteroidBodyAnimations;
        private bool _blasting;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _startPos;

        private void Start()
        {
            _breakableAsteroidBodyAnimations = GetComponentInChildren<BreakableAsteroidBodyAnimations>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider2D = GetComponent<Collider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _startPos = transform.position;
            if (Movable)
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                _rigidbody2D.gravityScale = 0;
            }
        }

        private void Update()
        {
            if (!Movable)
            {
                return;
            }

            if (TopToBottom && LeftToRight)
            {
                MoveTopToBottom();
                MoveLeftToRight();
            }
            else if (TopToBottom)
            {
                MoveTopToBottom();
            }
            else if (LeftToRight)
            {
                MoveLeftToRight();
            }
        }

        private void MoveLeftToRight()
        {
            var dest = MovingRight
                ? _startPos.x + Stride
                : _startPos.x - Stride;
            var newX = Mathf.Lerp(transform.position.x, dest, HorizontalInterpolationValue * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            if (MovingRight)
            {
                if (Approximately(newX, dest) || newX >= dest)
                {
                    MovingRight = false;
                }
            }
            else
            {
                if (Approximately(newX, dest) || newX <= dest)
                {
                    MovingRight = true;
                }
            }
        }

        private void MoveTopToBottom()
        {
            var dest = !MovingBottom
                ? _startPos.y + Stride
                : _startPos.y - Stride;
            var newY = Mathf.Lerp(transform.position.y, dest, HorizontalInterpolationValue * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            if (!MovingBottom)
            {
                if (Approximately(newY, dest) || newY >= dest)
                {
                    MovingBottom = true;
                }
            }
            else
            {
                if (Approximately(newY, dest) || newY <= dest)
                {
                    MovingBottom = false;
                }
            }
        }

        private static bool Approximately(float x, float y)
        {
            return Mathf.Abs(x - y) <= 0.1f;
        }


        public void Blast()
        {
            _breakableAsteroidBodyAnimations.BlastAnimation();
            _blasting = true;
            _collider2D.isTrigger = true; // Ignore further collisions
            AudioManager.Instance.Play(AudioTrack.AsteroidBlast);
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