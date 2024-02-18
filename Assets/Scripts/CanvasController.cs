using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject activate;
    public GameObject deactivate;

    public void trigger() {
        activate.SetActive(true);
        deactivate.SetActive(false);
    }
}
