using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloorFlameShot : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 5;
    private Rigidbody2D rb;
    public GameObject fire;

    // Update is called once per frame

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1 * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Instantiate(fire);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
