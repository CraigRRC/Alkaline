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
    private int batteryCounter = 0;
    public int liveTics;
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
            //Do something when no tics remain.
            Debug.Log("Dead");
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
