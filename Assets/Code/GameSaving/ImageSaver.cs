using System.IO;
using UnityEngine;

namespace Game
{
    public static class ImageSaver
    {
        public static void SaveImage(string path, Texture2D image)
        {
            if (path != null && image != null)
            {
                byte[] bytes = image.EncodeToPNG();
                File.WriteAllBytes(path, bytes);
            }
        }

        public static void LoadImage(string path, out Texture2D image)
        {
            byte[] bytes = File.ReadAllBytes(path);
            if (bytes != null)
            {
                image = new Texture2D(Screen.width, Screen.height);
                image.LoadImage(bytes);
                image.Apply();
            }
            else
            {
                image = null;
            }
        }

        public static void DeleteImage(string path)
        {
            File.Delete(path);
        }
    }
}