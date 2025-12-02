using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    public FlyManager fm;
    public AudioSource collectSound;
    public AudioSource deathSound;
    public AudioSource frogMoveSound;

    [Header("Tilt Settings")]
    public float tiltThreshold = 0.3f;
    public float moveCooldown = 0.25f;

    private float lastMoveTime = 0f;


    void Start()
    {
        AudioManager.instance.StopClip();

        AudioManager.instance.PlayClip(0);

    }

    void Update()
    {


        Vector3 tilt = Input.acceleration;

        if (Time.time - lastMoveTime < moveCooldown)
            return;

        //Accelerometer
        if (tilt.x > tiltThreshold)
        {
            Move(Vector2.right);
            AudioManager.instance.PlayClip(5);
        }
        else if (tilt.x < -tiltThreshold)
        {
            Move(Vector2.left);
            AudioManager.instance.PlayClip(5);
        }
        else if (tilt.y > tiltThreshold)
        {
            Move(Vector2.up);
            AudioManager.instance.PlayClip(5);
        }
        else if (tilt.y < -tiltThreshold)
        {
            Move(Vector2.down);
            AudioManager.instance.PlayClip(5);
        }

        //Keyboard
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
            AudioManager.instance.PlayClip(5);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
            AudioManager.instance.PlayClip(5);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
            AudioManager.instance.PlayClip(5);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
            AudioManager.instance.PlayClip(5);
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
            AudioManager.instance.PlayClip(4);
            Score.CurrentScore = 0;
            FlyManager.flyCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(col.gameObject.CompareTag("Fly"))
        {
            AudioManager.instance.PlayClip(3);
            Destroy(col.gameObject);
            FlyManager.flyCount++;
        }
    }
}
