using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Press E to deal {damage} damage to the target. The target has {health} HP.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDead)
        {
            DealDamage();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDead)
        {
            RecoverTarget();
        }
    }

    public void DealDamage()
    {
        health = Mathf.Max(0, health - damage);
        Debug.LogError($"Target HP: {health}");

        if (health == 0)
        {
            isDead = true;
            Debug.LogWarning("The target was destroyed. Press space to recover the target");            
        }
    }

    public void RecoverTarget()
    {
        health = maxHealth;
        isDead = false;
        Debug.Log($"The target was recovered and has {health} HP.");
    }

}