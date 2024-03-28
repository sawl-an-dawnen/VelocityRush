using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public enum Mode
    {
        Reset,
        Passthrough
    }

    public Mode mode;
    public int lives;

    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        if (mode == Mode.Reset)
        {
            playerManager.SetLives(lives);
        }
        else
        {
            playerManager.AddLife(lives);
        }
    }
}
