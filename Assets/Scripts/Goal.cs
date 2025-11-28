using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioSource completionSound;
    void OnTriggerEnter2D()
    {
        CollectSound.instance.GetComponent<AudioSource>().Play();
        Score.CurrentScore += 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
