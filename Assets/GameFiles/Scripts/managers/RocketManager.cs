using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.managers
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
        private GuiManager _guiManager;

        private void Start()
        {
            _health = MaxHealth;
            _boosts = new CoolingDownEntity(MaxBoosts);
            _bullets = new CoolingDownEntity(MaxBullets);
            _payloads = new CoolingDownEntity(MaxPayloads);
            _guiManager = FindObjectOfType<GuiManager>();
            _guiManager.UpdateBoostsInHud(_boosts.GetQuantity());
            _guiManager.UpdateDropshipsInHud(_payloads.GetQuantity());
            _guiManager.UpdateBulletsInHud(_bullets.GetQuantity());
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
            _guiManager.ToogleBoostsInHud(false);
            Invoke(nameof(StopBoostCoolDown), BoostCoolDownInSecs);
        }

        private void StopBoostCoolDown()
        {
            _boosts.StopCoolDown();
            _guiManager.UpdateBoostsInHud(_boosts.GetQuantity());
            _guiManager.ToogleBoostsInHud(true);
        }

        public bool CanShoot()
        {
            return _bullets.CanUse();
        }

        public void UseBullet()
        {
            _bullets.Use();
            _guiManager.ToogleBulletsInHud(false);
            Invoke(nameof(StopBulletCoolDown), BulletCoolDownInSecs);
        }

        private void StopBulletCoolDown()
        {
            _bullets.StopCoolDown();
            _guiManager.UpdateBulletsInHud(_bullets.GetQuantity());
            _guiManager.ToogleBulletsInHud(true);
        }

        public bool CanDropPaylod()
        {
            return _payloads.CanUse();
        }

        public void UsePayload()
        {
            _payloads.Use();
            _guiManager.ToogleDropshipsInHud(false);
            Invoke(nameof(StopPayloadCoolDown), PayloadCoolDownInSecs);
        }

        private void StopPayloadCoolDown()
        {
            _payloads.StopCoolDown();
            _guiManager.UpdateDropshipsInHud(_payloads.GetQuantity());
            _guiManager.ToogleDropshipsInHud(true);
        }
    }
}