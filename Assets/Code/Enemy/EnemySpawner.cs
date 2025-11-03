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
        private SpawnerSaveData _saveData;
        private EnemyController[] _enemies;

        private void Start()
        {
            LoadEnemies();
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

        private void GetEnemyData()
        {
            _enemies = GetComponentsInChildren<EnemyController>();
            _saveData = new SpawnerSaveData(_enemies.Length);
            _saveData.EnemyCount = _enemyCount;
            for (int i = 0; i < _enemies.Length; i++)
            {
                _saveData.EnemyPosition[i] = _enemies[i].transform.position;
                _saveData.EnemyDefaultPosition[i] = _enemies[i].DefaultPosition;
            }
        }

        private void LoadEnemies()
        {
            if (_saveData != null)
            {
                _enemyCount = _saveData.EnemyCount;
                for (int i = 0; i < _saveData.EnemyCount; i++)
                {
                    Vector3 spawnPoint = (Vector3)_saveData.EnemyPosition[i];
                    var enemy = Instantiate(_enemyPrefab, spawnPoint, _spawner.rotation, _spawner);
                    enemy.GetComponent<EnemyController>().DefaultPosition = (Vector3)_saveData.EnemyDefaultPosition[i];
                    enemy.name = $"Enemy [{i + 1}]";
                }
            }
        }

        public void GetSaveData(out SpawnerSaveData saveData)
        {
            GetEnemyData();
            saveData = _saveData;
        }

        public void SetSaveData(SpawnerSaveData saveData)
        {
            _saveData = saveData;
        }
    }
}