using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene"); //Loads game scene
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Quits game
    }

}
