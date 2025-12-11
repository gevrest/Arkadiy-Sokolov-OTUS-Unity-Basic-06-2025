using UnityEngine;

namespace Game
{
    [RequireComponent (typeof (Animator))]
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Death();
            }
        }

        private void Death()
        {
            _animator.enabled = false;
        }
    }
}