using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool[] levels;
    public GameObject levelSelector;

    public Slider xAxisSlider, yAxisSlider, musicSlider, sfxSlider;

    [HideInInspector]
    public float xSens, ySens, musicVolume, sfxVolume;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(levelSelector.transform.childCount);
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
            sfxVolume = data.sfxVolume;
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
