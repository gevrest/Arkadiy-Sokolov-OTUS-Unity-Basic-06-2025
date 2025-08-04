using UnityEngine;

namespace Game
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivateJumpAnimation();
            }
        }

        private void ActivateJumpAnimation()
        {
            _animator.SetTrigger("Jump");
        }
    }
}