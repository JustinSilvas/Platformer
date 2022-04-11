using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JS start
public class Elevator : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float elevatorSpeed = 10;
    private bool topBot = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, -elevatorSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0, elevatorSpeed);

        if (body.position.y >= 55 && topBot == true)        {
            elevatorSpeed = -elevatorSpeed;
            topBot = false;
        }
        else if (body.position.y <= -5 && topBot == false)
        {
            elevatorSpeed = -elevatorSpeed;
            topBot = true;
        }
    }
}
//JS end
