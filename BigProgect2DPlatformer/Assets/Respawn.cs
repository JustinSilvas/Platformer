using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NH start
public class Respawn : MonoBehaviour
{

    Vector3 startingPos;
    Scene currentScene;


    void Start()
    {
        startingPos = transform.position; //sets respawn point
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void PlayerRespawn()
    {
        if(currentScene.name == "SampleScene")
        {
            transform.position = startingPos; //moves player to repawn point
        }
        else
        {
            transform.position = startingPos;
            Time.timeScale = 1f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        }
        
    }
}
//NH end
