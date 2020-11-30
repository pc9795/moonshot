using GameFiles.Scripts.managers;
using GameFiles.Scripts.objects;
using UnityEngine;

namespace GameFiles.Scripts.behaviours
{
    public class BulletShooter : MonoBehaviour
    {
        public Bullet Bullet;
        public Vector2 BulletOffSet;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Shoot()
        {
            Bullet bulletInstance = Instantiate(Bullet,
                _rigidbody2D.transform.position + new Vector3(BulletOffSet.x * _rigidbody2D.transform.up.x,
                    BulletOffSet.y * _rigidbody2D.transform.up.y, 0f),
                _rigidbody2D.transform.rotation);
            bulletInstance.SetDirection(_rigidbody2D.transform.up);
            Destroy(bulletInstance, ConfigManager.Instance.BulletDuration);
        }
    }
}