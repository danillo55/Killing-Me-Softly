using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditTitle : MonoBehaviour
{
    [SerializeField] private GameObject Credit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Credit.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 800), 20f).SetEase(Ease.OutQuad);
        StartCoroutine(CallAfterDelay());
    }

    IEnumerator CallAfterDelay()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(18f);

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
