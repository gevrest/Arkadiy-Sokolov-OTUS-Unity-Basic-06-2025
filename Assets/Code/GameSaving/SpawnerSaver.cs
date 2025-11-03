using UnityEngine;

namespace Game
{
    public class SpawnerSaver : MonoBehaviour
    {
        private EnemySpawner[] _enemySpawners;
        private SpawnerSaveData[] _spawnerSaveDatas;

        private void Awake()
        {
            _enemySpawners = GetComponentsInChildren<EnemySpawner>();
            SetSpawnerData();
        }

        private void GetSpawnerData()
        {
            _spawnerSaveDatas = new SpawnerSaveData[_enemySpawners.Length];
            for (int i = 0; i < _enemySpawners.Length; i++)
            {
                _enemySpawners[i].GetSaveData(out _spawnerSaveDatas[i]);
            }
        }

        private void SetSpawnerData()
        {
            if (_spawnerSaveDatas == null)
                return;

            if (_spawnerSaveDatas.Length == _enemySpawners.Length)
            {
                for (int i = 0; i < _enemySpawners.Length; i++)
                {
                    _enemySpawners[i].SetSaveData(_spawnerSaveDatas[i]);
                }
            }
        }

        public void GetSaveData(out SpawnerSaveData[] spawnerSaveDatas)
        {
            GetSpawnerData();
            spawnerSaveDatas = _spawnerSaveDatas;
        }

        public void SetSaveData(SpawnerSaveData[] spawnerSaveDatas)
        {
            _spawnerSaveDatas = spawnerSaveDatas;
        }
    }
}