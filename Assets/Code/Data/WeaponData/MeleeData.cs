using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewMeleeData", menuName = "Data/Weapon Data/Melee", order = 2)]
    public sealed class MeleeData : ScriptableObject
    {
        [Serializable]
        public sealed class MeleeUpgradeData : UpgradeData
        {
            public int Damage;
            public float AttackDistance;
            public float AttackCooldown;
        }

        [SerializeField] private MeleeUpgradeData[] _upgradeData;

        public bool TryGetDataByLevel(int level, out MeleeUpgradeData upgradeData)
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