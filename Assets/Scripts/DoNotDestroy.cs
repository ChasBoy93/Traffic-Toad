using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy instance;
    void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");

        if(musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
