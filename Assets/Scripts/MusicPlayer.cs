using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Yarn.Unity;


public class MusicPlayer : MonoBehaviour
{
   private static MusicPlayer instance;

   [SerializeField] private AudioSource BackgroundMusic, RainSFX, SoundEffect;
   [SerializeField] private AudioClip[] songs;


    [YarnCommand("PlayMusic")]

    public void PlayMusic(float fadeDuration)
    {
        if (BackgroundMusic.isPlaying)
        {
            Debug.Log("Music still playing");
        }
        else
        {
            Debug.Log("Play new music");
            BackgroundMusic.DOFade(1f, fadeDuration).OnPlay(() => BackgroundMusic.Play());
        }
    }

    [YarnCommand("StopMusic")]

    public void StopMusic(float fadeDuration)
    {

        BackgroundMusic.DOFade(0f, fadeDuration).OnComplete(() => BackgroundMusic.Stop());

    }
    
    [YarnCommand("PlayRainSFX")]

    public void PlayRainSFX(float fadeDuration)
    {
        
        RainSFX.DOFade(1f, fadeDuration).OnPlay(() => RainSFX.Play());

    }

    [YarnCommand("StopRainSFX")]

    public void StopRainSFX(float fadeDuration)
    {

        RainSFX.DOFade(0f, fadeDuration).OnComplete(() => RainSFX.Stop());


    }

    [YarnCommand("PlaySFX")]

    public void PlaySFX(float fadeDuration)
    {
        
        SoundEffect.DOFade(1f, 0.1f).OnPlay(() => SoundEffect.Play());
    //    Invoke(nameof(StopSFX), fadeDuration);
        Debug.Log("SFX played");
    }

    [YarnCommand("StopSFX")]

    public void StopSFX(float fadeDuration)
    {

        SoundEffect.DOFade(0f, fadeDuration).OnComplete(() => SoundEffect.Stop());
        Debug.Log(" SFX Stopped");

    }

    [YarnCommand("ChangeMusic")]
    public void changeMusic(int index)
    {

        Debug.Log("Change Music");
        BackgroundMusic.clip = songs[index];

    }

    private void Awake()
    {
        // Singleton pattern: only one MusicPlayer survives
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Subscribe to scene change events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Called automatically when a new scene is loaded
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // Example logic: customize per scene
        if (sceneName == "Main Menu Jo's Episode" || 
            sceneName == "Main Menu Rainy's Episode" ||
            sceneName == "Main Menu Real's Episode")
        {
            StopMusic(1);
            PlayRainSFX(1);
        }

    }

    /*     void OnEnable()
    {
        // Subscribe to sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



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
            Debug.Log("Music player destroyed");
            Destroy(gameObject);
            return;

        }
        // Set this as the singleton instance
        instance = this;
        DontDestroyOnLoad(gameObject);
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
    }*/
}
