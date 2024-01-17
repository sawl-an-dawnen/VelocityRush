using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Look : MonoBehaviour
{
    public CinemachineFreeLook freeCam;
    public float midRigHeight = 3f;
    public float velocityCenterLimit = 10f;
    public float speedWarpModifier = .5f;
    private Vector2 lookInputValue;
    private Rigidbody rigidBody;
    private float defaultPOV;
    private PlayerManager player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidBody = GetComponent<Rigidbody>();
        defaultPOV = freeCam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        //camera.m_Lens.FieldOfView = defaultPOV + (rigidBody.velocity.magnitude * speedWarpModifier);
        freeCam.m_Lens.FieldOfView = Mathf.Lerp(defaultPOV, defaultPOV * speedWarpModifier, Mathf.InverseLerp(5f, 100f, rigidBody.velocity.magnitude));

        if (rigidBody.velocity.magnitude >= velocityCenterLimit)
        {
            freeCam.m_RecenterToTargetHeading.m_enabled = true;
        }
        else 
        {
            freeCam.m_RecenterToTargetHeading.m_enabled = false;
        }

        if (player.gravity)
        {
            freeCam.m_Orbits[1].m_Height = midRigHeight; // MiddleRig
        }
        else 
        {
            freeCam.m_Orbits[1].m_Height = -midRigHeight; // MiddleRig
        }
    }

    private void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
        //Debug.Log(lookInputValue);
    }

}