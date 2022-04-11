using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NH start
public class Respawn : MonoBehaviour
{

    Vector3 startingPos;


    void Start()
    {
        startingPos = transform.position; //sets respawn point
    }

    public void PlayerRespawn()
    {
        transform.position = startingPos; //moves player to repawn point
    }
}
//NH end
