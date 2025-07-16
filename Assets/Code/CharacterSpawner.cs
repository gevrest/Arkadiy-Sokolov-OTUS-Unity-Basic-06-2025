using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

    public int characterQuantity = 5;

    public Transform spawner;
    public GameObject prefab;

    public CharacterComponent characterComponent;

    void Start()
    {
        for (int i = 0; i < characterQuantity; i++)
        {
            var character = Instantiate(prefab, new Vector3(spawner.position.x + i, spawner.position.y, spawner.position.z), Quaternion.identity);
            character.gameObject.SetActive(true);
        }
    }

}