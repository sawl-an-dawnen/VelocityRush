using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    public bool timeTrialMode = false;
    public float timeLimit;
    private float timer = 0f;
    private TextMeshProUGUI timerUI;
    TimeSpan time;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        //Debug.Log(UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset.GetType().Name);
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerUI.text = UpdateTimerDisplay(timer);

        if ((timer >= timeLimit && timeTrialMode) || timer >= 3600f)
        {
            gameObject.GetComponent<SceneLoader>().LoadScene(); //gameover
        }
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
