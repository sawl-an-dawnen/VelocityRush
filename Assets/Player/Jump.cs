using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space) && (player.isGrounded || timer > 0)) 
        {
            Action(force);
        }
    }

    private void OnJump()
    {
        //moveInputValue = value.Get<Vector2>();
        //move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
        if (player.isGrounded || timer > 0) {
            Action(force);
        }
    }

    private void Action(float f) {
        timer = 0f;
        rigidBody.AddForce(Vector3.up * f, ForceMode.Impulse);
    }
}
