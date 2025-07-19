using UnityEngine;

namespace Character
{
    public class CharacterSpawner : MonoBehaviour
    {
        public int CharacterQuantity = 5;
        public Transform Spawner;
        public GameObject Prefab;

        private void Start()
        {
            for (int i = 0; i < CharacterQuantity; i++)
            {
                var character = Instantiate(Prefab, new Vector3(Spawner.position.x + i, Spawner.position.y, Spawner.position.z), Quaternion.identity, Spawner);
                character.gameObject.SetActive(true);
            }
        }
    }
}