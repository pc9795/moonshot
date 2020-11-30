using UnityEngine;

namespace GameFiles.Scripts.managers
{
    public class CameraManager : MonoBehaviour
    {
        public Transform ToFollow;
        public Vector2 Offset;

        private void Update()
        {
            transform.position = new Vector3(ToFollow.position.x + Offset.x, ToFollow.position.y + Offset.y,
                transform.position.z);
        }
    }
}