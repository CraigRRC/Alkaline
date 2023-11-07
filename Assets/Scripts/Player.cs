using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Magnet[] magnetsInLvl;
    private PlayerMovement movementScript;
    public Sprite deathSprite;
    private Animator playerAnimator;
    private PlayerState playerState = PlayerState.Alive;

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
                foreach (var magnet in magnetsInLvl)
                {
                    magnet.FlipPolarity();
                }
               
            }
        }

        if(playerState == PlayerState.Dead)
        {
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            //die
            if(deathSprite != null)
            {
                playerAnimator.SetBool("isDead", true);
                playerState = PlayerState.Dead;
                movementScript.enabled = false;
            }
            
        }
        
    }

    public PlayerState GetPlayerState() { return playerState; }

}


public enum PlayerState
{
    Alive,
    Dead,
}
