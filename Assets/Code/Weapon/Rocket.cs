using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class Rocket : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public bool IsActive { get; set; }

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
            IsActive = false;
        }

        public void Run(Vector3 path, Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            IsActive=true;
        }
    }
}