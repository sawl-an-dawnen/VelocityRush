using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public enum PromptID { One, Two, Three }

    public int levelIndex;
    public bool jump = false;
    public bool dash = false;
    public bool gravityShift = false;
    public AudioClip levelMusic;

    public bool prompted = false;
    public PromptID promptID;
    public string objective;

    private TextMeshProUGUI prompt;
    private PlayerManager player;
    private AudioSource gameMusic;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameMusic = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>();

        if (levelMusic != null && gameMusic.clip != levelMusic) {
            gameMusic.Stop();
            gameMusic.clip = levelMusic;
            gameMusic.Play();
        }

        if (prompted)
        {
            switch (promptID)
            {
                case PromptID.One:
                    prompt = GameObject.FindGameObjectWithTag("Prompt01").GetComponent<TextMeshProUGUI>();
                    Debug.Log("Prompt connected 01!");
                    break;
                case PromptID.Two:
                    prompt = GameObject.FindGameObjectWithTag("Prompt02").GetComponent<TextMeshProUGUI>();
                    Debug.Log("Prompt connected 02!");
                    break;
                case PromptID.Three:
                    prompt = GameObject.FindGameObjectWithTag("Prompt03").GetComponent<TextMeshProUGUI>();
                    Debug.Log("Prompt connected 03!");
                    break;
            }
            prompt.text = objective;
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
