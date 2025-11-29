using UnityEngine;
using Yarn.Unity;
using EasyTransition;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class LayoutManager : MonoBehaviour
{
    [SerializeField]
    private GameObject
    LinePresenter,
    TextBackground,
    CharacterName,
    TextContainer,
    ButtonsContainer,
    OptionPresenter;

    [SerializeField] private TransitionManager transitionManager;

    [SerializeField] private TransitionSettings transition;
    
    [SerializeField] private Material frameMaterial;

    [SerializeField] private GameObject MiniGameObject, MiniGameChoice;
    [SerializeField] private DialogueRunner dialogue;
    [SerializeField] private AudioSource AdditionalSFX;


    [YarnCommand("SetTextLayoutUI")]
    public void SetTextLayout(
        bool showTextBackground,
        bool showCharactername,
        bool showButton,
        float leftPadding,
        float rightPadding,
        float yValue)
    {
        TextBackground.SetActive(showTextBackground);
        CharacterName.SetActive(showCharactername);
        ButtonsContainer.SetActive(showButton);

        RectTransform textContainerRect = LinePresenter.GetComponent<RectTransform>();

        // Move vertically (Y position)
        Vector2 anchoredPos = textContainerRect.anchoredPosition;
        anchoredPos.y = yValue; // move y units up from bottom anchor
        textContainerRect.anchoredPosition = anchoredPos;

        // Adjust left and right margins
        textContainerRect.offsetMin = new Vector2(leftPadding, textContainerRect.offsetMin.y); // left margin 
        textContainerRect.offsetMax = new Vector2(-Mathf.Abs(rightPadding), textContainerRect.offsetMax.y); // right margin 


    }

    [YarnCommand("SetChoiceLayoutUI")]
    public void SetChoiceLayout(
        bool showTextBackground,
        bool showCharactername,
        bool showButton,
        float leftPadding,
        float rightPadding,
        float yValue)
    {
    }

    [YarnCommand("EditShaderFrame")]
    public void AnimateMask(
        float UVStartWidth,
        float UVStartHeight,
        float UVEndWidth,
        float UVEndHeight,
        float duration,
        bool loop)
    {

        if (frameMaterial == null) return;

        frameMaterial.SetVector("_Size", new Vector2(UVStartWidth, UVStartHeight));
        frameMaterial.SetVector("_Center", new Vector2(0.3f, 0.5f));

        // Animate width
        DOTween.To(
            () => frameMaterial.GetVector("_Size").x,
            x => frameMaterial.SetVector("_Size", new Vector2(x, frameMaterial.GetVector("_Size").y)),
            UVEndWidth,
            duration
        ).SetEase(Ease.OutQuad).SetLoops(loop ? -1 : 0, LoopType.Yoyo);

        // Animate height
        DOTween.To(
            () => frameMaterial.GetVector("_Size").y,
            y => frameMaterial.SetVector("_Size", new Vector2(frameMaterial.GetVector("_Size").x, y)),
            UVEndHeight,
            duration
        ).SetEase(Ease.OutQuad).SetLoops(loop ? -1 : 0, LoopType.Yoyo);
    }


    [YarnCommand("changeScaleandPosition")]
    public void ChangeScaleandPosition()
    {

        TextContainer.GetComponent<TextMeshProUGUI>().color = Color.white;

    }

    [YarnCommand("PlayAdditionalSFX")]
    public void PlayAdditionalSFX(float sfxduration)
    {

        AdditionalSFX.DOFade(1f, 0).OnPlay(() => AdditionalSFX.Play());
        Invoke(nameof(StopAdditionalSFX), sfxduration);
        Debug.Log("Additional SFX played");

    }

    [YarnCommand("StopAdditionalSFX")]

    public void StopAdditionalSFX()
    {

        AdditionalSFX.DOFade(0f, 0.5f).OnComplete(() => AdditionalSFX.Stop());
        Debug.Log("Stopped");

    }

    [YarnCommand("textColorChangeToWhite")]
    public void SetTextColorWhite()
    {

        TextContainer.GetComponent<TextMeshProUGUI>().color = Color.white;

    }
    
    [YarnCommand("textColorChangeToBlack")]
    public void SetTextColorBlack()
    {

        TextContainer.GetComponent<TextMeshProUGUI>().color = Color.black;
    
    }

    [YarnCommand("ShowMindScene")]
    public void showMindGameObject(float duration)
    {

        MiniGameObject.SetActive(true);
    
    }    


    [YarnCommand("HideMindScene")]
    public void hideMindGameObject(float duration)
    {

        MiniGameObject.SetActive(false);
    
    }

    [YarnCommand("ShowChoice")]
    public void showChoice(float duration)
    {

        MiniGameChoice.SetActive(false);
    
    }

    [YarnCommand("HideChoice")]
    public void hideChoice(float duration)
    {

        MiniGameChoice.SetActive(false);
    
    }         
    
    [YarnCommand("ChangeScene")]
    public void LoadScene(string _sceneName, float startDelay)
    {

        TransitionManager.Instance().Transition(_sceneName, transition, startDelay);
    
    }

    [YarnCommand("SaveScene")]
    public void SaveGameScene(string sceneCode)
    {
        string sceneName = "Scene "+sceneCode;
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();
        Debug.Log("Saved scene: " + sceneName);
    
    }
    
    [YarnCommand("SaveChoice")]
    public void SaveGameChoice(int choice)
    {
        
        PlayerPrefs.SetInt("Choice", choice);
        PlayerPrefs.Save();
        
    
    }

    [YarnCommand("LoadChoice")]
    public void LoadGameChoice()
    {
        dialogue.VariableStorage.SetValue("$lastChoice", PlayerPrefs.GetInt("choice"));
    
    }

    [YarnCommand("SetMaterialCenter")]
    public void SetMaterialCenter(float x, float y)
    {
        frameMaterial.SetVector("_Center", new Vector2(0.5f, 0.5f));
        Debug.Log("Material center changed");
    }

    
    
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();
        Debug.Log("Saved scene: " + sceneName);
        frameMaterial.SetVector("_Size", new Vector2(1f, 1f));
        frameMaterial.SetVector("_Center", new Vector2(0.5f, 0.5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
