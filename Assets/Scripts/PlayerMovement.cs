using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 horizonalInput = Vector2.zero;
    //public to debug
    public PlayerMovementState playerMovementState = PlayerMovementState.Grounded;
    public float playerSpeed = 30000f;
    private bool jump;
    private float jumpPower = 10000f;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    { 
        if(rb.velocity.y < -1)
        {
            playerMovementState = PlayerMovementState.Falling;
        }
        else if (rb.velocity.y == 0)
        {
            playerMovementState = PlayerMovementState.Grounded;
        }
        else
        {
            playerMovementState = PlayerMovementState.Jumping;
        }

        horizonalInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
        jump = Input.GetKey(KeyCode.Space);

        //Check to see if the player is jumping or grounded.
        switch (playerMovementState)
        {
            //If player is jumping, we change the aerial speed and perform
            //a raycast to check when we hit the ground again.
            //This raycast may need to be refactored using physics layers in the future.
            case PlayerMovementState.Jumping:
                playerSpeed = 10000f;
                rb.drag = 1.5f;
               
                break;
                //When grounded, go back to normal speed.
            case PlayerMovementState.Grounded:
                playerSpeed = 30000f;
                rb.drag = 1.5f;
                break;
            case PlayerMovementState.Falling:
                rb.drag = 0;
                playerSpeed = 3000f;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
                Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);
                //If player is close enough to ground
                //This will also need to change when the player grows in size.
                if(hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.layer);
                    if (hit.collider.gameObject.layer == 7 || hit.collider.gameObject.layer == 8)
                    {
                        
                        playerMovementState = PlayerMovementState.Grounded;
                    }
                }
                
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        //Processing the horizontal movement.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(horizonalInput * playerSpeed);
        }
        //Added a jump
        if (jump && playerMovementState == PlayerMovementState.Grounded)
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            playerMovementState = PlayerMovementState.Jumping;
        }
    }
}

//States for movement.
public enum PlayerMovementState
{
    Jumping,
    Grounded,
    Falling,
}
