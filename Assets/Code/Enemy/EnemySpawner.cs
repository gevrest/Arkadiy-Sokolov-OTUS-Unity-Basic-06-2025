using System.Collections;
using UnityEngine;

namespace Game
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int _spawnRadius = 10;
        [SerializeField] private int _maxEnemyCount = 3;
        [Space(10f)]
        [SerializeField] private int _maxSpawnCooldown = 15;
        [SerializeField] private int _minSpawnCooldown = 5;
        [Space(10f)]
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _spawner;

        private int _enemyCount = 0;
        private Vector3 _currentSpawnPoint;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                _currentSpawnPoint = new Vector3(_spawner.position.x + Random.Range(-_spawnRadius, _spawnRadius), _spawner.position.y, _spawner.position.z + Random.Range(-_spawnRadius, _spawnRadius));
                int currentSpawnCooldown = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);

                if (_enemyCount < _maxEnemyCount)
                {
                    Spawn();
                }
                yield return new WaitForSeconds(currentSpawnCooldown);
            }
        }

        private void Spawn()
        {
            var enemy = Instantiate(_enemyPrefab, _currentSpawnPoint, _spawner.rotation, _spawner);
            _enemyCount++;
            enemy.name = $"Enemy [{_enemyCount}]";
        }

        public void DecreaseEnemy()
        {
            _enemyCount = Mathf.Max(0, _enemyCount -= 1);
        }
    }
}