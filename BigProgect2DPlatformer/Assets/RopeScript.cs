using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AL start
public class RopeScript : MonoBehaviour
{
    public Vector2 destiny; //distance between player and grapple point
    public float speed = 1; //speed rope comes out
    public float distance = 2; //distance between nodes
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
        lr = GetComponent<LineRenderer>(); //variable for line renderer
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        nodes.Add(transform.gameObject);
        lr.startWidth = .1f; //width of rope
        lr.endWidth = .1f;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed); //rope will move towards the grapple point

        if((Vector2)transform.position != destiny) //if the rope is moving to the grapple point nodes will be created from the player to the grapple point
        {
            if(Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();

            }
           

        }
        else if (done == false) //connects player to the last node
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
    void CreateNode() //creates nodes in between the distance from the player to the grapple point
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position; //difference between player and last node created
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;
        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity); //creates node
        go.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        lastNode = go;
        nodes.Add(lastNode);
        vertexCount++;

    }
    void RenderLine() //creates line between all of the nodes from the player to the grapple point
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
//AL end
