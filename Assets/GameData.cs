using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool[] levels;

    public GameData(GameManager gameManager) 
    {
        levels = new bool[gameManager.levels.Length];
        for (int i = 0; i < gameManager.levels.Length; i++)
        {
            levels[i] = gameManager.levels[i];
        }
    }
}