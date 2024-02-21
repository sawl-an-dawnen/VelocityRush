using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSlider : MonoBehaviour
{

    public string targetSetting;
    private GameManager gameManager;
    private UnityEngine.UI.Slider s;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        s = GetComponent<UnityEngine.UI.Slider>();

        switch (targetSetting) {
            case "xSens":
                s.value = gameManager.xSens;
                break;
            case "ySens":
                s.value = gameManager.ySens;
                break;
            case "musicVolume":
                s.value = gameManager.musicVolume;
                break;
            case "sfxVolume":
                s.value = gameManager.sfxVolume;
                break;
            default:
                s.value = 50f;
                break;
        }


    }
}
