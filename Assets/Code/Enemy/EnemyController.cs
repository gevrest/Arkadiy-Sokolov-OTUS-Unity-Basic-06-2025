using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    [RequireComponent (typeof (NavMeshAgent))]
    public sealed class EnemyController : MonoBehaviour
    {
        [SerializeField] private int _maxPatrolRadius = 10;
        [Space(10f)]
        [SerializeField] private float _defaultSpeed = 3f;
        [SerializeField] private float _chaseSpeed = 5f;
        [Space(10f)]
        [SerializeField] private int _maxStopTime = 15;
        [SerializeField] private int _minStopTime = 5;
        [Space(10f)]
        [SerializeField] private NavMeshAgent _enemy;
        [SerializeField] private EnemyResponseTrigger _responseTrigger;

        private Vector3 _defaultPosition;
        private Vector3 _currentTarget;

        private void Start()
        {
            _defaultPosition = gameObject.transform.position;
            StartCoroutine(EnemyRoutine());
        }

        private void Update()
        {
            if (_responseTrigger.PlayerDetected || _responseTrigger.EnemyAttacked)
            {
                _enemy.speed = _chaseSpeed;
            }
            else
            {
                _enemy.speed = _defaultSpeed;
            }
        }

        public IEnumerator EnemyRoutine()
        {
            while (true)
            {
                _currentTarget = new Vector3(_defaultPosition.x += Random.Range(-_maxPatrolRadius, _maxPatrolRadius), 0, _defaultPosition.z += Random.Range(-_maxPatrolRadius, _maxPatrolRadius));
                int currentStopTime = Random.Range(_minStopTime, _maxStopTime);
                _enemy.destination = _currentTarget;
                yield return new WaitForSeconds(currentStopTime);
                _enemy.destination = _defaultPosition;
            }
        }
    }
}