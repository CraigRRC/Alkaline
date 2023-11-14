using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public Player playerPrefab;
    private Player playerSpawned;
    public int numOfPolaritySwitches;
    public TextMeshProUGUI powerCellCount;
    //can be refactored later to be dynamic.
    public List<Magnet> magnetsInLvl;
    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        if(powerCellCount != null )
            powerCellCount.text = numOfPolaritySwitches.ToString();
        playerSpawned.SetMaxPolaritySwitches(numOfPolaritySwitches);
        
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
            if(powerCellCount != null)
            {
                powerCellCount.text = playerSpawned.GetMaxPolaritySwitches().ToString();
            }
            //Do something in relation to score
        }
    }
}
