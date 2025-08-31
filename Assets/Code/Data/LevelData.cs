using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewLevelData", menuName = "Data/Level Data")]
    public sealed class LevelData : ScriptableObject
    {
        [Serializable]
        public sealed class LineData
        {
            public int _bricksQuantity;
            public Color _color;
        }

        [SerializeField] private LineData[] _lineData;

        public void GetDataByLines(out LineData[] lineData)
        {
            lineData = _lineData;
        }
    }
}