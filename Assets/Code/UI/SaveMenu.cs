using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class SaveMenu : UIElement
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Image _saveImage;
        [SerializeField] private TMP_Text _saveStatusText;
        [SerializeField] private TMP_Text _saveDateText;
        [Space(10f)]
        [SerializeField] private Sprite _defaultSaveImage;

        private bool _gameSaved;
        private string _saveDate;

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

        }

        private void DeleteSave()
        {

        }
    }
}