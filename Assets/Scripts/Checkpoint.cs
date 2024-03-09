using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioClip checkpointSound;
    private AudioSource audioSource;
    private SpawnManager spawnManager;
    private PlayerManager playerManager;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        spawnManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnManager>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(checkpointSound);
            spawnManager.SetCheckPoint(gameObject);
            playerManager.AddLife(1);
            Destroy(gameObject.GetComponent<MeshCollider>());
        }
    }
}
