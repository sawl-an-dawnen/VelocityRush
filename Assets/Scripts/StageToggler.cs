using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageToggler : MonoBehaviour
{
    public GameObject[] sewerLevels;
    public GameObject[] cityLevels;

    bool sewerActive = true;
    bool cityActive = false;
    bool skyActive = false;

    public void ToggleSelector() {
        if (sewerActive)
        {
            foreach (GameObject obj in sewerLevels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in cityLevels)
            {
                obj.SetActive(true);
            }
            cityActive = true;
            sewerActive = false;
        }
        else {
            foreach (GameObject obj in cityLevels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in sewerLevels)
            {
                obj.SetActive(true);
            }
            cityActive = false;
            sewerActive = true;
        }
    }
}
