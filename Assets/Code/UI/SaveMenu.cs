using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public sealed class SaveMenu : UIElement
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private TMP_Text _saveStatusText;
        [SerializeField] private TMP_Text _saveDateText;

        public UnityAction SaveGameEvent;
        public UnityAction DeleteSaveEvent;

        private GameSaver _gameSaver;
        private GameState _gameState;
        private string _saveStatus;
        private string _saveDate;

        private void Awake()
        {
            _gameSaver = GameObject.Find("SaveSystem").GetComponent<GameSaver>();
        }

        private void Start()
        {
            UpdateSaveInformation();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _saveButton.onClick.AddListener(SaveGame);
            _deleteButton.onClick.AddListener(DeleteSave);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
            _saveButton.onClick.RemoveListener(SaveGame);
            _deleteButton.onClick.RemoveListener(DeleteSave);
        }

        private void GetSaveInformation()
        {
            _gameSaver.GetSavedData(out _gameState);
            if (_gameState != null)
            {
                _saveStatus = "Game saved";
                _saveDate = _gameState.SaveDate;
            }
            else
            {
                _saveStatus = "Game not saved";
                _saveDate = string.Empty;
            }
        }

        private void UpdateSaveInformation()
        {
            GetSaveInformation();
            _saveStatusText.text = _saveStatus;
            _saveDateText.text = _saveDate;
        }

        private void SaveGame()
        {
            SaveGameEvent.Invoke();
            UpdateSaveInformation();
        }

        private void DeleteSave()
        {
            DeleteSaveEvent.Invoke();
            UpdateSaveInformation();
        }
    }
}