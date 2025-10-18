using UnityEngine;

namespace Game
{
    public class RaycastInteractor : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance = 3f;
        [SerializeField] private Transform _rayPoint;

        private void Update()
        {
            if (Physics.Raycast(_rayPoint.position, _rayPoint.forward, out var hitInfo, _interactionDistance))
            {
                if (hitInfo.collider.CompareTag("InteractableObject"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (hitInfo.collider.TryGetComponent(out Bonfire bonfire))
                        {
                            bonfire.Kindle();
                        }
                    }
                }
            }
        }
    }
}