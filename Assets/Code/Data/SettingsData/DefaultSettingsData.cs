using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewDefaultSettingsData", menuName = "Data/Settings/Default Settings Data", order = 0)]
    public sealed class DefaultSettingsData : ScriptableObject
    {
        [Range(0, 5)] public int QualityLevel = 4;
        public bool Fullscreen = true;
    }
}