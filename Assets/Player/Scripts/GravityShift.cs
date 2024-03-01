using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityShift : MonoBehaviour
{
    public bool pressed = false;
    public float gForce = 1000f;

    private PlayerManager player;
    private Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerManager>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pressed = false;
        if (Input.GetKeyDown(KeyCode.E) && player.canShiftGravity)
        {
            player.InvertGravity();
            pressed = true;
        }

        if (player.gravity)
        {
            rigidBody.AddForce(gForce * Time.deltaTime * Vector3.down, ForceMode.Acceleration);
        }
        else
        {
            rigidBody.AddForce(gForce * 2.0f * Time.deltaTime * Vector3.up, ForceMode.Acceleration);
        }
    }

    private void OnGravityShift()
    {
        if (player.canShiftGravity) 
        { 
            player.InvertGravity();
            pressed = true;
        }
    }


}
