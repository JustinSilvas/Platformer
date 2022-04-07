using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{
    public float bulletSpeed = 5;
    private Rigidbody2D rb;

    NewPlayerMovement target;
    Vector2 moveDirection;

    //NewPlayerMovement player = new NewPlayerMovement();

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<NewPlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 5f);
    }


    void FixedUpdate()
    {

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }



}
