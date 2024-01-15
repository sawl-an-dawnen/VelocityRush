using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableLevel : MonoBehaviour
{


    public int levelIndex;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Debug.Log(gameManager.levels[levelIndex - 1]);
        if (gameManager.levels[levelIndex - 1] == true) {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
