using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Vector2 destiny;
    public float speed = 1;
    public float distance = 2;
    public GameObject nodePrefab;
    public GameObject player;
    public GameObject lastNode;
    public List<GameObject> nodes = new List<GameObject>();
    public LineRenderer lr;
    bool done = false;
    int vertexCount = 2;


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        nodes.Add(transform.gameObject);
        lr.startWidth = .1f;
        lr.endWidth = .1f;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

        if((Vector2)transform.position != destiny)
        {
            if(Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();

            }
           

        }
        else if (done == false)
        {
            done = true;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();

            while(Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();

            }

        }

        RenderLine();



    }
    void CreateNode()
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;
        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);
        go.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        lastNode = go;
        nodes.Add(lastNode);
        vertexCount++;

    }
    void RenderLine()
    {
        lr.positionCount = vertexCount;

        int i;
        
        for(i = 0; i < nodes.Count; i++)
        {
            lr.SetPosition(i,nodes[i].transform.position);
        }

        lr.SetPosition(i, player.transform.position);

    }
}
