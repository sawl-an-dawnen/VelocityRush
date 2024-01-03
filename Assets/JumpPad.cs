using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    public float force;
    public bool muteMomentum = false;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (muteMomentum) {
            rb.velocity = Vector3.zero;
        }

        rb.AddForce(force * Time.deltaTime * Vector3.up, ForceMode.Impulse);
    }
}
