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
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground") {
            Debug.Log("GROUNDED");
            isGrounded = true;
            timer = gracePeriod;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground")
        {
            Debug.Log("NOT GROUNDED");
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        }
        //apply force to sphere
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || timer > 0)) 
        {
            timer = 0f;
            Action(force);
        }
    }

    private void OnJump()
    {
        //moveInputValue = value.Get<Vector2>();
        //move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
        if (isGrounded || timer > 0) {
            timer = 0f;
            Action(force);
        }
    }

    private void Action(float f) {
        rigidBody.AddForce(Vector3.up * f, ForceMode.Impulse);
    }
}
