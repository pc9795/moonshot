using UnityEngine;

namespace GameFiles.Scripts
{
    public class PayloadDropper : MonoBehaviour
    {
        public GameObject Payload;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Drop()
        {
            Instantiate(Payload, _rigidbody2D.transform.position, Quaternion.identity);
        }
    }
}