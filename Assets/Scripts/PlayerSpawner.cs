using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Player playerPrefab;
    private Player playerSpawned;
    private void Awake()
    {
        playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(playerSpawned.GetPlayerState() == PlayerState.Dead)
        {
            playerSpawned = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
    }
}
