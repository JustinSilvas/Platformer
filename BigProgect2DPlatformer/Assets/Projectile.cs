using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JS start
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 10f;
    public float bulletDamage = 0f;
    public float bulletJump = 20f;
    public Rigidbody2D rb;
    private float kill;
    [SerializeField] private float bulletTime = 5;


    // Update is called once per frame
    void Awake()
    {
        rb.velocity = new Vector2(bulletSpeed, bulletJump);
        Destroy(this.gameObject, 3f);
    }

    private void FixedUpdate()
    {

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
//JS end
