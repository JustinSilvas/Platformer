using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwhook : MonoBehaviour
{
    public GameObject hook;

    GameObject curHook;

    public bool ropeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
            ropeActive=false;
        }
        
    }
}
