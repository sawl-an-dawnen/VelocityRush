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
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        time = TimeSpan.FromSeconds(timer);

        timerUI.text = time.ToString("mm':'ss");

        if ((timer >= timeLimit && timeTrialMode) || timer >= 3600f) 
        {
            gameObject.GetComponent<SceneLoader>().LoadScene();
        }
    }
}
