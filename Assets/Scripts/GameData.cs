using Unity.Profiling;

[System.Serializable]
public class GameData
{
    public bool[] levels;
    public float[] records;
    public float xSens, ySens, musicVolume, sfxVolume;

    public GameData(GameManager gameManager) 
    {
        levels = new bool[gameManager.levels.Length];
        records = new float[gameManager.levels.Length];

        for (int i = 0; i < gameManager.levels.Length; i++)
        {
            levels[i] = gameManager.levels[i];
            records[i] = gameManager.records[i];
        }
        xSens = gameManager.xSens;
        ySens = gameManager.ySens;
        musicVolume = gameManager.musicVolume;
        sfxVolume = gameManager.sfxVolume;
    }
}
