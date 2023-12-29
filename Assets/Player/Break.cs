using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Break : MonoBehaviour
{
    public float breakingForce = 25f;
    private Rigidbody rigidBody;
    private PlayerManager player;
    private bool handBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerManager>();
        breakingForce *= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded && (Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButtonDown(1) || handBreak)) {
            Action(breakingForce);
        } 
    }


    int i = 0;
    private void OnBreak(InputValue input)
    {
        if (input.GetType() == input.GetType()) {
            handBreak = !handBreak;
        }
    }

    private void Action(float b) 
    {
        rigidBody.AddForce(b * Time.deltaTime * -rigidBody.velocity, ForceMode.Acceleration);
    }
}