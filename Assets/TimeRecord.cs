using TMPro;
using UnityEngine;

public class TimeRecord : MonoBehaviour
{
    public int levelIndex;
    public bool total = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<TextMeshProUGUI>().text = UpdateTimerDisplay(gameManager.records[levelIndex-1]);
        if (total) {
            float totalTime = 0f;
            for (int i = 0; i < gameManager.records.Length; i++) {
                totalTime += gameManager.records[i];
            }
            gameObject.GetComponent<TextMeshProUGUI>().text = UpdateTimerDisplay(totalTime);
        }
    }

    public void Reset()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "00:00:00";
    }

    private string UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        string currentTime = string.Format("{00:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        return currentTime;
        //firstMinute.text = currentTime[0].ToString();
        //secondMinute.text = currentTime[1].ToString();
        //firstSecond.text = currentTime[2].ToString();
        //secondSecond.text = currentTime[3].ToString();
        //firstMilli.text = currentTime[4].ToString();
        //secondMilli.text = currentTime[5].ToString();
    }
}
