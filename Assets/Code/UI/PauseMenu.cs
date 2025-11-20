using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private SaveMenu _saveMenu;
        [Space(10)]
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _quitButton;

        private bool isPaused;

        private void OnEnable()
        {
            _settingsButton.onClick.AddListener(OpenSettings);
            _saveButton.onClick.AddListener(OpenSaveMenu);
            _resumeButton.onClick.AddListener(ResumeGame);
            _menuButton.onClick.AddListener(BackToMenu);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _saveButton.onClick.RemoveListener(OpenSaveMenu);
            _resumeButton.onClick.RemoveListener(ResumeGame);
            _menuButton.onClick.RemoveListener(BackToMenu);
            _quitButton.onClick.RemoveListener(QuitGame);
        }

        public void Toggle()
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        private void CloseAllTabs()
        {
            _settings.Close();
            _saveMenu.Close();
        }

        private void OpenSettings()
        {
            CloseAllTabs();
            _settings.Open();
        }

        private void OpenSaveMenu()
        {
            CloseAllTabs();
            _saveMenu.Open();
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
            ResumeGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}