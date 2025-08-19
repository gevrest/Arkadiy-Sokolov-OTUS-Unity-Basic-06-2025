using UnityEngine;

namespace Game
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Fire();

        public abstract void Reload();

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}