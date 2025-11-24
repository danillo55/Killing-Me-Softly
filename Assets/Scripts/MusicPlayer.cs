using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // If another MusicPlayer already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (currentSceneName == "Main Menu Jo's Episode" || 
            currentSceneName == "Main Menu Rainy's Episode" ||
            currentSceneName == "Main Menu Real's Episode")
        {
            Destroy(gameObject);
            return;

        }
        // Set this as the singleton instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
