using UnityEngine;

namespace Game
{
    [RequireComponent (typeof (Rigidbody))]
    public sealed class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;
        private AudioController _audioController;
        private Vector2 _direction;
        private Vector2 _startPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _audioController = GetComponentInParent<AudioController>();
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _direction == Vector2.zero)
            {
                Launch();
            }
        }

        public void Reset()
        {
            _rigidbody.position = _startPosition;
            SetVelocity(Vector2.zero);
        }

        private void Launch()
        {
            float x = Random.Range(-1, 1);
            SetVelocity(new Vector2(x, 1).normalized);
        }

        private void SetVelocity(Vector2 direction)
        {
            _direction = direction;
            _rigidbody.velocity = _direction * _speed;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Paddle paddle))
            {
                float deltaX = transform.position.x - other.transform.position.x;
                float ratio = deltaX / other.collider.bounds.size.x;
                SetVelocity(new Vector2(ratio, 1).normalized);
                _audioController.PlayCollisionSound();
            }
        }
    }
}