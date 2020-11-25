using GameFiles.Scripts.behaviours;
using GameFiles.Scripts.managers;
using GameFiles.Scripts.plain.objects;
using UnityEngine;

namespace GameFiles.Scripts.objects
{
    public class Rocket : MonoBehaviour
    {
        public float LaunchThurst = 500;
        public float BoostThrust = 800;
        public float TurnSenstivityAtLaunch = 0.3f;
        public float PayloadDropDownwardThurst = 200;

        private Rigidbody2D _rigidbody;
        private bool _launched;
        private RocketManager _rocketManager;
        private BulletShooter _bulletShooter;
        private PayloadDropper _payloadDropper;
        private Rotator _rotator;
        private GuiManager _guiManager;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _rigidbody.gravityScale = 0.5f; //todo make configurable
            _rocketManager = GetComponent<RocketManager>();
            _bulletShooter = GetComponent<BulletShooter>();
            _payloadDropper = GetComponent<PayloadDropper>();
            _rotator = GetComponent<Rotator>();
            _guiManager = FindObjectOfType<GuiManager>();
        }

        private void Update()
        {
            if (!_rocketManager.IsAlive())
            {
                return;
            }

            if (!_launched && Input.GetKeyDown(KeyCode.Space))
            {
                _launched = true;
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.AddForce(transform.up * LaunchThurst);
                _rotator.Detach();
                _rotator.SetTurnSenstivity(TurnSenstivityAtLaunch);
                return;
            }

            if (_launched)
            {
                if (Input.GetKeyDown(KeyCode.Space) && _rocketManager.CanBoost())
                {
                    _rocketManager.UseBoost();
                    _rigidbody.AddForce(transform.up * BoostThrust);
                }

                if (Input.GetKeyDown(KeyCode.E) && _rocketManager.CanShoot())
                {
                    _rocketManager.UseBullet();
                    _bulletShooter.Shoot();
                }

                if (Input.GetKeyDown(KeyCode.Q) && _rocketManager.CanDropPaylod())
                {
                    _rocketManager.UsePayload();
                    _payloadDropper.Drop();
                    _rigidbody.AddForce(-transform.up * PayloadDropDownwardThurst);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Boundary))
            {
                _rocketManager.Die();
                GameManager.Pause();
                _guiManager.NavigateTo(GuiScreen.GameOver);
                return;
            }

            if (other.CompareTag(Tag.Moon))
            {
                GameManager.Pause();
                GameManager.NextLevel();
            }
        }
    }
}