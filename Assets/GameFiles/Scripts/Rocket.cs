using GameFiles.Scripts.enums;
using UnityEngine;

namespace GameFiles.Scripts
{
    public class Rocket : MonoBehaviour
    {
        public float LaunchThurst = 10;

        private Rigidbody2D _rigidbody;
        private bool _launched;
        private StatsManager _statsManager;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _statsManager = GetComponent<StatsManager>();
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
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Boundary))
            {
                Debug.LogWarning("Out of boundary!");
                _statsManager.Die();
            }
        }
    }
}