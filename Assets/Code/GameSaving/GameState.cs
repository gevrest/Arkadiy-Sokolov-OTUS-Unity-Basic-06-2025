using System;

namespace Game
{
    [Serializable]
    public sealed class GameState
    {
        public string SaveDate;
        public SerializableVector3 PlayerPosition;
        public SpawnerSaveData[] SpawnerSaveData;

        public GameState()
        {
            SpawnerSaveData = new SpawnerSaveData[] { };
        }
    }
}