using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    public FlyManager fm;
    public AudioSource collectSound;

    [Header("Tilt Settings")]
    public float tiltThreshold = 0.3f;
    public float moveCooldown = 0.25f;

    private float lastMoveTime = 0f;


    void Start()
    {

    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Main Game")
        {
            DoNotDestroy.instance.GetComponent<AudioSource>().Play();
        }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            Debug.Log("WE LOST!");
            Score.CurrentScore = 0;
            FlyManager.flyCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(col.gameObject.CompareTag("Fly"))
        {
            collectSound.Play();
            Destroy(col.gameObject);
            FlyManager.flyCount++;
        }
    }
}
