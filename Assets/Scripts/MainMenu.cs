using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            DoNotDestroy.instance.GetComponent<AudioSource>().Stop();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}
