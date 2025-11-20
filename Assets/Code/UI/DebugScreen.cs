using TMPro;
using UnityEngine;

namespace Game
{
    public class DebugScreen : UIElement
    {
        [SerializeField] TMP_Text _fpsText;
        [SerializeField] TMP_Text _maxFpsText;
        [SerializeField] TMP_Text _minFpsText;
        [SerializeField] TMP_Text _screenText;

        private int _fps = 0;
        private int _maxFps = 0;
        private int _minFps = int.MaxValue;
        private int _frameGap = 0;

        private bool _isOpened = false;

        private void Update()
        {
            _fps = (int)(1 / Time.unscaledDeltaTime);
            _frameGap = (int)(Time.unscaledDeltaTime * 1000);
            _fpsText.text = $" fps: {_fps} [{_frameGap} ms]";

            _maxFps = _fps > _maxFps ? _fps : _maxFps;
            _minFps = _fps < _minFps ? _fps : _minFps;
            _maxFpsText.text = $" max fps: {_maxFps}";
            _minFpsText.text = $" min fps: {_minFps}";

            int width = Screen.width;
            int height = Screen.height;
            _screenText.text = $" screen: {width}x{height}";
        }

        public void Toggle()
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
    }
}