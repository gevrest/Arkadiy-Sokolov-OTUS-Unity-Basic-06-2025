using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class Settings : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _saveButton.onClick.AddListener(Save);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
            _saveButton.onClick.RemoveListener(Save);
        }

        public void ToggleSettings()
        {
            if (!_isOpened)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _isOpened = true;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _isOpened = false;
        }

        private void Save()
        {

        }
    }
}