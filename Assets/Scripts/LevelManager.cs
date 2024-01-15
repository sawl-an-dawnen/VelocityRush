using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelIndex;
    public bool jump = false;
    public bool dash = false;
    public bool gravityShift = false;
    public AudioClip levelMusic;

    private PlayerManager player;
    private AudioSource gameMusic;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameMusic = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>();

        if (levelMusic != null) {
            gameMusic.Stop();
            gameMusic.clip = levelMusic;
            gameMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump) {
            player.DeactivateJump();
        }
        if (!dash)
        {
            player.DeactivateDash();
        }
        if (!gravityShift)
        {
            player.DeactivateGravityShift();
        }
    }
}
