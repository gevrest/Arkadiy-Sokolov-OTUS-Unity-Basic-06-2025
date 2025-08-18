using UnityEngine;

namespace Game
{
    public sealed class Explosion : MonoBehaviour
    {
        private Collider[] _collidedObjects;

        public void Detonate(Vector3 position, float radius, float force, int damage)
        {
            _collidedObjects = Physics.OverlapSphere(position, radius);

            for (int i = 0; i < _collidedObjects.Length; i++)
            {
                Collider collider = _collidedObjects[i];

                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(force, position, radius);
                }
                if (collider.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.DealDamage(damage);
                }
            }
        }
    }
}