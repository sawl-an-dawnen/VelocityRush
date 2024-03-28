using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxAudioSetting : MonoBehaviour
{
    public float offset = 0f;
    private GameManager gameManager;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = (gameManager.sfxVolume * 0.01f) - (offset * 0.01f);
    }
}
