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
        prompt.text = toCollect.transform.childCount + " left to collect!";
        if (toCollect.transform.childCount == 0)
        {
            prompt.text = "All points collected!";
            foreach (GameObject obj in toActive)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in toDelete)
            {
                Destroy(obj);
            }
        }
        else {
            prompt.text = toCollect.transform.childCount + " left to collect!";
        }
    }
}
