using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public GameObject toCollect; //objects to collect
    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public bool usesKey = false;
    public GameObject key;

    // Update is called once per frame
    void Update()
    {
        if (toCollect.transform.childCount == 0 || (usesKey == true && key == null)) {
            foreach (GameObject obj in toActive) {
                obj.SetActive(true);
            }
        }
    }
}
