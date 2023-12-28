using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        gameObject.transform.position = spawn.transform.position;
    }

}
