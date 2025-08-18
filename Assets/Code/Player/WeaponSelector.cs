using UnityEngine;

namespace Game
{
    public class WeaponSelector : MonoBehaviour
    {
        private int _weaponIndex;

        public void NextWeapon()
        {
            SelectWeapon();
        }

        public void PreviosWeapon()
        {
            SelectWeapon();
        }

        private void SelectWeapon()
        {

        }
    }
}