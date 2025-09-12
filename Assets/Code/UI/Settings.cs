using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class Settings : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void ToggleSettings()
        {
            if (!_isOpened)
            {
                Open();
                _isOpened = true;
            }
            else
            {
                Close();
                _isOpened = false;
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}