using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;
    private float kill;
    [SerializeField] private float bulletTime = 5;

    // Update is called once per frame

    void FixedUpdate()
    {
        kill += Time.deltaTime;

        rb.velocity = transform.right * bulletSpeed;
        if (kill > bulletTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
