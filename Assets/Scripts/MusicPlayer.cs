using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
   private static MusicPlayer instance;

 /*    void Awake()
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
            Debug.Log("Music player destroyed");
            Destroy(gameObject);
            return;

        }
        // Set this as the singleton instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }*/
    void OnEnable()
    {
        // Subscribe to sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // If another MusicPlayer already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            
        }

        if (currentSceneName == "Main Menu Jo's Episode" || 
            currentSceneName == "Main Menu Rainy's Episode" ||
            currentSceneName == "Main Menu Real's Episode")
        {

            if (instance == null) {
                Debug.Log("Music Player is already destroyed");
            }
            else{
                Debug.Log("Music player destroyed");
                Destroy(gameObject);
            }

        }
        // Set this as the singleton instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
