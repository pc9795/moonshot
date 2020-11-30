using GameFiles.Scripts.objects;
using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class CameraManager : MonoBehaviour
    {
        public Rocket Rocket;
        public Vector2 Offset;
        public float ScrollSpeed = 0.005f;
        public float MaxY = 70f;
        public float MinY = -30f;


        private void Start()
        {
            if (!Rocket)
            {
                return;
            }

            transform.position = new Vector3(Rocket.transform.position.x + Offset.x,
                Rocket.transform.position.y + Offset.y,
                transform.position.z);
        }

        private void Update()
        {
            if (!Rocket)
            {
                return;
            }

            if (!Rocket.IsLaunched())
            {
                ScrollCamera();
            }
            else
            {
                transform.position = new Vector3(Rocket.transform.position.x + Offset.x,
                    Rocket.transform.position.y + Offset.y,
                    transform.position.z);
            }
        }

        private void ScrollCamera()
        {
            var verticalInput = Input.GetAxis("Vertical");
            var newY = transform.position.y + ScrollSpeed * verticalInput;
            if (newY > MaxY || newY < MinY)
            {
                return;
            }

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}