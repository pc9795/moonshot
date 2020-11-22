using UnityEngine;

namespace GameFiles.Scripts
{
    public class BreakableAsteroid : MonoBehaviour
    {
        public void Blast()
        {
            Destroy(gameObject);
        }
    }
}