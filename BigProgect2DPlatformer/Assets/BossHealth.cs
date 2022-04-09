/***************************
All code related to the win screen was made by Brandon Martel.
The rest was made by Justin Silva.
***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public int maxHealth = 1000;
    public int currentHealth;

    public HealthBar healthBar; //Calls HealthBar class
    public WinScreen winScreen; //Calls win screen class  //BM

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
            TakeDamage(100);
        }


    }

    private void Update()
    {
        if (currentHealth <=0)
        {
            WinScreen(); //Shows the win screen if the boss' health reaches 0 //BM
        }

    }

    void TakeDamage(int damage) //changes player health and calls health bar with said health
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void WinScreen() //BM
    {
        winScreen.Setup(); //Calls the win screen
    }

}
