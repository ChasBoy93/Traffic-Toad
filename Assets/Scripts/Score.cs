using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int CurrentScore = 0;

    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Score: " + CurrentScore.ToString();
    }
}
