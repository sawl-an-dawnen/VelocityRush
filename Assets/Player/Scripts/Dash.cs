using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Dash : MonoBehaviour
{
    [HideInInspector]
    public bool pressed = false;
    public float force = 3f;
    public float coolDown = 8f;

    private PlayerManager player;
    private Rigidbody rigidBody;
    private Movement movement;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerManager>();
        rigidBody = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        pressed = false;
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        //apply force to sphere
        if (Input.GetMouseButtonDown(0) && timer <= 0f && player.canDash)
        {
            Action(force);
        }
    }

    private void OnDash()
    {
        if (timer <= 0f && player.canDash)
        {
            Action(force);
        }
    }

    private void Action(float f)
    {
        if (movement.move == Vector3.zero) {
            return;
        }
        rigidBody.AddForce(movement.move * f, ForceMode.Impulse);
        timer = coolDown;
        pressed = true;
    }
}
