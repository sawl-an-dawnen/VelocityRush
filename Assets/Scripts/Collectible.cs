using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float rotationSpeed = 2f;

    public bool addPoints = false;
    public bool addLife = false;
    public bool isKey = false;

    public int pointValue = 10;
    public int numberOfLives = 1;

    public float detectionRange = 2f;
    public float moveSpeed = 5f;

    public AudioClip pickUpSound;
    private AudioSource playerSFX;

    public GameObject[] toActivate;

    PlayerManager player;
    Transform playerTransform;
    bool chasePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerSFX = GameObject.FindGameObjectWithTag("SFX-1").GetComponent<AudioSource>();
        rotationSpeed *= 10;
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up.normalized * rotationSpeed * Time.deltaTime, Space.World);

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= detectionRange) {
            chasePlayer = true;
        }
        if (chasePlayer) {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            moveSpeed = moveSpeed + 10f * Time.deltaTime;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (addPoints) {
                player.AddPoints(pointValue);
            }
            if (addLife)
            {
                player.AddLife(numberOfLives);
            }
            if (isKey) {
                Debug.Log("Unlock Door");
            }

            foreach (GameObject obj in toActivate) {
                obj.SetActive(true);
            }

            try { playerSFX.PlayOneShot(pickUpSound); }
            catch { }
            Destroy(gameObject);
        }

    }
}
