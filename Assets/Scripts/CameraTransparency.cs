using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparency : MonoBehaviour
{

    private GameObject player;
    private MeshRenderer mesh;
    private TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mesh = player.GetComponent<MeshRenderer>();
        trail = player.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, Camera.main.transform.position);
        //Debug.Log(distance);
        if (distance <= 1.5f)
        {
            mesh.enabled = false;
            trail.enabled = false;
        }
        else {
            mesh.enabled = true;
            trail.enabled = true;
        }
    }
}
