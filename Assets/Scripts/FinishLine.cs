using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string nextLevel;
    private SceneLoader sceneLoader;
    private GameManager gameManager;
    private LevelManager levelManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            gameManager.CompleteLevel(levelManager.levelIndex - 1);
            Debug.Log(gameManager.levels[levelManager.levelIndex - 1]);
            sceneLoader = GetComponent<SceneLoader>();
            sceneLoader.LoadScene(nextLevel);
        }
    }
}
