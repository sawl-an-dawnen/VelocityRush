using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject checkPoint;
    private Rigidbody rb;
    private bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = GameObject.FindGameObjectWithTag("Spawn");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gameObject.transform.position != checkPoint.transform.position && !isSpawned) {
            Respawn();
        }
        else if (gameObject.transform.position == checkPoint.transform.position && !isSpawned)
        {
            isSpawned = true;
        }
    }

    public void SetCheckPoint(GameObject location) {
        checkPoint = location;
    }
    public void Respawn() {
        Camera.main.transform.position = checkPoint.transform.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.transform.position = checkPoint.transform.position;
    }
}
