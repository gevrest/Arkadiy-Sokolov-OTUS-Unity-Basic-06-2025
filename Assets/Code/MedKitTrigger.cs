using UnityEngine;

namespace Game
{
    public class MedKitTrigger : MonoBehaviour
    {
        [SerializeField] private int _healing = 25;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<HealthComponent>().Heal(_healing);
                Destroy(gameObject);
            }
        }
    }
}