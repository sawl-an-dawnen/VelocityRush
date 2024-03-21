using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    public enum PromptID { One, Two, Three }

    public GameObject toCollect; //objects to collect
    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public GameObject[] toDelete;

    public PromptID promptID;

    private TextMeshProUGUI prompt;

    void Start() {
        switch (promptID) {
            case PromptID.One:
                prompt = GameObject.FindGameObjectWithTag("Prompt01").GetComponent<TextMeshProUGUI>();
                break;
            case PromptID.Two:
                prompt = GameObject.FindGameObjectWithTag("Prompt02").GetComponent<TextMeshProUGUI>(); 
                break;
            case PromptID.Three:
                prompt = GameObject.FindGameObjectWithTag("Prompt03").GetComponent<TextMeshProUGUI>(); 
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (toCollect.transform.childCount == 0)
        {
            prompt.text = "ALL POINTS COLLECTED!";
            foreach (GameObject obj in toActive)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in toDelete)
            {
                Destroy(obj);
            }
            Destroy(this);
        }
        else {
            if (toCollect.transform.childCount == 1) 
            {
                prompt.text = 1 + " POINT LEFT TO COLLECT!";
                return;
            }
            prompt.text = toCollect.transform.childCount + " POINTS LEFT TO COLLECT!";
        }
    }
}
