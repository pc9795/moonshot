using GameFiles.Scripts.managers;
using GameFiles.Scripts.objects;
using UnityEngine;

namespace GameFiles.Scripts.behaviours
{
    public class BulletShooter : MonoBehaviour
    {
        public Bullet Bullet;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Shoot()
        {
            Bullet bulletInstance = Instantiate(Bullet, _rigidbody2D.transform.position, Quaternion.identity);
            bulletInstance.SetDirection(_rigidbody2D.transform.up);
            Destroy(bulletInstance, ConfigManager.Instance.BulletDuration);
        }
    }
}