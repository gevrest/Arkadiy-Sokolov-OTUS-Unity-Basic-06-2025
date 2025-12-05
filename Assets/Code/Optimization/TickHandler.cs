using UnityEngine;

namespace Game
{
    public sealed class TickHandler : MonoBehaviour
    {
        private TickableObject[] _tickableObjects;

        private void Start()
        {
            _tickableObjects = GetComponentsInChildren<TickableObject>();
        }

        private void Update()
        {
            for (int i = 0; i < _tickableObjects.Length; i++)
            {
                _tickableObjects[i].OnTick();
            }
        }
    }
}