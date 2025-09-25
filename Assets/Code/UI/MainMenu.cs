using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [Space(10f)]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(LaunchGame);
            _settingsButton.onClick.AddListener(OpenSettings);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(LaunchGame);
            _settingsButton.onClick.RemoveListener(OpenSettings);
            _quitButton.onClick.RemoveListener(QuitGame);
        }

        private void LaunchGame()
        {
            SceneManager.LoadScene("Game");
        }

        private void OpenSettings()
        {
            _settings.ToggleSettings();
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}