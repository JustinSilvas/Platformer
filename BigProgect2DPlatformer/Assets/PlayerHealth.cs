using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;
    public int lifeCount;

    string currentSceneName;

    public HealthBar healthBar;
    public Respawn respawn;

    public GameObject walkingEnemy;
    public GameObject platformEnemy1;
    public GameObject platformEnemy2;


    private void Start()
    {
        lifeCount = 3;
        currentSceneName = SceneManager.GetActiveScene().name;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(40);
        }
        if (collision.gameObject.CompareTag("WalkingEnemy") && transform.position.y < walkingEnemy.transform.position.y + .5 )
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("PlatformEnemy1") && transform.position.y < platformEnemy1.transform.position.y + .5)
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("PlatformEnemy2") && transform.position.y < platformEnemy2.transform.position.y + .5)
        {
            TakeDamage(50);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(maxHealth);
        }
        
    }

    private void Update()
    {

        if (transform.position.y <= -20)
        {
            TakeDamage(maxHealth);
        }
        if (currentHealth <= 0 && lifeCount > 0)
        {
            lifeCount--;
            respawn.PlayerRespawn();
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);

            healthBar.SetLifeCount(lifeCount);

        }
        if (lifeCount <= 0)
        {
            SceneManager.LoadScene(currentSceneName);
            lifeCount = 3;

            healthBar.SetLifeCount(lifeCount);

        }
        

        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
