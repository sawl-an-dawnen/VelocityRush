using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float acceleration = 5f;
    private Transform player;
    private Vector3 move;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(transform.position, player.position, Color.red);
        move = (player.position - transform.position).normalized;
        //Debug.Log(move);
        rigidBody.AddForce(acceleration * Time.deltaTime * move, ForceMode.Acceleration);
    }

}
