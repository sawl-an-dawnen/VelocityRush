using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject levelSelect;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ActivateLevelSelection() {
        titleScreen.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void DeactivateLevelSelection() {
        titleScreen.SetActive(true);
        levelSelect.SetActive(false);
    }
}
