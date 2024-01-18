using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public bool isGrounded = false;
    public bool gravity = true;
    public bool canJump = true;
    public bool canDash = true;
    public bool canShiftGravity = true;

    private int lives = 3;
    private int points = 0;
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
            //Debug.Log("GROUNDED");
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground")
        {
            //Debug.Log("NOT GROUNDED");
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(maxVelocity);
        if (rigidBody.velocity.magnitude > maxVelocity) {
            maxVelocity = rigidBody.velocity.magnitude;
        }

        if (lives <= 0) {
            Debug.Log("Game Over");
        }
    }

    public void SubLife() {
        --lives;
    }

    public void AddLife(int l) {
        lives += l;
    }

    public int AddPoints(int p) {
        points += p;
        //Debug.Log(points);
        return points;
    }

    public void InvertGravity() {
        gravity = !gravity;
    }

    public void ActivateJump() {
        canJump = true;
    }
    public void DeactivateJump() {
        canJump = false;
    }
    public void ActivateDash()
    {
        canDash = true;
    }
    public void DeactivateDash()
    {
        canDash = false;
    }
    public void ActivateGravityShift()
    {
        canShiftGravity = true;
    }
    public void DeactivateGravityShift()
    {
        canShiftGravity = false;
    }
}
