using UnityEngine;

namespace GameFiles.Scripts
{
    public class Rotator : MonoBehaviour
    {
        public float TurnSenstiivity = 1;
        public float MaxSteerAngle = 30;
        public Transform LaunchPlatformStand;

        private float _horizontalInput;
        private bool _deatached;

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            var steerAngle = _horizontalInput * MaxSteerAngle * TurnSenstiivity;
            if (!_deatached)
            {
                transform.RotateAround(LaunchPlatformStand.transform.position, Vector3.back, steerAngle);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -steerAngle));
            }
        }

        public void Detach()
        {
            _deatached = true;
            TurnSenstiivity = 0.3f;
        }
    }
}