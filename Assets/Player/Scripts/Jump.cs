using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [HideInInspector]
    public bool pressed = false;
    public float force = 10f;
    public float gracePeriod = .05f;
    private float timer;
    private Rigidbody rigidBody;
    private PlayerManager player;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground")
        {
            pressed = false;
            timer = gracePeriod;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        }
        //apply force to sphere
        if (Input.GetKeyDown(KeyCode.Space) && (player.isGrounded || timer > 0) && player.canJump) 
        {
            Action(force);
        }
    }

    private void OnJump()
    {
        //moveInputValue = value.Get<Vector2>();
        //move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
        if ((player.isGrounded || timer > 0) && player.canJump) {
           Action(force);
           pressed = true;
        }
    }

    private void Action(float f) {
        pressed = true;
        timer = 0f;
        if (player.gravity) { rigidBody.AddForce(Vector3.up * f, ForceMode.Impulse); }
        else { rigidBody.AddForce(Vector3.down * f, ForceMode.Impulse); }
    }
}
