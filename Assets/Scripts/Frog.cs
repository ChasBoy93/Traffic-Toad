using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Tilt Settings")]
    public float tiltThreshold = 0.3f; 
    public float moveCooldown = 0.25f;  

    private float lastMoveTime = 0f;

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (Time.time - lastMoveTime < moveCooldown)
            return;

        if (tilt.x > tiltThreshold)
        {
            Move(Vector2.right);
        }
        else if (tilt.x < -tiltThreshold)
        {
            Move(Vector2.left);
        }
        else if (tilt.y > tiltThreshold)
        {
            Move(Vector2.up);
        }
        else if (tilt.y < -tiltThreshold)
        {
            Move(Vector2.down);
        }
    }

    void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction);
        lastMoveTime = Time.time;
    }
}
