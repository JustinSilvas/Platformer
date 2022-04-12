using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) //If the player presses escape the game will pause and show the pause UI and if the game is already paused pressing escape will unpause the game
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() //resumes the game and closes the pause UI and sets time to 1 which unpauses the game
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause() //pauses the game by setting time to 0 and sets the pause screen UI to active
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused=true;
    }

    public void LoadMenu() //loads title screen when the menu button is pressed
    {
        Resume();
        Time.timeScale =0f;
        SceneManager.LoadScene("Title Screen");

    }

    public void QuitGame() //quits out of the game when quit button is pressed
    {
        Application.Quit();
    }
}
