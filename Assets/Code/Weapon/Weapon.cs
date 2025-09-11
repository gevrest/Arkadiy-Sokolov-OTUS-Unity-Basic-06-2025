using UnityEngine;

namespace Game
{
    public abstract class Weapon : MonoBehaviour
    {
        public int Ammo { get; protected set; }

        public abstract void Fire();

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}