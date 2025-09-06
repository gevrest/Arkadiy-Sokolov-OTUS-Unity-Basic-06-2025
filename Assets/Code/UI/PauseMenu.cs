using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _quitButton;

        private bool isActive;

        public void ToggleActive()
        {
            if (!isActive)
            {
                gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isActive = true;
            }
            else
            {
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isActive = false;
            }
        }
    }
}