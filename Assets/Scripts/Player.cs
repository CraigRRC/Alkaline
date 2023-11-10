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
    public int maxPolaritySwitches;

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
                maxPolaritySwitches--;
                foreach (var magnet in magnetsInLvl)
                {
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
        Debug.Log(collision.gameObject.layer);
        //Hazard
        if(collision.gameObject.layer == 10)
        {
            //die
            if(deathSprite != null)
            {
                PlayerDead();
            }

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
        movementScript.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public PlayerState GetPlayerState() { return playerState; }
    public void CallPlayerDead() { PlayerDead(); }
    public void SetMaxPolaritySwitches(int max) { maxPolaritySwitches = max; }
    public int GetMaxPolaritySwitches() {  return maxPolaritySwitches; }

}


public enum PlayerState
{
    Alive,
    Dead,
}
