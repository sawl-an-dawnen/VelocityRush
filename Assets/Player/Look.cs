using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{

    private Vector2 lookInputValue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
    }

    private void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
        //Debug.Log(lookInputValue);
    }

}
