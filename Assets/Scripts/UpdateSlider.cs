using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSlider : MonoBehaviour
{

    public string targetSetting;
    private GameManager gameManager;
    private AudioSource mainMusicSource;
    private UnityEngine.UI.Slider s;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        mainMusicSource = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>();
        s = GetComponent<UnityEngine.UI.Slider>();

        switch (targetSetting)
        {
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

    public void updateXSense(UnityEngine.UI.Slider s)
    {
        gameManager.xSens = s.value;
    }

    public void updateYSense(UnityEngine.UI.Slider s)
    {
        gameManager.ySens = s.value;
    }

    public void updateMusicVolume(UnityEngine.UI.Slider s)
    {
        gameManager.musicVolume = s.value;
        mainMusicSource.volume = gameManager.musicVolume * .01f;
    }

    public void updateSFXVolume(UnityEngine.UI.Slider s)
    {
        gameManager.sfxVolume = s.value;
    }
}
