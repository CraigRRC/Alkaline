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
    public int numOfPolaritySwitches;
    public SpriteRenderer[] powerCells;
    //can be refactored later to be dynamic.
    public List<Magnet> magnetsInLvl;
    public BoxCollider2D doorCollider;
    public Unlock[] keysToActivateDoor;
    private bool doorUnlocker = false;
    private int maxKeys = 0;
    private int batteryCounter = 0;
    public int liveTics;
    public Text levelNumber;

    //Temp UI stuff
    public Animator keysAnimator;
    public bool keyDisplay_WASD = false;
    public bool keyDisplay_SPACE = false;
    public bool keyDisplay_E = false;
    public bool keyDisplay_R = false;


    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.transform.localScale = this.transform.localScale;
        playerSpawned.GetComponent<PlayerMovement>().setPlayerMovement(transform.localScale.x);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        playerSpawned.SetMaxPolaritySwitches(numOfPolaritySwitches);
        maxKeys = keysToActivateDoor.Length;
        if(levelNumber != null )
            levelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void Start()
    {
        playerSpawned.OnSwitchPolarity += PowerDrain;
    }

    private void OnDisable()
    {
        playerSpawned.OnSwitchPolarity -= PowerDrain;
    }

    private void PowerDrain()
    {
        //Check if the array is null
        if(powerCells == null)
        {
            Debug.LogWarning("Powercells is null");
            return;
        }
        //Check if the array is blank.
        foreach (var tic in powerCells)
        {
            if (tic == null)
            {
                Debug.LogWarning("PowerCells Array Empty.");
                return;
            }
        }

        //Power off a tic
        powerCells[batteryCounter].enabled = false;
        //Reset tic counter.
        liveTics = 0;
        //Check how many tics remain
        foreach (var tic in powerCells)
        {
            liveTics += tic.enabled ? 1 : 0;
        }
        if(liveTics == 0)
        {
            //I dunno man.
            foreach (var magnet in playerSpawned.magnetsInLvl)
            {
                magnet.TurnMagnetOff();
            }
        }
        else
        {
            batteryCounter++;
        }
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
        }
        

    }






}
