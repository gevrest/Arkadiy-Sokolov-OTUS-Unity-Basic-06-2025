using UnityEngine;

namespace Game
{
    [RequireComponent (typeof (Rigidbody))]
    public sealed class Paddle : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _axis;
        private Vector3 _velocity;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            _axis = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            _velocity = Vector3.right * _axis * _speed * Time.fixedDeltaTime;
            transform.Translate(_velocity);
        }

        public void Reset()
        {
            _velocity = Vector3.zero;
            transform.position = _startPosition;
        }
    }
}