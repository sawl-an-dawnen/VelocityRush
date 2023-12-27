using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float force = 5;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //apply force to sphere
        if (Input.GetKeyDown(KeyCode.Space)) 
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
