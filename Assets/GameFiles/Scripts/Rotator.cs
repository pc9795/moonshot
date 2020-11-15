using UnityEngine;

namespace GameFiles.Scripts
{
    public class Rotator : MonoBehaviour
    {
        public float TurnSenstiivity = 1;
        public float MaxSteerAngle = 30;
        public Transform LaunchPlatformStand;

        private float _horizontalInput;

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            var steerAngle = _horizontalInput * MaxSteerAngle * TurnSenstiivity;
            transform.RotateAround(LaunchPlatformStand.transform.position, Vector3.back, steerAngle);
        }
    }
}