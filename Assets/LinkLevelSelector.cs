using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkLevelSelector : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.levelSelector = this.gameObject;
    }

}
