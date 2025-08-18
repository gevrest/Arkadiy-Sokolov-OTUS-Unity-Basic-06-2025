using UnityEngine;

namespace Game
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private WeaponSelector _weaponSelector;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _weapon.Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weapon.Reload();
            }
        }
    }
}