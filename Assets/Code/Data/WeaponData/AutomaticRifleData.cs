using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewAutomaticRifleData", menuName = "Data/Weapon Data/Automatic Rifle", order = 0)]
    public sealed class AutomaticRifleData : ScriptableObject
    {
        [Serializable]
        public sealed class ARUpgradeData : UpgradeData
        {
            public int MaxAmmo;
            public int Damage;
            public float ShootDelay;
        }

        [SerializeField] private ARUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out ARUpgradeData upgradeData)
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