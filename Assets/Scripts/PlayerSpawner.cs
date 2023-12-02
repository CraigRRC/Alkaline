using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public Player playerPrefab;
    private Player playerSpawned;
    //can be refactored later to be dynamic.
    public List<Magnet> magnetsInLvl;
    public BoxCollider2D doorCollider;
    public Unlock[] keysToActivateDoor;
    private bool doorUnlocker = false;
    private int maxKeys = 0;
    public Text levelNumber;

    //Temp UI stuff
    public Animator keysAnimator;
    public bool keyDisplay_WASD = false;
    public bool keyDisplay_SPACE = false;
    public bool keyDisplay_E = false;
    public bool keyDisplay_R = false;
    public bool keyDisplay_F = false;


    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.transform.localScale = this.transform.localScale;
        playerSpawned.GetComponent<PlayerMovement>().setPlayerMovement(transform.localScale.x);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        maxKeys = keysToActivateDoor.Length;
        if(levelNumber != null )
            levelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void Update()
    {
        if (playerSpawned.GetPlayerState() == PlayerState.Dead)
        {
            playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        }

        int activeKeys = 0;
        if (keysToActivateDoor != null)
        {
            foreach (Unlock temp in keysToActivateDoor)
            {
                if (temp == null) return;
                if (temp.IsActive())
                {
                    activeKeys++;
                }
                else
                {
                    activeKeys--;
                }
                //Debug.Log("temp  " + temp);
                //Debug.Log("active  " + temp.IsActive());
            }
            //Debug.Log("active keys " + activeKeys);
            //Debug.Log("max keys " + maxKeys);
        }

        if (doorCollider != null)
        {
            doorCollider.enabled = activeKeys == maxKeys;
        }



        //Temp UI controller
        if(keysAnimator != null)
        {
            if (keyDisplay_WASD)
            {
                keysAnimator.SetBool("Move", true);
            }
            else if (keyDisplay_SPACE)
            {
                keysAnimator.SetBool("Jump", true);
            }
            else if (keyDisplay_E)
            {
                keysAnimator.SetBool("Polarity", true);
            }
            else if(keyDisplay_R)
            {
                keysAnimator.SetBool("Reset", true);
            }
            else if (keyDisplay_F)
            {
                keysAnimator.SetBool("Interact", true);
            }
        }
        

    }
}
