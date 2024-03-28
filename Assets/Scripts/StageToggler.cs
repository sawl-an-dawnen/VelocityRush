using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageToggler : MonoBehaviour
{
    public GameObject[] sewerLevels;
    public GameObject[] cityLevels;
    public GameObject[] skyLevels;

    private int index = 0;

    public void ToggleSelector() {
        if (index == 0)
        {
            foreach (GameObject obj in sewerLevels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in cityLevels)
            {
                obj.SetActive(true);
            }
            index++;
        }
        else if (index == 1) {
            foreach (GameObject obj in cityLevels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in skyLevels)
            {
                obj.SetActive(true);
            }
            index++;
        }
        else if (index == 2)
        {
            foreach (GameObject obj in skyLevels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in sewerLevels)
            {
                obj.SetActive(true);
            }
            index = 0;
        }
    }
}
