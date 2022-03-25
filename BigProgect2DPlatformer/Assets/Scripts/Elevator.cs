using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float elevatorSpeed = 5;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, -elevatorSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (body.position.y >= 55 || body.position.y <= -5)
        {
            elevatorSpeed = -elevatorSpeed;
            body.velocity = new Vector2(0, elevatorSpeed);
        }
    }
}
