using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private TrailRenderer _trailRenderer;
        private ParticleSystem _particleSystem;
        private ParticleSystem.EmissionModule _emission;
        private Camera _camera;
        private string _swordName;
        private float _cooldown;

        private Vector2 _mousePosition;
        private Vector2 _lastMousePosition;


        public void Configure(TrailRenderer trailRenderer, string swordName)
        {
            _swordName = swordName;
            _camera = Camera.main;
            if (_trailRenderer == trailRenderer )
            {
                return;
            }
            if (_trailRenderer != null)
            {
                Destroy(_trailRenderer.gameObject);
            }
            _trailRenderer = Instantiate(trailRenderer);
            _particleSystem = _trailRenderer.GetComponent<ParticleSystem>();
            _emission = _particleSystem.emission;
        }

        private void Update()
        {
            _cooldown += Time.deltaTime;
        }


        public void TouchFollow2()
        {
            if(Input.touchCount >= 1)
            {
                Touch touch = Input.GetTouch(0);
                _mousePosition = _camera.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    _trailRenderer.gameObject.transform.position = _mousePosition;
                    float distance = Vector2.Distance(_mousePosition, _lastMousePosition);
                    if (distance > .3f && _cooldown > .8)
                    {
                        ServiceLocator.Instance.GetService<AudioManager>().PlaySword(_swordName);
                        _cooldown = Random.Range(0f, 0.5f);
                    }
                    _lastMousePosition = _mousePosition;
                    if (!_emission.enabled)
                    {
                        _emission.enabled = true;
                        _trailRenderer.emitting = true;
                    }
                }
                else
                {
                    if(_emission.enabled)
                    {
                        _emission.enabled = false;
                        _trailRenderer.emitting = false;
                    }
                }
            }
        }
    }
}