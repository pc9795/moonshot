using UnityEngine;

namespace GameFiles.Scripts
{
    public class StatsManager : MonoBehaviour
    {
        public float MaxHealth = 100;
        public int MaxBoosts = 3;
        public int BoostCoolDownInSecs = 2;

        private float _health;
        private int _boosts;
        private bool _boostCoolingDown;

        private void Awake()
        {
            _health = MaxHealth;
            _boosts = MaxBoosts;
        }

        public void Die()
        {
            _health = 0;
        }

        public bool IsAlive()
        {
            return (int) _health != 0;
        }

        public bool CanBoost()
        {
            return _boosts != 0 && !_boostCoolingDown;
        }

        public void UseBoost()
        {
            _boosts--;
            _boostCoolingDown = true;
            Invoke(nameof(StopCoolDown), BoostCoolDownInSecs);
        }

        private void StopCoolDown()
        {
            _boostCoolingDown = false;
        }
    }
}