using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Tilt Settings")]
    public float tiltThreshold = 0.3f;  // How far the player must tilt to trigger a move
    public float moveCooldown = 0.25f;  // Prevents continuous movement while holding tilt

    private float lastMoveTime = 0f;

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (Time.time - lastMoveTime < moveCooldown)
            return;

        // Horizontal Movement
        if (tilt.x > tiltThreshold)
        {
            Move(Vector2.right);
        }
        else if (tilt.x < -tiltThreshold)
        {
            Move(Vector2.left);
        }
        // Vertical Movement
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
