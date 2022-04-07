using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : MonoBehaviour
{
    public float bulletSpeed = 3;
    private Rigidbody2D rb;
    Vector2 moveDirection;
    // Start is called before the first frame update
    Boss1st boss = new Boss1st();
    Boss1st target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindObjectOfType<Boss1st>();
        moveDirection = (transform.position - target.transform.position) * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
