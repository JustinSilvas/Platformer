using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JS start
public class Boss1st : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed = 1;
    public float shootCooldown = 3;
    public GameObject normalBullet;
    public GameObject floorFireBullet;
    public GameObject spreadShotBullet;
    public Transform[] firingPointSpread;
    public Transform firingPoint;
    private bool bossDown = false;
    private float time;
    public GameObject target;
    private bool normalShot = false;
    private bool floorShot = false;
    private bool spreadShot = false;
    public float spreadShotCooldown = 13;
    private float spreadShotTime = 0;
    private float floorShotTime = 0;
    public float floorShotCooldown = 15;


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
        if (body.position.y <= 6.7f)
        {
            body.velocity = new Vector2(0,0);
            bossDown = true;
        }
        //Check if boss already in position before moving 
        if (bossDown)
        {
            time += Time.deltaTime;
            spreadShotTime += Time.deltaTime;
            floorShotTime += Time.deltaTime;

            //Death based on health

            //Rotation of onject towards player
            Vector2 separation = target.transform.position - transform.position;
            float angle = Mathf.Atan2(separation.y, separation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));

            if (time > shootCooldown)
            {
                int randomNumber = Random.Range(0, 10);
                Debug.Log(randomNumber);

                if ((randomNumber >= 0 && randomNumber <= 5) && normalShot == false)
                {
                    normalShot = true;
                    StartCoroutine(NormalShoot());
                    time = 0;
                }

                else if ((randomNumber <= 8) && spreadShot == false)
                {
                    if (spreadShotTime > spreadShotCooldown)
                    {
                        spreadShot = true;
                        StartCoroutine(SpreadShot());
                        time = 0;
                        spreadShotTime = 0;
                    }
                }

                else if (randomNumber == 9 && floorShot == false)
                {
                    if (floorShotTime > floorShotCooldown)
                    {

                        floorShot = true;
                        FireFloorShot();
                        time = 0;
                        floorShotTime = 0;
                    }
                }
            }

            

            //Shooting with cooldown

        }
    }

    private IEnumerator NormalShoot()
    {
        for (int j = 0; j < 3 ; j++)
        {
            Instantiate(normalBullet, firingPoint.position, body.transform.rotation);
            yield return new WaitForSeconds(0.1f);

        }

        normalShot = false;
    }

    private void FireFloorShot()
    {
        Instantiate(floorFireBullet, firingPoint.position, Quaternion.identity);
        floorShotTime = 0;
    }

    private IEnumerator SpreadShot()
    {
        //Runs through first phase of shooting
        for(int i = 0; i < (firingPointSpread.Length/2) + 1; i++)
        {
            spreadShotTime = 0;
            Instantiate(spreadShotBullet, firingPointSpread[i].position, body.transform.rotation);
            Instantiate(spreadShotBullet, firingPointSpread[firingPointSpread.Length - i - 1].position, body.transform.rotation);
            //Set waiting time per shot
            yield return new WaitForSeconds(0.1f);

        }
        //Runs through second phase
        for (int i = 0; i < (firingPointSpread.Length / 2) + 1; i++)
        {
            Instantiate(spreadShotBullet, firingPointSpread[(firingPointSpread.Length / 2) +i].position, body.transform.rotation);
            Instantiate(spreadShotBullet, firingPointSpread[(firingPointSpread.Length / 2) - i].position, body.transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
        spreadShot = false;
    }
}
//JS end
