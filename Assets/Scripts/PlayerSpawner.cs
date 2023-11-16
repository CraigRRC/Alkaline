using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        playerSpawned.SetMaxPolaritySwitches(numOfPolaritySwitches);
        maxKeys = keysToActivateDoor.Length;
    }

    private void Start()
    {
        playerSpawned.OnSwitchPolarity += PowerDrain;
    }

    private void PowerDrain()
    {
        //Power off a tic
        //Check how many tics remain
        //Do something when no tics remain.
    }

    private void Update()
    {

        if (playerSpawned.GetPlayerState() == PlayerState.Dead)
        {
            playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        }
        else
        {
            //Do something in relation to score
        }
        int activeKeys = 0;
        foreach (Unlock temp in keysToActivateDoor)
        {
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
        if (activeKeys == maxKeys)
        {
            doorCollider.enabled = true;
        }
        else
        {
            doorCollider.enabled = false;
        }
    }


}
