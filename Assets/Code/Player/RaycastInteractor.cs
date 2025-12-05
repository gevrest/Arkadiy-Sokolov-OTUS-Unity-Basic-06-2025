using UnityEngine;

namespace Game
{
    public sealed class RaycastInteractor : TickableObject
    {
        [SerializeField] private float _interactionDistance = 3f;
        [SerializeField] private Transform _rayPoint;

        public override void OnTick()
        {
            if (Physics.Raycast(_rayPoint.position, _rayPoint.forward, out var hitInfo, _interactionDistance))
            {
                if (hitInfo.collider.CompareTag("InteractableObject"))
                {
                    Interact(hitInfo.collider);
                }
            }
        }

        private void Interact(Collider collider)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collider.TryGetComponent(out Bonfire bonfire))
                {
                    bonfire.Switch();
                }
            }
        }
    }
}