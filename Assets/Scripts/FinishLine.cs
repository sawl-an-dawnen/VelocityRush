using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string nextLevel;
    private SceneLoader sceneLoader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            sceneLoader = GetComponent<SceneLoader>();
            sceneLoader.LoadScene(nextLevel);
        }
    }
}
