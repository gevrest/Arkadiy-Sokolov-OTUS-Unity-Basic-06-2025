using System.Collections;
using UnityEngine;

namespace Game
{
    public sealed class Rocket : MonoBehaviour
    {
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionForce;
        [SerializeField] private int _damage;

        private Rigidbody _rigidbody;
        private MeshRenderer _renderer;
        private CapsuleCollider _collider;
        private RocketAudioSource _audioSource;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<MeshRenderer>();
            _collider = GetComponent<CapsuleCollider>();
            _audioSource = GetComponent<RocketAudioSource>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds (10.0f);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            var explosion = gameObject.AddComponent<Explosion>();
            explosion.Detonate(transform.position, _explosionRadius, _explosionForce, _damage);
            Disable();
            _audioSource.PlayExplosionSound();
        }

        public void Strike(Vector3 path, Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            transform.SetParent(null);
        }

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
        }

        private void Disable()
        {
            Destroy(_rigidbody);
            Destroy(_renderer);
            Destroy(_collider);
        }
    }
}