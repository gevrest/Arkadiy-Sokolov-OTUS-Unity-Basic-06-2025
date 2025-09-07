using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _quitButton;

        private bool isPaused;

        private void OnEnable()
        {
            _settingsButton.onClick.AddListener(OpenSettings);
            _resumeButton.onClick.AddListener(ResumeGame);
            _menuButton.onClick.AddListener(BackToMenu);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _resumeButton.onClick.RemoveListener(ResumeGame);
            _menuButton.onClick.RemoveListener(BackToMenu);
            _quitButton.onClick.RemoveListener(QuitGame);
        }

        public void TogglePause()
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

        private void OpenSettings()
        {

        }

        private void BackToMenu()
        {

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