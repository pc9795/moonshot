using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class BouncyTrigger : MonoBehaviour
    {
        public float TriggerThrust = 600;
        public GameObject Holder;

        private Rocket _rocket;

        private void Start()
        {
            _rocket = FindObjectOfType<Rocket>();
        }

        private void Update()
        {
            transform.position = Holder.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(Tag.BouncyAsteroid))
            {
                Debug.Log("Trigger touched!");
                _rocket.GetComponent<Rigidbody2D>().AddForce(_rocket.transform.up * TriggerThrust);
            }
        }
    }
}