using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 2.0f;
        [SerializeField] private float _maxAngle = 90.0f;

        private float _rotation;

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

            _rotation -= mouseY * _sensitivity;
            _rotation = Mathf.Clamp(_rotation, -_maxAngle, _maxAngle);
            transform.localRotation = Quaternion.Euler(_rotation, 0.0f, 0.0f);
        }
    }
}