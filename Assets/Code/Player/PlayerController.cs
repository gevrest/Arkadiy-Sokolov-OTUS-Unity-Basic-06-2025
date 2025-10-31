using UnityEngine;

namespace Game
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5.0f;
        [SerializeField] private float _sprintSpeed = 10.0f;
        [SerializeField] private float _swimSpeed = 6.0f;

        [SerializeField] private float _jumpForce = 0.5f;
        [SerializeField] private float _floatUpForce = 1.5f;
        [SerializeField] private float _gravity = -9.81f;

        private Vector3 _velocity;
        private Vector3 _oldPosition;
        private CharacterController _controller;

        public bool isSprinting { get; private set; }
        public bool isGrounded { get; private set; }
        public bool isMoving { get; private set; }
        public bool isSwiming { get; set; }

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _oldPosition = transform.position;
        }

        private void Update()
        {
            if (Time.timeScale == 0f)
            {
                return;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                FloatUp();
            }

            if (isSwiming)
            {
                Swim(moveDirection);
            }
            else
            {
                _velocity.y += _gravity * Time.deltaTime;
                Move(moveDirection);
            }

            isGrounded = _controller.isGrounded;
            isMoving = _oldPosition != transform.position;

            _oldPosition = transform.position;            
        }

        private void Move(Vector3 direction)
        {
            if (isSprinting)
            {
                direction *= _sprintSpeed;
            }
            else
            {
                direction *= _moveSpeed;
            }
            _controller.Move(direction * Time.deltaTime);
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void Swim(Vector3 direction)
        {
            direction *= _swimSpeed;

            _controller.Move(direction * Time.deltaTime);
            _controller.Move(Vector3.down * Time.deltaTime);
        }

        private void Jump()
        {
            if (isGrounded && !isSwiming)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * _gravity * -2);
            }
        }

        private void FloatUp()
        {
            if (isSwiming)
            {
                _controller.Move(Vector3.up * _floatUpForce * Time.deltaTime);
            }
        }
    }
}