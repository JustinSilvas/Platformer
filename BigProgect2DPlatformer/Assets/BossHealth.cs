using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public int maxHealth = 1000;
    public int currentHealth;

    public HealthBar healthBar; //Calls HealthBar class

    //Calls different enemies


    private void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); //sets health bar to max health
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Checks collision and calls TakeDamage function with corresponding damage amount
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }


    }

    private void Update()
    {


    }

    void TakeDamage(int damage) //changes player health and calls health bar with said health
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
