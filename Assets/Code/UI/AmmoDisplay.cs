using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class AmmoDisplay : MonoBehaviour
    {
        private TMP_Text _ammoText;

        private void Start()
        {
            _ammoText = GetComponentInChildren<TMP_Text>();
        }

        public void SetText(string ammo)
        {
            _ammoText.text = ammo;
        }
    }
}