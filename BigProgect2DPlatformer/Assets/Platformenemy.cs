using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformenemy : MonoBehaviour
{
    private Rigidbody2D body;
    public Transform player;
    private float range = 10;
    private float walkingSpeed = 5;
    private bool inRange = false;
    private float checkDist;
    public float leftLimit;
    public float rightLimit;
    private bool direction = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
        body.velocity = new Vector2(walkingSpeed, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(walkingSpeed, 0);
        if (body.position.x >= rightLimit && direction == true)
        {
            body.velocity = new Vector2(walkingSpeed, 0);
            walkingSpeed = -walkingSpeed;
            direction = false;
        }

        if (body.position.x <= leftLimit && direction == false)
        {
            walkingSpeed = -walkingSpeed;
            body.velocity = new Vector2(walkingSpeed, 0);
            direction = true;
        }
        DistanceCheck();
    }


    private void DistanceCheck()
    {
        float distance = player.position.x - transform.position.x;
        if ((distance < range && distance > -range) && inRange == false)
        {
            if (distance > 0)
            {
                if (walkingSpeed < 0)
                {
                    walkingSpeed = -walkingSpeed;
                }
            }
            else
            {
                if (walkingSpeed > 0)
                {
                    walkingSpeed = -walkingSpeed;
                }
            }
            checkDist = distance;
            inRange = true;
        }
        else if (distance < range && distance > -range && inRange == true)
        {
            SwitchSides(ref checkDist);
        }
        else if (distance > range && distance > -range && inRange == true)
        {
            inRange = false;
        }
    }
    private void SwitchSides(ref float saved)
    {
        Vector2 newDistance = player.position - transform.position;

        if (((saved < 0 && newDistance.x > 0) || (saved > 0 && newDistance.x < 0)))
        {
            walkingSpeed = -walkingSpeed;
            saved = newDistance.x;
        }
    }
}
