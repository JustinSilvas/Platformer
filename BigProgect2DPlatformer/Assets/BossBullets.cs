using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{
    public float bulletSpeed = 5;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private float kill;
    [SerializeField] private float bulletTime = 5;
    private float playerPos;

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
