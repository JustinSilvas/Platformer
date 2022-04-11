using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JS start
public class Platformenemy : MonoBehaviour
{
    public GameObject play;
    private Rigidbody2D body;
    public Transform player;
    public Transform firingPoint;
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;

    public float distance;
    private float range = 10;
    private float walkingSpeed = 5;
    private bool inRange = false;
    private float checkDist;
    public bool direction = false;
    public float shootCooldown = 5;
    private float nextShot;
    private bool Shot;
    private int health = 30;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
              

    }

    // Update is called once per frame
    void Update()
    {
        nextShot += Time.deltaTime;
       
        //Check next Shot
        if (nextShot > shootCooldown)
        {
            Shot = true;
        }

        if (Shot)
        {
            DistanceCheck();
            if (inRange)
            {
                Throw();
                Shot = false;
                nextShot = 0;
            }
            
        }
    }

    //Collision with player or Bullets
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
        }

        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
        
        
    }

    //Check Distace of player to decide what side to shoot
    private void DistanceCheck()
    {
        if (play != null)
        {
            distance = player.position.x - body.position.x;
            if (distance < range && distance > -range)
            {
                if (distance > 0)
                {
                    
                    direction = true;

                }
                else if (distance < 0)
                {
                    
                    direction = false;
                }
                inRange = true;
            }
            else
            {
                inRange = false;
            }
        }
    }

    private void Throw()
    {
        if (direction)
        {
            float angle = direction ? 0f : 180f;
            Instantiate(bulletPrefabRight, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
        else if (!direction)
        {
            float angle = direction ? 0f : 180f;
            Instantiate(bulletPrefabLeft, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
        
    }
    public int DirectionSign()
    {
        if (direction)
        {
            return -1;
        }
        else if (!direction)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
//JS end

