using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class DeleteDataButton : MonoBehaviour
{
    public Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Reset);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Reset()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject obj in buttons)
        {
            obj.GetComponent<EnableLevel>().Reset();
            Debug.Log("Button Reset");
        }
        gameManager.DeleteLevelProgression();
    }
}
