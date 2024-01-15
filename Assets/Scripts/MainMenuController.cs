using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject levelSelect;


    public void ActivateLevelSelection() {
        titleScreen.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void DeactivateLevelSelection() {
        titleScreen.SetActive(true);
        levelSelect.SetActive(false);
    }
}
