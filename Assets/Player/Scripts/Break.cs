using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Break : MonoBehaviour
{
    [HideInInspector]
    public bool pressed = false;
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
        pressed = false;
        if (player.isGrounded && (Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButton(1) || handBreak)) {
            Action(breakingForce);
        } 
    }

    private void OnBreak(InputValue input)
    {
        if (input.GetType() == input.GetType()) {
            handBreak = !handBreak;
        }
    }

    private void Action(float b) 
    {
        rigidBody.AddForce(b * Time.deltaTime * -rigidBody.velocity, ForceMode.Acceleration);
        pressed = true;
    }
}
