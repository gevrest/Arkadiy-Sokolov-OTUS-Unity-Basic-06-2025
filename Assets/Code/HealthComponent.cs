using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int health = 100;
    private bool isDead = false;

    public void DealDamage(int damage)
    {
        if (!isDead)
        {
            health = Mathf.Max(0, health - damage);
        }

        if (health == 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

}