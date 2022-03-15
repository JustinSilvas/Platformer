using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformenemy : MonoBehaviour
{
    private Rigidbody2D body;
    public Transform player;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    private float range = 10;
    private float walkingSpeed = 5;
    private bool inRange = false;
    private float checkDist;
    public float leftLimit;
    public float rightLimit;
    private bool direction = false;
    private float shootCooldown = 5;
    private float nextShot;
    private bool Shot;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(walkingSpeed, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
        nextShot = Time.time;
        body.velocity = new Vector2(walkingSpeed, 0);
        if (body.position.x >= rightLimit && direction == false)
        {
            body.velocity = new Vector2(walkingSpeed, 0);
            walkingSpeed = -walkingSpeed;
            direction = true;
        }

        if (body.position.x <= leftLimit && direction == true)
        {
            walkingSpeed = -walkingSpeed;
            body.velocity = new Vector2(walkingSpeed, 0);
            direction = false;
        }


        if (nextShot > shootCooldown)
        {
            Shot = true;
        }
        if (Shot)
        {
            Throw();
            Shot = false;
            nextShot -= shootCooldown;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void DistanceCheck()
    {
        float distance = player.position.x - body.position.x;
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

    void Throw()
    {
        float angle = direction ? 45f : 135;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(5, 0f, angle)));
    }
}
