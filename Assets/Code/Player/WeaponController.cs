using UnityEngine;

namespace Game
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private AmmoDisplay _ammoDisplay;
        private WeaponSelector _weaponSelector;

        private void Start()
        {
            Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
            _weaponSelector = new WeaponSelector(weapons, _ammoDisplay);

            _weaponSelector.SelectWeapon();
        }

        private void Update()
        {
            if (Time.timeScale == 0f)
            {
                return;
            }

            _weaponSelector.SetAmmoText();

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

            if (Input.GetMouseButtonUp(0))
            {
                _weaponSelector.ReleaseTrigger();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weaponSelector.Reload();
            }
        }
    }
}