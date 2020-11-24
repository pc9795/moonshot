using UnityEngine;

namespace GameFiles.Scripts.behaviours
{
    public class Rotator : MonoBehaviour
    {
        public float TurnSenstiivity = 1;
        public float MaxSteerAngle = 30;
        public Transform Stand;

        private float _horizontalInput;
        private bool _deatached;

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            var steerAngle = _horizontalInput * MaxSteerAngle * TurnSenstiivity;
            if (!_deatached)
            {
                transform.RotateAround(Stand.position, Vector3.back, steerAngle);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -steerAngle));
            }
        }

        public void SetTurnSenstivity(float turnSenstivity)
        {
            TurnSenstiivity = turnSenstivity;
        }

        public void Detach()
        {
            _deatached = true;
        }
    }
}