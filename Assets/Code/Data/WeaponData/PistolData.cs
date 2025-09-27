using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewPistolData", menuName = "Data/Weapon Data/Pistol", order = 1)]
    public sealed class PistolData : ScriptableObject
    {
        [Serializable]
        public sealed class PistolUpgradeData : UpgradeData
        {
            public int MaxAmmo;
            public int Damage;
        }

        [SerializeField] private PistolUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out PistolUpgradeData upgradeData)
        {
            for (int i = 0; i < _upgradeData.Length; i++)
            {
                if (_upgradeData[i].Level == level)
                {
                    upgradeData = _upgradeData[i];
                    return true;
                }
            }
            upgradeData = _upgradeData[0];
            return false;
        }
    }
}