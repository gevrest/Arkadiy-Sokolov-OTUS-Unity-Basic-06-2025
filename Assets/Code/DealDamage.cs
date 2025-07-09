using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Press E to deal {damage} damage to the target. The target has {health} HP.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && health != 0)
        {
            health -= damage;
            Debug.LogError($"Target HP: {health}");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.LogWarning("The target was destroyed. Press space to recover the target");
        }

        if (Input.GetKeyDown(KeyCode.Space) && health == 0)
        {
            health = maxHealth;
            Debug.Log($"The target was recovered and has {health} HP.");
        }
    }
}