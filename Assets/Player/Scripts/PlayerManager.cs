using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public bool isGrounded = false;
    public bool gravity = true;
    public bool canJump = true;
    public bool canDash = true;
    public bool canShiftGravity = true;
    public bool debugMode = false;

    public TextMeshProUGUI livesUI;

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
        livesUI.text = "LIVES: " + lives;

        //Debug.Log(maxVelocity);
        if (rigidBody.velocity.magnitude > maxVelocity) {
            maxVelocity = rigidBody.velocity.magnitude;
        }

        if (lives <= 0) {
            Debug.Log("Game Over");
            gameObject.GetComponent<SceneLoader>().LoadScene();
        }
    }

    public void SubLife() {
        if (!debugMode)
        {
            --lives;
        }
    }

    public void AddLife(int l) {
        lives += l;
    }

    public int SetLives(int l)
    {
        lives = l;
        return lives;
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
