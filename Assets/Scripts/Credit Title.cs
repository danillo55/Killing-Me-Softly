using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class CreditTitle : MonoBehaviour
{
    [SerializeField] private GameObject Credit, Header;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeText());
        StartCoroutine(CreditRoll());
        StartCoroutine(CallAfterDelay());
    }

    IEnumerator FadeText()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(3f);

        // Call your function
        Header.GetComponent<TextMeshProUGUI>().DOFade(0f, 2f);
    }


    IEnumerator CreditRoll()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(5f);

        // Call your function
        Credit.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 1100), 30f).SetEase(Ease.OutQuad);
    }


    IEnumerator CallAfterDelay()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(25f);

        // Call your function
        BackToMainMenu();
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Rainy's Episode");
        // Put your custom logic here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
