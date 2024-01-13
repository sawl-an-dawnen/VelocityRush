using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPad : MonoBehaviour
{
    public float force;
    public bool muteMomentum = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (muteMomentum)
            {
                rb.velocity = Vector3.zero;
            }

            rb.AddForce(force * Time.deltaTime * gameObject.transform.forward, ForceMode.Impulse);
        }
    }
}
