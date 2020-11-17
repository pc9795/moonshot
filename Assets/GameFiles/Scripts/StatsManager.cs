using UnityEngine;

namespace GameFiles.Scripts
{
    public class StatsManager : MonoBehaviour
    {
        public float MaxHealth = 100;

        private float _health;

        private void Awake()
        {
            _health = MaxHealth;
        }

        public void Die()
        {
            _health = 0;
        }

        public bool IsAlive()
        {
            return (int)_health != 0;
        }
    }
}