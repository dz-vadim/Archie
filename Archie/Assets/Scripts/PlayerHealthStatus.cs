using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthStatus : MonoBehaviour
{
    public int maxHealth;
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
            print("GameOver");
        }
    }
}
