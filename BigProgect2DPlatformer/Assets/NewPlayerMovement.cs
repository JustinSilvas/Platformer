using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float coyoteTime; //Time plyer can hang in the air before jumping
    private float coyoteCounter; //Time passed since player ran off an edge
    [SerializeField] private int extraJumps; //Number of extra jumps player can do
    private int jumpCounter; // How many extra jumps the player has at any moment
    [SerializeField] private float wallJumpX; // horizontal wall jump force
    [SerializeField] private float wallJumpY; // vertical wall jump force
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    

    [HideInInspector] public bool isFacingRight = true;


    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //Grabs references for rigidbodyand animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        

        horizontalInput = Input.GetAxis("Horizontal");

        //Flips player when moving left or right
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
        

        //Set animator parameters
        //anim.SetBool("Run", horizontalInput != 0);
        //anim.SetBool("Grounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }

        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
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

        if (onWall())
        {
            wallJump();
        }
        else
        {
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
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
    private void wallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        wallJumpCooldown = 0;
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
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
        /*if (collision.gameObject.CompareTag("Floor"))//checks that player is touching ground
        {
            isGrounded();

        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall();
        }*/

        
    }
}
