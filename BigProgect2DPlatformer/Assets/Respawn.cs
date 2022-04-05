using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    Vector3 startingPos;


    void Start()
    {
        startingPos = transform.position;
    }

    public void PlayerRespawn()
    {
        transform.position = startingPos;
    }
}
