using System.Collections;
using UnityEngine;

namespace Game
{
    public class SceneCapture : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private RenderTexture _renderTexture;
        [Header("Ignored Objects")]
        [SerializeField] private Canvas _playerInterface;

        private Texture2D _texture;

        private void Start()
        {
            float width = Screen.width;
            float height = Screen.height;
            _texture = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
        }

        public void TakePicture(out Texture2D image)
        {
            StartCoroutine(Shot());
            image = _texture;
        }

        public void TakeAndSavePicture(string path, out Texture2D image)
        {
            StartCoroutine(ShotAndSave(path));
            image = _texture;
        }

        private IEnumerator Shot()
        {
            Rect rect = new Rect(0, 0, _texture.width, _texture.height);
            DisableIgnoredObjects(true);
            yield return new WaitForEndOfFrame();
            _camera.Render();
            _texture.ReadPixels(rect, 0, 0);
            _texture.Apply();
            yield return new WaitForEndOfFrame();
            DisableIgnoredObjects(false);
        }

        private IEnumerator ShotAndSave(string path)
        {
            Rect rect = new Rect(0, 0, _texture.width, _texture.height);
            DisableIgnoredObjects(true);
            yield return new WaitForEndOfFrame();
            _camera.Render();
            _texture.ReadPixels(rect, 0, 0);
            _texture.Apply();
            yield return new WaitForEndOfFrame();
            DisableIgnoredObjects(false);
            ImageSaver.SaveImage(path, _texture);
        }

        private void DisableIgnoredObjects(bool isDisabled)
        {
            _playerInterface.gameObject.SetActive(!isDisabled);
        }
    }
}