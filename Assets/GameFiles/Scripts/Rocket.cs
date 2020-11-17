using GameFiles.Scripts.enums;
using UnityEngine;

namespace GameFiles.Scripts
{
    public class Rocket : MonoBehaviour
    {
        public float LaunchThurst = 500;
        public float BoostThrust = 800;

        private Rigidbody2D _rigidbody;
        private bool _launched;
        private StatsManager _statsManager;
        private Rotator _rotator;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _statsManager = GetComponent<StatsManager>();
            _rotator = GetComponent<Rotator>();
        }

        private void Update()
        {
            if (!_statsManager.IsAlive())
            {
                return;
            }

            if (!_launched && Input.GetKeyDown(KeyCode.Space))
            {
                _launched = true;
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.AddForce(transform.up * LaunchThurst);
                _rotator.Detach();
            }

            if (_launched)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && _statsManager.CanBoost())
                {
                    _statsManager.UseBoost();
                    _rigidbody.AddForce(transform.up * BoostThrust);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Boundary))
            {
                _statsManager.Die();
                GameManager.Restart(); // todo remove
                return;
            }

            if (other.CompareTag(Tag.Moon))
            {
                Debug.Log("You Won!");
                GameManager.Restart();
            }
        }
    }
}