using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class BreakableAsteroid : MonoBehaviour
    {
        public void Blast()
        {
            Destroy(gameObject);
        }
    }
}