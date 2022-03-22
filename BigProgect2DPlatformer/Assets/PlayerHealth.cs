using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Respawn respawn;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(40);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(50);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            respawn.playerRespawn();
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
