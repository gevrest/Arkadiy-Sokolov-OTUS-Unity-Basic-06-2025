using System;

namespace Game
{
    [Serializable]
    public sealed class SpawnerSaveData
    {
        public int EnemyCount;
        public SerializableVector3[] EnemyPosition;
        public SerializableVector3[] EnemyDefaultPosition;

        public SpawnerSaveData(int enemies)
        {
            EnemyPosition = new SerializableVector3[enemies];
            EnemyDefaultPosition = new SerializableVector3[enemies];
        }
    }
}