using UnityEngine;

namespace Game
{
    public sealed class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private DebugScreen _debugScreen;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseMenu.Toggle();
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                _debugScreen.Toggle();
            }
        }
    }
}