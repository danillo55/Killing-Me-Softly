using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Yarn.Unity;

public class DialogueFillGame3 : MonoBehaviour
{
    [SerializeField] private TMP_Text mainSentenceText;
    [SerializeField] private Button[] wordButtons;
    [SerializeField] private string[] correctWords; // ["brown", "over", "dog"]
    [SerializeField] private DialogueRunner dialogueRunner; // Reference to Yarn Spinner
    [SerializeField] private LayoutManager layoutManager;

    private int currentIndex = 0; // Which blank we’re filling

    private string sentenceTemplate = "She _____ so _____. _____ is _____ _____ to _____.";


    void Start()
    {
        mainSentenceText.text = sentenceTemplate;

        for (int i = 0; i < wordButtons.Length; i++)
        {
            int index = i;
            wordButtons[i].onClick.AddListener(() => OnWordClicked(wordButtons[index]));
        }
    }

    void OnWordClicked(Button clickedButton)
    {
        string clickedWord = clickedButton.GetComponentInChildren<TMP_Text>().text;

        if (clickedWord == correctWords[currentIndex])
        {
            ReplaceBlank(clickedWord);
            FadeOutButton(wordButtons[currentIndex]);
            wordButtons[currentIndex].interactable = false;
            currentIndex++;

            if (currentIndex >= correctWords.Length)
            {
       
//                ActivateYarnNode("AfterFillNode"); // Your Yarn node name
                layoutManager.LoadScene("Scene 24", 1f);
                
            }            
        }
        else
        {
            // 🔴 Wrong choice → Shake the button
            ShakeButton(clickedButton);
        }
    }

    void FadeOutButton(Button btn)
{
    Image img = btn.GetComponent<Image>();
    if (img != null)
    {
        img.DOFade(0f, 1f); // fade to transparent over 1 second
    }

    TMP_Text[] texts = btn.GetComponentsInChildren<TMP_Text>(true); // `true` includes inactive children
    foreach (var t in texts)
    {
        if (t != null)
            t.DOFade(0f, 1f); // fade each child text over 1 second
    }

/*    TMP_Text txt = btn.GetComponentInChildren<TMP_Text>();
    if (txt != null)
    {
        txt.DOFade(0f, 1f); // fade text too
    }*/
    
}

    void ShakeButton(Button btn)
    {
        RectTransform rect = btn.GetComponent<RectTransform>();
        rect.DOShakePosition(0.5f, strength: new Vector3(10f, 0f, 0f), vibrato: 10, randomness: 90, snapping: false, fadeOut: true);
    }

    void ReplaceBlank(string word)
    {
        // Replace only the first occurrence of "_____"
        int blankIndex = mainSentenceText.text.IndexOf("_____");
        if (blankIndex != -1)
        {
            mainSentenceText.text = mainSentenceText.text.Remove(blankIndex, 5).Insert(blankIndex, word);
        }
    }

    void ActivateYarnNode(string nodeName)
    {
        if (dialogueRunner != null)
        {
            dialogueRunner.StartDialogue(nodeName);
        }
        else
        {
            Debug.LogWarning("DialogueRunner not assigned!");
        }
    }
}
