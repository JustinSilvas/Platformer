/************************
All code in this class was made by Brandon Martel
************************/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public HealthBar healthBar; //Calls HealthBar class
    public BossHealth bossHealth; //Calls BossHealth class
    public PlayerHealth playerHealth; //Calls PlayerHealth class

    public void Setup()
    {
        gameObject.SetActive(true); //Makes the win screen visible
    }

    public void RestartButton()
    { // Unpauses the game and resets the game by loading the scene again
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        playerHealth.lifeCount = 3; //Resets player lives to 3

        healthBar.SetLifeCount(playerHealth.lifeCount); //Sets player health bar to max health
        bossHealth.currentHealth = bossHealth.maxHealth; //Resets boss health to max health
        bossHealth.healthBar.SetMaxHealth(bossHealth.maxHealth); //sets boss health bar to max health
    }
    public void ExitButton() //Switches the scene to the title screen
    {
        SceneManager.LoadScene("Title Screen");
    }
}
