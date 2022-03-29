using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WalkingEnemyWall : MonoBehaviour
{
    public GameObject play;    //Player alive track
    private Rigidbody2D body;    //Rigidbody of enemy
    public Transform player;     //player location track
    private Bullet b;     //Bullet reference
    private float range = 10;
    private float walkingSpeed = -5;
    private bool wallCollision = false;
    [SerializeField] float rightWallLimit = 29;
    private bool inRange = false;
    private float checkDist;
    private bool direction = false;     //False = Left and True = right
    public float health = 10;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(walkingSpeed, 0);
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        //Check if player is null and if not dont run
        if (play != null)
        {
            //Set walking speed
            body.velocity = new Vector2(walkingSpeed, 0);
            // Wall collision and direction to left
            if (wallCollision && direction == false)
            {
                walkingSpeed = -walkingSpeed;
                wallCollision = false;
                direction = true;
            }
            //If passed x limit and direction right
            if (body.position.x >= rightWallLimit && direction == true)
            {
                walkingSpeed = -walkingSpeed;
                direction = false;
            }
            //Checks y value to check distance
            if (player.position.y <= body.position.y + 2)
            {
                DistanceCheck();
            }    
            if (body.velocity.x > 0 && !facingLeft)
            {
            facingLeft = true;
            body.transform.Rotate(0, 180, 0);
            }
        else if (body.velocity.x < 0 && facingLeft)
            {
            facingLeft = false;
            body.transform.Rotate(0, 180, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Wall Collision Check
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallCollision = true;
        }

        //Bullet Collision Check
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }

        //Head collision Check with y value
        if (collision.gameObject.CompareTag("Player") && player.position.y > body.position.y + 1)
        {
            Destroy(this.gameObject);
        }
        
    }

    //Finds the difference in x between enemy and player to change velocity of the enemy
    private void DistanceCheck()
    {
        float distance = player.position.x - body.position.x; //Difference between player position and enemy position

        if ((distance < range && distance > -range) && inRange == false)
        {
            //right check to turn 
            if (distance > 0)
            {
                //if walkingspeed is negative
                if (walkingSpeed < 0)
                {
                    walkingSpeed = -walkingSpeed;
                    direction = true;

                }
            }
            //Left check to turn 
            else if (distance < 0)
            {
                //If walking speed is positive
                if (walkingSpeed > 0)
                {
                    walkingSpeed = -walkingSpeed;
                    direction = false;
                }
            }
            checkDist = distance;
            inRange = true;
        }
        //in Range hasnt changed but checks if needs to turn
        else if (distance < range && distance > -range && inRange == true)
        {
            SwitchSides(ref checkDist);
        }
        //Out of Range Check
        else if (distance > range && distance > -range && inRange == true)
        {
            inRange = false;
        }
        
    }

    //Switches sides if still in range but distance has changed from positive to negative and vise versa
    private void SwitchSides(ref float saved)
    {
        float newDistance = player.position.x - body.position.x;

        //distance changed from negative to positive
        if (saved < 0 && newDistance > 0)
        {
            walkingSpeed = -walkingSpeed;
            direction = true;
            saved = newDistance;
        }
        //distace changed from postive to negative 
        if (saved > 0 && newDistance < 0)
        {
            walkingSpeed = -walkingSpeed;
            direction = false;
            saved = newDistance;
        }
    }
}
