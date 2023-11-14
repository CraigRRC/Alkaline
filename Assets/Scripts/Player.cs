using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Magnet[] magnetsInLvl;
    private PlayerMovement movementScript;
    public Sprite deathSprite;
    private Animator playerAnimator;
    private PlayerState playerState = PlayerState.Alive;
    public int currentPolaritySwitches;
    public BoxCollider2D playerDeathBox;
    public float lethalImpactForce = 11f;
    public float pushingForce = 3750f;

    private void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetsInLvl != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentPolaritySwitches++;
                foreach (var magnet in magnetsInLvl)
                {
                    if(magnet != null)
                        magnet.FlipPolarity();
                }
               
            }
        }

        if(playerState == PlayerState.Dead)
        {
            magnetsInLvl = null;
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hazard
        if(collision.gameObject.layer == 10)
        {
            //die
            if(deathSprite != null)
            {
                PlayerDead();
            }

        }

        if (collision.relativeVelocity.magnitude > lethalImpactForce)
        {
            PlayerDead();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //Gives the player just a little more oomph.
            collision.rigidbody.AddForce(movementScript.GetHorizontalInput().normalized * pushingForce);
            //Need to figure out how to do this only when we are on the sides of the box.
            if(movementScript.GetPlayerMovementState() == PlayerMovementState.Grounded)
            {
                playerAnimator.SetBool("IsPushing", true);
            }
                
            Debug.Log(collision.GetContact(0).point.magnitude);
        }
        else
        {
            playerAnimator.SetBool("IsPushing", false);
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Magnet 
        if (collision.gameObject.layer == 12)
        {
            playerAnimator.SetBool("InMagnet", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Magnet 
        if (collision.gameObject.layer == 12)
        {
            playerAnimator.SetBool("InMagnet", false);
        }
    }

    private void PlayerDead()
    {
        playerAnimator.SetBool("isDead", true);
        playerState = PlayerState.Dead;
        GetComponent<BoxCollider2D>().enabled = false;
        playerDeathBox.enabled = true;
        movementScript.enabled = false;
    }

    public PlayerState GetPlayerState() { return playerState; }
    public void CallPlayerDead() { PlayerDead(); }
    public void SetMaxPolaritySwitches(int current) { currentPolaritySwitches = current; }
    public int GetMaxPolaritySwitches() {  return currentPolaritySwitches; }

}


public enum PlayerState
{
    Alive,
    Dead,
}
