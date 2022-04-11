using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JS start 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    

    [SerializeField] private float jumpForce = 30; //allows programmer to change jump force in editor
    [SerializeField] private float runSpeed = 15; //allows prgrammer to change speed in editor
    private bool grounded;
    private bool onWall;
    

    [HideInInspector] public bool isFacingRight = true;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //assigns left and right arrow to move player
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * runSpeed, body.velocity.y);

        


        //Makes player look the way it's walking
        if (horizontalInput > 0f)
        {
            isFacingRight = true;
            transform.localScale = Vector3.one;
            //body.transform.Rotate(0f, 180f, 0f);
        }
        else if (horizontalInput < 0)
        {
            isFacingRight = false;
            //body.transform.Rotate(0f, 180f, 0f);
            transform.localScale = new Vector3(-1, 1, 1);

        }


        if (onWall && !grounded)
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }

        else
        {
            body.gravityScale = 7;
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (grounded == true || onWall == true))//checks that up arrow or w has been pressed and player is on ground
        {
            Jump();

        }
      
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);//sets direction and speed
        grounded = false;//Player is in air
        onWall = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))//checks that player is touching ground
        {
            grounded = true;
            
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall = true;
        }

    }

}   
//JS end

