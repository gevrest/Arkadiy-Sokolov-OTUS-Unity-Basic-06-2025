using UnityEngine;

namespace Game
{
    public sealed class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private PauseMenu _pauseMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseMenu.TogglePause();
            }
        }
    }
}