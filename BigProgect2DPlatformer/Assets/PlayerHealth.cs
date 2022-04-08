using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int lifeCount;
    [SerializeField] private float collisionTimer;
    private float damageCooldown = 1;

    public HealthBar healthBar; //Calls HealthBar class
    public Respawn respawn; //Calls Respawn class

    //Calls different enemies


    private void Start()
    {
        lifeCount = 3;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); //sets health bar to max health
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //Checks collision and calls TakeDamage function with corresponding damage amount
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(40);
        }
        if (collision.gameObject.CompareTag("WalkingEnemy"))
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("PlatformEnemy1"))
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("PlatformEnemy2"))
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(maxHealth);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(50);
        }


    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
        if (transform.position.y <= -20) //Kills player if the fall below a certain threshold
        {
            TakeDamage(maxHealth);
        }
        if (currentHealth <= 0 && lifeCount > 0) //player respawns if it has lives remaining
        {
            lifeCount--;
            respawn.PlayerRespawn();
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);

            healthBar.SetLifeCount(lifeCount); //changes life count in UI

        }
        if (lifeCount <= 0) //reloads the scene if player runs out of lives
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            lifeCount = 3;

            healthBar.SetLifeCount(lifeCount);

        }



    }

    void TakeDamage(int damage) //changes player health and calls health bar with said health
    {
        if (collisionTimer >= damageCooldown)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            collisionTimer = 0;
        }
    }

}
