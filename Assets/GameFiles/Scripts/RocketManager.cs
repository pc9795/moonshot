using GameFiles.Scripts.beans;
using UnityEngine;

namespace GameFiles.Scripts
{
    public class RocketManager : MonoBehaviour
    {
        public float MaxHealth = 100;
        public int MaxBoosts = 3;
        public int MaxBullets = 10;
        public int MaxPayloads = 3;
        public float BoostCoolDownInSecs = 1;
        public float BulletCoolDownInSecs = 1;
        public float PayloadCoolDownInSecs = 1;


        private float _health;
        private CoolingDownEntity _boosts;
        private CoolingDownEntity _bullets;
        private CoolingDownEntity _payloads;

        private void Awake()
        {
            _health = MaxHealth;
            _boosts = new CoolingDownEntity(MaxBoosts);
            _bullets = new CoolingDownEntity(MaxBullets);
            _payloads = new CoolingDownEntity(MaxPayloads);
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
            return _boosts.CanUse();
        }

        public void UseBoost()
        {
            _boosts.Use();
            Invoke(nameof(StopBoostCoolDown), BoostCoolDownInSecs);
        }

        private void StopBoostCoolDown()
        {
            _boosts.StopCoolDown();
        }

        public bool CanShoot()
        {
            return _bullets.CanUse();
        }

        public void UseBullet()
        {
            _bullets.Use();
            Invoke(nameof(StopBulletCoolDown), BulletCoolDownInSecs);
        }

        private void StopBulletCoolDown()
        {
            _bullets.StopCoolDown();
        }

        public bool CanDropPaylod()
        {
            return _payloads.CanUse();
        }

        public void UsePayload()
        {
            _payloads.Use();
            Invoke(nameof(StopPayloadCoolDown), PayloadCoolDownInSecs);
        }

        private void StopPayloadCoolDown()
        {
            _payloads.StopCoolDown();
        }
    }
}