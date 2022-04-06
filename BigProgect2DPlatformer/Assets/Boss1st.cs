using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1st : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed = 1;
    [SerializeField] private static int maxHealth = 200;
    [SerializeField] private float shootCooldown = 20;
    public GameObject normalBullet;
    public GameObject floorFireBullet;
    public Transform firingPoint;
    private bool bossDown = false;
    private float time;
    public GameObject target;

    BossBullets bullets = new BossBullets();


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
        //Stop of the initial movement
        if (body.position.y <= 5)
        {
            body.velocity = new Vector2(0,0);
            bossDown = true;
        }
        //Check if boss already in position before moving 
        if (bossDown)
        {
            time += Time.deltaTime;
            //Death based on health
            if (maxHealth <= 0)
            {
                Destroy(this.gameObject);
            }

            //Rotation of onject towards player
            Vector2 separation = target.transform.position - transform.position;
            float angle = Mathf.Atan2(separation.y, separation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));


            //Shooting with cooldown
            if (time >= shootCooldown)
            {
                NormalShoot();
                time = 0;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            maxHealth -= 10;
        }
    }

    private void NormalShoot()
    {
        Instantiate(normalBullet, firingPoint.position, body.transform.rotation);

    }

    private void FireFloorShot()
    {
        Instantiate(floorFireBullet, firingPoint.position, Quaternion.identity);
    }
}
