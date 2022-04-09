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
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        playerHealth.lifeCount = 3;
        healthBar.SetLifeCount(playerHealth.lifeCount);
    }
    public void ExitButton()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Title Screen");
    }
}
