using UnityEngine;

public class RollingScript : MonoBehaviour
{
    public enum RotationDirection
    {
        Clockwise,
        CounterClockwise
    }

    

    public float rotationSpeed = 10f;
    public RotationDirection rotationDirection = RotationDirection.Clockwise;
    public Vector3 axis = Vector3.up;

    Transform rollerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rollerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationDirection == RotationDirection.Clockwise)
        {
            rollerTransform.Rotate(axis, rotationSpeed * Time.deltaTime);
        }
        else {
            rollerTransform.Rotate(axis, -rotationSpeed * Time.deltaTime);
        }
    }
}
