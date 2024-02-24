using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool[] levels;
    public GameObject levelSelector;
    public AudioSource mainMusicSource;

    public UnityEngine.UI.Slider xAxisSlider, yAxisSlider, musicSlider, sfxSlider;

    [HideInInspector]
    public float xSens, ySens, musicVolume, sfxVolume;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log(levelSelector.transform.childCount);
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
            xSens = data.xSens;
            ySens = data.ySens;
            musicVolume = data.musicVolume;
            mainMusicSource.volume = musicVolume * .01f;
            sfxVolume = data.sfxVolume;
        }
    }

    public void CompleteLevel(int i)
    {
        levels[i] = true;

        //save level completion
        SaveSystem.SaveGame(this);
    }

    public void SaveSettings()
    {
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

    public void DeleteLevelProgression() {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = false;
            //Debug.Log(levels[i] + " " + i);
        }
        SaveSystem.SaveGame(this);
    }

    public void DeletePlayerSettings()
    {
        xSens = 50f;
        ySens = 50f;
        musicVolume = 50f;
        mainMusicSource.volume = .5f;
        sfxVolume = 50f;
        xAxisSlider.value = 50f;
        yAxisSlider.value = 50f;
        musicSlider.value = 50;
        sfxSlider.value = 50f;
        SaveSystem.SaveGame(this);
    }

    public void updateXSense(UnityEngine.UI.Slider s)
    {
        xSens = s.value;
        Debug.Log(xSens);
    }

    public void updateYSense(UnityEngine.UI.Slider s)
    {
        ySens = s.value;
        Debug.Log(ySens);
    }

    public void updateMusicVolume(UnityEngine.UI.Slider s)
    {
        musicVolume = s.value;
        Debug.Log(musicVolume);
        mainMusicSource.volume = musicVolume*.01f;
    }

    public void updateSFXVolume(UnityEngine.UI.Slider s)
    {
        sfxVolume = s.value;
        Debug.Log(sfxVolume);
    }
}
