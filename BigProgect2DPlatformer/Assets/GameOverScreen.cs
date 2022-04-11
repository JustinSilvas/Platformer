/***************************
All code in this class was made by Brandon Martel.
***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public HealthBar healthBar; //Calls HealthBar class
    public PlayerHealth playerHealth; //calls player health class

    public void Setup()
    {
        gameObject.SetActive(true); //makes the game over screen visible
    }

    public void RestartButton()
    { //Unpauses the game and restarts the game by loading the scene and resetting player health
        Time.timeScale = 1f;
        playerHealth.lifeCount = 3;
        SceneManager.LoadScene("SampleScene");        
        healthBar.SetLifeCount(playerHealth.lifeCount);
    }
    public void ExitButton() //Changes the scene to the title screen
    {
        SceneManager.LoadScene("Title Screen");
    }
}
