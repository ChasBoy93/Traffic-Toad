using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioSource completionSound;
    void OnTriggerEnter2D()
    {
        AudioManager.instance.PlayClip(2);
        Score.CurrentScore += 100;
        StartCoroutine(ReloadGame());
    }

    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
