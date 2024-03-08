using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    PlayerManager playerManager;
    SpawnManager spawnManager;

    AudioSource audioSource;
    public AudioClip deathSound;


    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        spawnManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnManager>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            audioSource.PlayOneShot(deathSound);
            playerManager.SubLife();
            spawnManager.Respawn();
        }
    }

}
