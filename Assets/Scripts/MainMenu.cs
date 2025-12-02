using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        AudioManager.instance.StopClip();
        AudioManager.instance.PlayClip(1);

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}
