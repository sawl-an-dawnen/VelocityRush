using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float acceleration = 5f;
    [Range(0f,100f)]
    public float airTimeReduction = 20f;
    [HideInInspector]
    public Vector3 move;
    private Rigidbody rigidBody;
    private float moveX;
    private float moveZ;
    private Vector2 moveInputValue;
    private PlayerManager player;
    private AudioSource rollingSound;
    private GameManager gameManager;
 
    // Start is called before the first frame update
    void Start()
    {
        acceleration = acceleration * 100;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.maxAngularVelocity = float.MaxValue;
        player = GetComponent<PlayerManager>();
        rollingSound = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded) 
        {
            try
            {
                rollingSound.volume = Mathf.Clamp(rigidBody.velocity.magnitude / 60f, 0f, gameManager.sfxVolume * 0.01f);
            }
            catch 
            {
                Debug.Log("No GameManager");
                rollingSound.volume = Mathf.Clamp(rigidBody.velocity.magnitude / 60f, 0f, 1f);

            }


        }
        else 
        {
            rollingSound.volume = 0f;
        }

        //Get the inputs for left right forward backwards
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //create the vector for movement relative to the camera direction
        move = Camera.main.transform.right * moveX + new Vector3(Camera.main.transform.forward.x, 0f,Camera.main.transform.forward.z) * moveZ;

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
            Action(acceleration * (100f-airTimeReduction) * 0.01f);
        }

    }

    private void OnMove(InputValue value) {
        moveInputValue = value.Get<Vector2>();
        move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
    }

    private void Action(float a) 
    {
        rigidBody.AddForce(a * Time.deltaTime * move, ForceMode.Acceleration);
    }

    public void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.collider.name);
    }
}
