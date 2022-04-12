using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AL start
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
        distanceFromHook = new Vector2(gpoint.position.x - player.position.x, gpoint.position.y - player.position.y); //gets distance of the grappling point from the player
        if (Input.GetKeyDown(KeyCode.Q) && (distanceFromHook.x <= 20 && distanceFromHook.x >= -20)) //when q is pressed and the player is in a certain range of the grapple point it will activate the rope
        {
            if (ropeActive == false)
            {
                Vector2 destiny = GameObject.FindGameObjectWithTag("gpoint").transform.position;
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeScript>().destiny = destiny;
                ropeActive = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Q)) //when q is let go the rope will deactivate
        {
            Destroy(curHook);
            ropeActive = false;
        }

    }
}
//AL end
