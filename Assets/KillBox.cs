using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    PlayerManager playerManager;
    SpawnManager spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        spawnManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            playerManager.SubLife();
            spawnManager.Respawn();
        }
    }

}
