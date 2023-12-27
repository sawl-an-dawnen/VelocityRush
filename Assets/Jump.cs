using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float force = 2000;

    private Rigidbody rigidBody;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        force = 1000 * force;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground") {
            Debug.Log("GROUNDED");
            isGrounded = true;
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

        //apply force to sphere
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rigidBody.AddForce(force * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        }
    }

    private void OnJump()
    {
        //moveInputValue = value.Get<Vector2>();
        //move = Camera.main.transform.right * moveInputValue.x + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * moveInputValue.y;
    }
}
