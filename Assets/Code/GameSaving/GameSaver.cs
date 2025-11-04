using System;
using UnityEngine;

namespace Game
{
    public sealed class GameSaver : MonoBehaviour
    {
        [SerializeField] private SpawnerSaver _spawnerSaver;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private SaveMenu _saveMenu;

        private GameState _gameState;

        private void Awake()
        {
            LoadGame();
        }

        private void OnEnable()
        {
            _saveMenu.SaveGameEvent += SaveGame;
            _saveMenu.DeleteSaveEvent += DeleteSave;
        }

        private void OnDisable()
        {
            _saveMenu.SaveGameEvent -= SaveGame;
            _saveMenu.DeleteSaveEvent -= DeleteSave;
        }

        private void SaveGame()
        {
            GetData();
            string json = JsonUtility.ToJson(_gameState);
            PlayerPrefs.SetString("GameSave", json);
            PlayerPrefs.Save();
        }

        private void DeleteSave()
        {
            PlayerPrefs.DeleteKey("GameSave");
            PlayerPrefs.Save();
            _gameState = null;
        }

        private void LoadGame()
        {
            if (!PlayerPrefs.HasKey("GameSave"))
                return;
            string json = PlayerPrefs.GetString("GameSave");
            _gameState = JsonUtility.FromJson<GameState>(json);
            _playerController.transform.position = (Vector3)_gameState.PlayerPosition;
            _spawnerSaver.SetSaveData(_gameState.SpawnerSaveData);
        }

        private void GetData()
        {
            _gameState = new GameState();
            _gameState.SaveDate = $"{DateTime.Now.Month} / {DateTime.Now.Day} / {DateTime.Now.Year} [{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}]";
            _gameState.PlayerPosition = _playerController.transform.position;
            _spawnerSaver.GetSaveData(out _gameState.SpawnerSaveData);
        }

        public void GetSavedData(out GameState gameState)
        {
            gameState = _gameState;
        }
    }
}