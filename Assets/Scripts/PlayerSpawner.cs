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
    public NumOfPolaritySwitches polaritySwitchState;
    public TextMeshProUGUI powerCellCount;
    //can be refactored later to be dynamic.
    public List<Magnet> magnetsInLvl;
    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        if (polaritySwitchState == NumOfPolaritySwitches.Finite)
        {
            powerCellCount.text = numOfPolaritySwitches.ToString();
            playerSpawned.SetMaxPolaritySwitches(numOfPolaritySwitches);
        }
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
            if(polaritySwitchState == NumOfPolaritySwitches.Finite)
            {
                if (playerSpawned.GetMaxPolaritySwitches() < 0)
                {
                    powerCellCount.text = numOfPolaritySwitches.ToString();
                    playerSpawned.CallPlayerDead();
                }
                else
                {
                    powerCellCount.text = playerSpawned.GetMaxPolaritySwitches().ToString();
                }
            }
        }
    }

    public enum NumOfPolaritySwitches
    {
        Infinite,
        Finite,
    }
}
