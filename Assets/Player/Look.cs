using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Look : MonoBehaviour
{
    public CinemachineFreeLook camera;
    public float speedWarpModifier = .5f;
    private Vector2 lookInputValue;
    private Rigidbody rigidBody;
    private float defaultPOV;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidBody = GetComponent<Rigidbody>();
        defaultPOV = camera.m_Lens.FieldOfView;
    }

    private void Update()
    {
        //camera.m_Lens.FieldOfView = defaultPOV + (rigidBody.velocity.magnitude * speedWarpModifier);
        camera.m_Lens.FieldOfView = Mathf.Lerp(defaultPOV, defaultPOV * speedWarpModifier, Mathf.InverseLerp(5f, 100f, rigidBody.velocity.magnitude));
    }

    private void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
        //Debug.Log(lookInputValue);
    }

}
