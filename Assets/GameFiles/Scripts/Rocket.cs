using UnityEngine;

namespace GameFiles.Scripts
{
    public class Rocket : MonoBehaviour
    {
        public float LaunchThurst = 10;

        private Rigidbody2D _rigidbody;
        private bool _launched;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }

        private void Update()
        {
            if (!_launched && Input.GetKeyDown(KeyCode.Space))
            {
                _launched = true;
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.AddForce(transform.up * LaunchThurst);
            }
        }
    }
}