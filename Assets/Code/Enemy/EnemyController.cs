using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    [RequireComponent (typeof (NavMeshAgent))]
    public sealed class EnemyController : TickableObject
    {
        [SerializeField] private int _patrolRadius = 10;
        [Space(10f)]
        [SerializeField] private float _defaultSpeed = 3f;
        [SerializeField] private float _chaseSpeed = 5f;
        [Space(10f)]
        [SerializeField] private int _maxStopTime = 15;
        [SerializeField] private int _minStopTime = 5;
        [Space(10f)]
        [SerializeField] private NavMeshAgent _enemy;
        [SerializeField] private EnemyResponseTrigger _responseTrigger;

        public Vector3 DefaultPosition;

        private GameObject _player;
        private Vector3 _currentTarget;

        private void Start()
        {
            _player = GameObject.Find("Player");
            DefaultPosition = gameObject.transform.position;
            StartCoroutine(EnemyRoutine());
        }

        public override void OnTick()
        {
            if (_responseTrigger.PlayerDetected || _responseTrigger.EnemyAttacked)
            {
                _enemy.destination = _player.transform.position;
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
                _currentTarget = new Vector3(DefaultPosition.x + Random.Range(-_patrolRadius, _patrolRadius), transform.position.y, DefaultPosition.z + Random.Range(-_patrolRadius, _patrolRadius));
                int currentStopTime = Random.Range(_minStopTime, _maxStopTime);

                yield return new WaitForSeconds(currentStopTime);
                _enemy.destination = _currentTarget;
                yield return new WaitForSeconds(currentStopTime);
                _enemy.destination = DefaultPosition;
            }
        }
    }
}