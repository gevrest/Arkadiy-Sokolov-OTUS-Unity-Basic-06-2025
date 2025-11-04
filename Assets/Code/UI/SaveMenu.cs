using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public sealed class SaveMenu : UIElement
    {
        [SerializeField] SceneCapture _sceneCapture;
        [Space(10f)]
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Image _saveImage;
        [SerializeField] private TMP_Text _saveStatusText;
        [SerializeField] private TMP_Text _saveDateText;
        [Space(10f)]
        [SerializeField] private Sprite _notSaveImage;

        public UnityAction SaveGameEvent;
        public UnityAction DeleteSaveEvent;

        private GameSaver _gameSaver;
        private GameState _gameState;
        private Sprite _saveSprite;
        private string _saveStatus;
        private string _saveDate;
        private bool _isSaved;

        private void Awake()
        {
            _gameSaver = GameObject.Find("SaveSystem").GetComponent<GameSaver>();
        }

        private void Start()
        {
            UpdateSaveInformation();
            LoadPicture();
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

        private void SaveGame()
        {
            SaveGameEvent.Invoke();
            UpdateSaveInformation();
            SavePicture();

        }

        private void DeleteSave()
        {
            DeleteSaveEvent.Invoke();
            UpdateSaveInformation();
            DeletePicture();
        }

        private void GetSaveInformation()
        {
            _gameSaver.GetSavedData(out _gameState);
            _isSaved = _gameState != null;

            if (_isSaved)
            {
                _saveStatus = "Game saved";
                _saveDate = _gameState.SaveDate;
                _saveSprite = null;
            }
            else
            {
                _saveStatus = "Game not saved";
                _saveDate = string.Empty;
                _saveSprite = _notSaveImage;
            }
        }

        private void UpdateSaveInformation()
        {
            GetSaveInformation();
            _saveStatusText.text = _saveStatus;
            _saveDateText.text = _saveDate;
            _saveImage.sprite = _saveSprite;
        }

        private void SavePicture()
        {
            _sceneCapture.TakeAndSavePicture(Application.persistentDataPath + "/SaveImage.png", out Texture2D image);
            _saveImage.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

        private void LoadPicture()
        {
            if (_isSaved)
            {
                ImageSaver.LoadImage(Application.persistentDataPath + "/SaveImage.png", out Texture2D image);
                _saveImage.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
        }

        private void DeletePicture()
        {
            ImageSaver.DeleteImage(Application.persistentDataPath + "/SaveImage.png");
        }
    }
}