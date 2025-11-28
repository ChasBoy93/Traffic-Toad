using UnityEngine;

public class CollectSound : MonoBehaviour
{

    public static CollectSound instance;

    void Awake()
    {
        if (instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
