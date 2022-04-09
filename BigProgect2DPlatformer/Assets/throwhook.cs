using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwhook : MonoBehaviour
{
    public GameObject hook;

    GameObject curHook;

    public bool ropeActive = false;

    public Transform player;

    public Transform gpoint;

    Vector2 distanceFromHook;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceFromHook = new Vector2(gpoint.position.x - player.position.x, gpoint.position.y - player.position.y);
        if (Input.GetKeyDown(KeyCode.Q) && (distanceFromHook.x <= 20 && distanceFromHook.x >= -20))
        {
            if (ropeActive == false)
            {
                Vector2 destiny = GameObject.FindGameObjectWithTag("gpoint").transform.position;
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeScript>().destiny = destiny;
                ropeActive = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Destroy(curHook);
            ropeActive = false;
        }

    }
}
