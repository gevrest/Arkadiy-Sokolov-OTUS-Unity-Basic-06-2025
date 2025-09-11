using UnityEngine;

namespace Game
{
    public sealed class WeaponSelector
    {
        private readonly Weapon[] _weapons;
        private int _currentIndex = 0;
        private Weapon _currentWeapon;
        private AmmoDisplay _ammoDisplay;

        public WeaponSelector(Weapon[] weapons, AmmoDisplay ammoDisplay)
        {
            _weapons = weapons;
            _ammoDisplay = ammoDisplay;
            for (int i = 0; i < _weapons.Length; i++)
            {
                Weapon weapon = _weapons[i];
                weapon.SetActive(false);
            }
        }

        public void NextWeapon()
        {
            _currentIndex++;
            SelectWeapon();
        }

        public void PreviosWeapon()
        {
            _currentIndex--;
            SelectWeapon();
        }

        public void SelectWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.SetActive(false);
            }

            int index = Mathf.Abs(_currentIndex % _weapons.Length);

            _currentWeapon = _weapons[index];
            _currentWeapon.SetActive(true);
        }

        public void Fire()
        {
            _currentWeapon.Fire();
        }

        public void Reload()
        {
            if (_currentWeapon is IReloadable reload)
            {
                reload.Reload();
            }
        }

        public void ReleaseTrigger()
        {
            if (_currentWeapon is IReleasable release)
            {
                release.ReleaseTrigger();
            }
        }

        public void SetAmmoText()
        {
            _ammoDisplay.SetText(_currentWeapon.Ammo.ToString());
        }
    }
}