using UnityEngine;

namespace Game
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Fire();

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}