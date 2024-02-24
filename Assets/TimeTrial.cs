using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    public float timeLimit;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= timeLimit) { 
            //game over, reset level
        }
    }
}
