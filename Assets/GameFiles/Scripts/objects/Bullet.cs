using GameFiles.Scripts.managers;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Vector3 _direction;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0;
        }

        private void Update()
        {
            transform.position += _direction * ConfigManager.Instance.BulletSpeed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var rocket = other.collider.GetComponent<Rocket>();
            if (rocket != null)
            {
                return;
            }

            var breakableAsteroid = other.collider.GetComponent<BreakableAsteroid>();
            if (breakableAsteroid != null)
            {
                breakableAsteroid.Blast();
                Blast();
            }
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void Blast()
        {
            Destroy(gameObject);
        }
    }
}