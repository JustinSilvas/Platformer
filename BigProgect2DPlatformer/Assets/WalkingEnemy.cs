using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WalkingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    private Transform player;
    private float walkingSpeed = 5;
    private bool wallCollision = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
        walkingSpeed = -walkingSpeed;
        body.velocity = new Vector2(walkingSpeed, 0);
    }

    // Update is called once per frame

    private void Update()
    {
        body.velocity = new Vector2(walkingSpeed, 0);
        if (wallCollision)
        {
            body.velocity = new Vector2(walkingSpeed, 0);
            walkingSpeed = -walkingSpeed;
            wallCollision = false;
        }
        if (body.position.x >= 27 && body.position.x <= 30)
        {
            walkingSpeed = -walkingSpeed;
            body.velocity = new Vector2(walkingSpeed, 0);
        }

        if (player.position.x - body.position.x < 5f && player.position.x - body.position.x > -5f)
        {
            float distance = player.position.x - body.position.x;
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))//If hit wall change direction
        {
            wallCollision = true;
        }

    }

    private void DistanceCheck()
    {
         
    }
}
