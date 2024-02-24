using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public GameObject[] toDelete;

    // Update is called once per frame
    void OnTriggerEnter()
    {
        foreach (GameObject obj in toActive)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in toDelete)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
