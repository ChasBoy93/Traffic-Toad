using UnityEngine;
using TMPro;

public class FlyManager : MonoBehaviour
{
    public static int flyCount;
    public TMP_Text flyText;

    void Update()
    {
        flyText.text = "Flies: " + flyCount.ToString();
    }
}
