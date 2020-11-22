using UnityEngine;

namespace GameFiles.Scripts
{
    public class CameraManager : MonoBehaviour
    {
        public Transform ToFollow;

        private void Update()
        {
            transform.position = new Vector3(ToFollow.position.x, ToFollow.position.y, transform.position.z);
        }
    }
}