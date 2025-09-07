using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class AmmoDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _ammoText;

        public void SetText(string ammo)
        {
            _ammoText.text = ammo;
        }
    }
}