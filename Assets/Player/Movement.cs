using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float acceleration = 5f;
    public float airTimeReduction = .5f;
    public float gForce = 5f;
    [HideInInspector]
    public Vector3 move;
    private Rigidbody rigidBody;
    private float moveX;
    private float moveZ;
    private Vector2 moveInputValue;
    private PlayerManager player;
    
    

    // Start is called before the first frame update
    void Start()
    {
        acceleration = acceleration * 100;
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the inputs for left right forward backwards
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //create the vector for movement relative to the camera direction
        move = Camera.main.transform.right * moveX + new Vector3(Camera.main.transform.forward.x, 0f,Camera.main.transform.forward.z) * moveZ;
        //Debug.Log(Camera.main.transform.forward);

        //normalize so we only have the direction the player wants to move in relative to the camera,
        //this ensures that we don't add up vectors and have magnitues larger than 1 when we press horizontal and vertical movemen
        move = move.normalized;

        //Debug.Log(Camera.main.transform.forward);
        //apply force to sphere
        if (player.isGrounded)
        {
            Action(acceleration);
        }
        else {
            Action(acceleration * airTimeReduction);
        }
        rigidBody.AddForce(gForce * Time.deltaTime * Vector3.down, ForceMode.Acceleration);
    }

    private void OnMove(InputValue value) {
        moveInputValue = value.Get<Vector2>();
        move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
    }

    private void Action(float a) 
    {
        rigidBody.AddForce(a * Time.deltaTime * move, ForceMode.Acceleration);
    }
}
