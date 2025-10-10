using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent (typeof (SphereCollider))]
    public sealed class EnemyResponseTrigger : MonoBehaviour
    {
        [SerializeField] private float _chaseTime = 5f;

        public bool PlayerDetected { get; private set; }
        public bool EnemyAttacked { get; private set; }

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
            yield return new WaitForSeconds(_chaseTime);
            EnemyAttacked = false;
        }
    }
}