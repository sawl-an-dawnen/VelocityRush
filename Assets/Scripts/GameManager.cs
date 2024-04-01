using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool[] levels;
    [HideInInspector]
    public float[] records;
    public GameObject levelSelector;
    public AudioSource mainMusicSource;

    public UnityEngine.UI.Slider xAxisSlider, yAxisSlider, musicSlider, sfxSlider;

    [HideInInspector]
    public float xSens, ySens, musicVolume, sfxVolume;

    public bool xInvert, yInvert = false;
    public UnityEngine.UI.Toggle xAxisToggle, yAxisToggle;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log(levelSelector.transform.childCount);
        levels = new bool[levelSelector.transform.childCount];
        records = new float[levelSelector.transform.childCount];

        //initilize the levels array
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = false;
            records[i] = 0f;
            //Debug.Log(levels[i] + " " + i);
        }

        //load GameData
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = data.levels[i];
                records[i] = data.records[i];
            }
            xSens = data.xSens;
            ySens = data.ySens;
            musicVolume = data.musicVolume;
            mainMusicSource.volume = musicVolume * .01f;
            sfxVolume = data.sfxVolume;
        }
        else
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = false;
                records[i] = 0f;
            }
            xSens = 50f;
            ySens = 50f;
            musicVolume = 50f;
            mainMusicSource.volume = 50f * .01f;
            sfxVolume = 50f;
        }
    }

    public void CompleteLevel(int i, float t)
    {
        levels[i] = true;
        if (t < records[i] || records[i] <= 0f)
            records[i] = t;

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
            records[i] = 0f;
        }
        SaveSystem.DeleteSave();
    }

    public void DeleteLevelProgression() {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = false;
            records[i] = 0f;
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
        mainMusicSource.volume = musicVolume * .01f;
    }

    public void updateSFXVolume(UnityEngine.UI.Slider s)
    {
        sfxVolume = s.value;
        Debug.Log(sfxVolume);
    }

    public void updateInverSettings() {
        xInvert = xAxisToggle.isOn;
        yInvert = yAxisToggle.isOn;
    }
}
