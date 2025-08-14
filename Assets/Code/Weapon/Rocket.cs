using UnityEngine;

namespace Game
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] private float _explosionRadius;
        [SerializeField] private int _damage;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public bool IsActive { get; set; }

        public void Strike(Vector3 path, Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path, ForceMode.Acceleration);
            transform.SetParent(null);
        }

        public void Sleep(Transform parent)
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
        }
    }
}