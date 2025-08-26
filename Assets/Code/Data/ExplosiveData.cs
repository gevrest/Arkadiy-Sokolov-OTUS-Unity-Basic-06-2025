using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewExplosiveData", menuName = "Data/Weapon Data/Explosive", order = 3)]
    public sealed class ExplosiveData : ScriptableObject
    {
        [Serializable]
        public sealed class ExplosiveUpgradeData : UpgradeData
        {
            public float Force;
        }

        [SerializeField] private ExplosiveUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out ExplosiveUpgradeData upgradeData)
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