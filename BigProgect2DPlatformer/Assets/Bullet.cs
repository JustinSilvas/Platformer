using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JS start
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;
    [SerializeField] private float bulletTime = 5;

    // Update is called once per frame

    void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;
        
        Destroy(gameObject, 5f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
//JS end
