using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Dash : MonoBehaviour
{
    public float force = 3;
    public float coolDown = 8f;

    private Rigidbody rigidBody;
    private Movement movement;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        //apply force to sphere
        if (Input.GetMouseButtonDown(0) && timer <= 0f)
        {
            Action(force);
        }
    }

    private void OnDash()
    {
        if (timer <= 0f)
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
    }
}
