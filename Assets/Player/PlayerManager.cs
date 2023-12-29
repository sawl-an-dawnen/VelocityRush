using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public bool isGrounded = false;

    private Rigidbody rigidBody;

    private float maxVelocity = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground")
        {
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
        Debug.Log(maxVelocity);
        if (rigidBody.velocity.magnitude > maxVelocity) {
            maxVelocity = rigidBody.velocity.magnitude;
        }
    }
}
