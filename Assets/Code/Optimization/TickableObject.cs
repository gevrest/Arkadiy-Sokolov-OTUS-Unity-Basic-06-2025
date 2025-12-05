using UnityEngine;

namespace Game
{
    public abstract class TickableObject : MonoBehaviour
    {
        public abstract void OnTick();
    }
}