using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioSource completionSound;
    void OnTriggerEnter2D()
    {
        AudioManager.instance.PlayClip(2);
        Score.CurrentScore += 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
