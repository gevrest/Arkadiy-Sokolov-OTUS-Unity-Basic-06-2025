using UnityEngine;

namespace Game
{
    public class WeaponController : MonoBehaviour
    {
        private WeaponSelector _weaponSelector;

        private void Start()
        {
            Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
            _weaponSelector = new WeaponSelector(weapons);

            _weaponSelector.SelectWeapon();
        }

        private void Update()
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            if (scrollWheel >= 0.1f)
            {
                _weaponSelector.NextWeapon();
            }

            if (scrollWheel <= -0.1f)
            {
                _weaponSelector.PreviosWeapon();
            }
            if (Input.GetMouseButton(0))
            {
                _weaponSelector.Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weaponSelector.Reload();
            }
        }
    }
}