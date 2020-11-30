using UnityEngine;

namespace GameFiles.Scripts.behaviours
{
    public class PayloadDropper : MonoBehaviour
    {
        public GameObject Payload;
        public Vector2 OffSet;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Drop()
        {
            Instantiate(Payload,
                _rigidbody2D.transform.position + new Vector3(OffSet.x * -_rigidbody2D.transform.up.x,
                    OffSet.y * -_rigidbody2D.transform.up.y, 0), Quaternion.identity);
        }
    }
}