using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{

    public bool isEnemy;
    public GameObject character;

    private void OnValidate()
    {
        CharacterDefinition(isEnemy);
    }

    public void CharacterDefinition(bool Enemy)
    {
        if (Enemy)
        {
            character.GetComponent<MeshRenderer>().material.color = Color.red;
            character.name = "Enemy";
        }
        else
        {
            character.GetComponent<MeshRenderer>().material.color = Color.blue;
            character.name = "Ally";
        }
    }

}