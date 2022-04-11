using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//JS start
public class WalkingEnemyWall : MonoBehaviour
{
    public GameObject play;
    private Rigidbody2D body;
    public Transform player;
    private Bullet b;
    private float range = 10;
    private float walkingSpeed = -5;
    private bool wallCollision = false;
    private bool inRange = false;
    private float checkDist;
    private bool direction = false;
    public float health = 10;

    bool facingLeft;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(walkingSpeed, 0);
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        body.velocity = new Vector2(walkingSpeed, 0);
        if (wallCollision && direction == false)
        {
            body.velocity = new Vector2(walkingSpeed, 0);
            walkingSpeed = -walkingSpeed;
            wallCollision = false;
            direction = true;
            
        }
        if (body.position.x >= 29 && direction == true)
        {
            walkingSpeed = -walkingSpeed;
            body.velocity = new Vector2(walkingSpeed, 0);
            direction = false;
            
        }
        if (player.position.y <= body.position.y + 2)
        {
            DistanceCheck();
        }
        
        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallCollision = true;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (player.position.x - body.position.x > 0)
            {

            }
        }
        
    }


    private void DistanceCheck()
    {
        if (play != null)
        {
            float distance = player.position.x - body.position.x;
            if ((distance < range && distance > -range) && inRange == false)
            {
                if (distance > 0)
                {

                    if (walkingSpeed < 0)
                    {
                        walkingSpeed = -walkingSpeed;
                        direction = true;
                        

                    }
                }
                else if (distance < 0)
                {

                    if (walkingSpeed > 0)
                    {
                        walkingSpeed = -walkingSpeed;
                        direction = false;
                        
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
    }

    private void SwitchSides(ref float saved)
    {
        float newDistance = player.position.x - body.position.x;

        if (saved < 0 && newDistance > 0)
        {
            walkingSpeed = -walkingSpeed;
            direction = true;
            saved = newDistance;
        }       
        if (saved > 0 && newDistance < 0)
        {
            walkingSpeed = -walkingSpeed;
            direction = false;
            saved = newDistance;
        }
    }
}
//JS end
