using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject activate;
    public GameObject deactivate;
    public GameObject firstSelected;
    public EventSystem eventSystem;

    public void Trigger() {
        activate.SetActive(true);
        deactivate.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelected);
    }
}
