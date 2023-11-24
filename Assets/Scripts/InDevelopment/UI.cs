using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//Class that will be used to handle the UI for the player
//Changes to the UI will be made dynamically and persist.
//Needs to handle various things like the battery meter, and the logs that have been acquired.
public class UI : MonoBehaviour
{
    public Image[] powerCells;
    public PlayerSpawner levelManager;
    private Player playerSpawned;
    private int ticPosition = 0;
    private int liveTics = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
         
        
       
    }

    private void Start()
    {
       // Initialize those cached objects?
    }

    private void PowerDrain()
    {
        Debug.Log("inPowerDrain");
        //Check if the array is null
        if (powerCells == null)
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
        powerCells[ticPosition].enabled = false;
        //Reset tic counter.
        liveTics = 0;
        //Check how many tics remain
        foreach (var tic in powerCells)
        {
            liveTics += tic.enabled ? 1 : 0;
        }
        if (liveTics == 0)
        {
            //I dunno man.
            foreach (var magnet in playerSpawned.magnetsInLvl)
            {
                magnet.TurnMagnetOff();
            }
        }
        else
        {
            ticPosition++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<PlayerSpawner>();
            playerSpawned = FindObjectOfType<Player>();
            playerSpawned.OnSwitchPolarity += PowerDrain;
        }
    }


    private void OnDisable()
    {
        playerSpawned.OnSwitchPolarity -= PowerDrain;
    }

    //OnPlayerDeath disable onSwitchpolarity.
}
