using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenuFrameController : MonoBehaviour
{
    [SerializeField] private GameObject BlackFrame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeBox());

    }

    IEnumerator FadeBox()
    {
        // Wait for 20 seconds
        yield return new WaitForSeconds(1f);

        // Call your function
        BlackFrame.GetComponent<Image>().DOFade(0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
