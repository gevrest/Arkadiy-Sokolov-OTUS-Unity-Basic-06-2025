using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    [RequireComponent (typeof (SphereCollider))]
    public sealed class EnemyResponseTrigger : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _enemy;
        [SerializeField] private float _attackResponseTime = 5f;

        private GameObject _player;

        public bool PlayerDetected { get; private set; }
        public bool EnemyAttacked { get; private set; }

        private void Start()
        {
            _player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (PlayerDetected || EnemyAttacked)
            {
                _enemy.destination = _player.transform.position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerDetected = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerDetected = false;
            }
        }

        public IEnumerator EnemyAttackedResponce()
        {
            EnemyAttacked = true;
            yield return new WaitForSeconds(_attackResponseTime);
            EnemyAttacked = false;
        }
    }
}