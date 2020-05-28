using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//craate a father class
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar health;
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamege(20);
        }
    }
    public void TakeDamege(int damage)
    {
        currentHealth -= damage;
        health.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}

