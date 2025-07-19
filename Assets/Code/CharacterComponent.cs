using UnityEngine;

namespace Character
{
    public class CharacterComponent : MonoBehaviour
    {
        public bool IsEnemy;
        public GameObject Character;

        private void OnValidate()
        {
            CharacterDefinition(IsEnemy);
        }

        private void CharacterDefinition(bool enemy)
        {
            if (enemy)
            {
                Character.GetComponent<Renderer>().material.color = Color.red;
                Character.name = "Enemy";
            }
            else
            {
                Character.GetComponent<Renderer>().material.color = Color.blue;
                Character.name = "Ally";
            }
        }
    }
}