using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool[] levels;
    public GameObject levelSelector;

    // Start is called before the first frame update
    void Start()
    {
        levels = new bool[levelSelector.transform.childCount];

        //initilize the levels array
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = false;
            //Debug.Log(levels[i] + " " + i);
        }

        //load GameData
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = data.levels[i];
            }
        }
    }

    public void CompleteLevel(int i)
    {
        levels[i] = true;

        //save level completion
        SaveSystem.SaveGame(this);
    }

    public void DeleteSave()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = false;
            //Debug.Log(levels[i] + " " + i);
        }
        SaveSystem.DeleteSave();
    }

}