using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Player playerPrefab;
    private Player playerSpawned;
    //can be refactored later to be dynamic.
    public List<Magnet> magnetsInLvl;
    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        
    }

    private void Update()
    {
        if(playerSpawned.GetPlayerState() == PlayerState.Dead)
        {
            playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            playerSpawned.magnetsInLvl = magnetsInLvl.ToArray();
        }
    }
}
