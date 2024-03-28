using UnityEngine;

public class GravityShift : MonoBehaviour
{
    public bool pressed = false;
    public float timer = 5f;
    public float gForce = 1000f;
    public AudioClip readyChime;

    private float t = 0f;
    private PlayerManager player;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool notified = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerManager>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t >= 0f)
        {
            t -= Time.deltaTime;
        }
        else if (!notified) 
        {
            audioSource.PlayOneShot(readyChime);
            notified = true;
        }
        pressed = false;
        if (Input.GetKeyDown(KeyCode.E) && player.canShiftGravity && t <= 0f)
        {
            player.InvertGravity();
            pressed = true;
            t = timer;
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
        if (player.canShiftGravity && t <= 0f) 
        { 
            player.InvertGravity();
            pressed = true;
            t = timer;
        }
    }


}
