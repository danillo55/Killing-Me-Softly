using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        // If another MusicPlayer already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the singleton instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
