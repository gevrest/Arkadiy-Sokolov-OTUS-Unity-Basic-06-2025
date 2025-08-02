using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5.0f;
        [SerializeField] private float _sprintSpeed = 10.0f;
        [SerializeField] private float _jumpForce = 0.01f;
        [SerializeField] private float _gravity = -9.81f;

        private Vector3 _velocity;
        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDirection *= (Input.GetKey(KeyCode.LeftShift) ? _sprintSpeed : _moveSpeed);

            _controller.Move(moveDirection * Time.deltaTime);
            _controller.Move(_velocity * Time.deltaTime);

            _velocity.y += _gravity * Time.deltaTime;

            if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
            }
        }
    }
}