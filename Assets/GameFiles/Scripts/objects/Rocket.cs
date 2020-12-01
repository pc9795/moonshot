using GameFiles.Scripts.animations;
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
        public float GravityScale = 0.5f;
        public float RestBoostsMultiplier = 1.3f;

        private Rigidbody2D _rigidbody;
        private bool _launched;
        private RocketManager _rocketManager;
        private BulletShooter _bulletShooter;
        private PayloadDropper _payloadDropper;
        private Rotator _rotator;
        private GuiManager _guiManager;
        private RocketFireAnimations _rocketFireAnimations;
        private RocketBodyAnimations _rocketBodyAnimations;
        private bool _firstBoost = true;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _rigidbody.gravityScale = GravityScale;
            _rocketManager = GetComponent<RocketManager>();
            _bulletShooter = GetComponent<BulletShooter>();
            _payloadDropper = GetComponent<PayloadDropper>();
            _rotator = GetComponent<Rotator>();
            _guiManager = FindObjectOfType<GuiManager>();
            _rocketFireAnimations = GetComponentInChildren<RocketFireAnimations>();
            _rocketBodyAnimations = GetComponentInChildren<RocketBodyAnimations>();
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            if (!_rocketManager.IsAlive())
            {
                return;
            }

            if (!_launched && Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.Instance.Play(AudioTrack.Launch);
                _launched = true;
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.AddForce(transform.up * LaunchThurst);
                _rotator.Detach();
                _rotator.SetTurnSenstivity(TurnSenstivityAtLaunch);
                _rocketFireAnimations.LaunchFireAnimation();
                return;
            }

            if (_launched)
            {
                if (Input.GetKeyDown(KeyCode.Space) && _rocketManager.CanBoost())
                {
                    AudioManager.Instance.Play(AudioTrack.UseBoost);
                    _rocketManager.UseBoost();
                    _rigidbody.AddForce(transform.up * BoostThrust * (_firstBoost ? 1f : RestBoostsMultiplier));
                    _rocketFireAnimations.LaunchFireAnimation();
                    _firstBoost = false;
                }
                if (Input.GetKeyDown(KeyCode.E) && _rocketManager.CanShoot())
                {
                    AudioManager.Instance.Play(AudioTrack.UseBullet);
                    _rocketManager.UseBullet();
                    _bulletShooter.Shoot();
                }

                if (Input.GetKeyDown(KeyCode.Q) && _rocketManager.CanDropPaylod())
                {
                    AudioManager.Instance.Play(AudioTrack.UseDropShip);
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
                Die();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Have to check IsAlive as it could be case while we are playing blast animation and we reach moon.
            if (other.CompareTag(Tag.Moon) && _rocketManager.IsAlive())
            {
                AudioManager.Instance.Play(AudioTrack.ReachMoon);
                _guiManager.NavigateTo(GuiScreen.LevelComplete);
                GameManager.Pause();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var breakableAsteroid = other.collider.GetComponent<BreakableAsteroid>();
            if (breakableAsteroid != null && !breakableAsteroid.IsBlasting())
            {
                Die();
            }
        }

        private void Die()
        {
            AudioManager.Instance.Play(AudioTrack.RocketBlast);
            _rocketBodyAnimations.BlastAnimation();
            _rocketManager.Die();
        }

        public void LoseLevel()
        {
            if (LevelManager.Instance.DevMode)
            {
                GameManager.RestartCurrLevel();
            }
            else
            {
                _guiManager.NavigateTo(GuiScreen.GameOver);
            }
        }

        public bool IsLaunched()
        {
            return _launched;
        }
    }
}