/************************************
All code in this class was made by Brandon Martel except for 
the first if statement which was made by Nik Haddock.
************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BM start
public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float wallclimbMult;
    [SerializeField] private float jumpPower;
    [SerializeField] private float coyoteTime; //Time plyer can hang in the air before jumping
    private float coyoteCounter; //Time passed since player ran off an edge
    [SerializeField] private int extraJumps; //Number of extra jumps player can do
    private int jumpCounter; // How many extra jumps the player has at any moment
    [SerializeField] private LayerMask groundLayer; //The surfaces that the player can jump on
    [SerializeField] private LayerMask wallLayer; //The surfaces that the player can climb and jump off of
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private float verticalInput;
    

    [HideInInspector] public bool isFacingRight = true;


    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //Grabs references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Flips player when moving left or right // NH
        if (horizontalInput > 0.01f && isFacingRight == false)
        {
            isFacingRight = true;
            transform.Rotate(0, 180, 0);
        }
        else if (horizontalInput < -0.01f && isFacingRight == true)
        {
            isFacingRight = false;
            transform.Rotate(0, 180, 0);
        }

        //Allows the player to jump by holding down space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //If the player lets go of space early, the jump height is reduced
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }
        //The player sticks on walls and can move up or down at a percentage of normal movement speed
        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
            body.velocity = new Vector2(body.velocity.x, verticalInput * (speed * wallclimbMult));
        }
        else //Allows the player to move normally and resets gravity
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //Resets coyote counter when on the ground
                jumpCounter = extraJumps; // Resets jump counter when on the ground
            }
            else
            {
                coyoteCounter -= Time.deltaTime; //Decreases coyote counter when not on ground
            }
        }
    }
    private void Jump()
    {
        // Disables jump when counter is <= 0 and no extra jumps
        if (coyoteCounter <= 0 && !onWall() && jumpCounter <= 0) 
        {
            return;
        }

        if (onWall()) //allows the player to jump off of walls
        {
            wallJump();
        }
        else
        {
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower); //The normal jump functionality
            }
            else
            {
                // If counter > 0 and not on ground then player can jump
                if (coyoteCounter > 0)
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                }
                else
                {
                    if (jumpCounter > 0) //Decreases jump counter if player uses an extra jump
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }
            //Avoids double jumps
            coyoteCounter = 0;
        }
    }
    private void wallJump() //Pushes the player by a set amount off of walls
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * 300, 200));
    }
    private bool isGrounded() //Uses raycasting to detect surfaces with the ground layer
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall() //Uses raycasting to detect surfaces with the wall layer
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
//BM end
