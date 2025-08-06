using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 2.0f;
        [SerializeField] private float _maxYAngle = 80.0f;

        private float _rotationX = 0.0f;

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

            _rotationX -= mouseY * _sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        }
    }
}