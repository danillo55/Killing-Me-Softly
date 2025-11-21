using DG.Tweening;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class BookView : MonoBehaviour
{
    [SerializeField] private GameObject book1, book2, book3, book4, background;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [YarnCommand("ShowBook")]
    public void LoadBook()
    {

        //    book1.SetActive(true);
        book1.GetComponent<Image>().DOFade(1f, 2f);

    }

    [YarnCommand("HideBook")]
    public void HideBookFunction()
    {

        //    book1.SetActive(true);
        book1.GetComponent<Image>().DOFade(0f, 3f);

    }

    [YarnCommand("HideBook2")]
    public void HideBook2Function()
    {

        //    book1.SetActive(true);
        book2.GetComponent<Image>().DOFade(0f, 3f);

    }


    [YarnCommand("AnimateWriting")]
    public void ChangeBook()
    {

        
        book1.GetComponent<Image>().DOFade(0f, 3f);
        book2.GetComponent<Image>().DOFade(1f, 3f);

    }

    [YarnCommand("ShowBook2")]
    public void LoadBook2()
    {
        book2.GetComponent<Image>().DOFade(1f, 2f);
    }

    [YarnCommand("FinishWriting")]
    public void LoadBook3()
    {

        book2.GetComponent<Image>().DOFade(0f, 1f);

    }

    [YarnCommand("ShowTable")]
    public void LoadBook4()
    {

        book3.GetComponent<Image>().DOFade(1f, 1f);
//        book4.GetComponent<Image>().DOFade(1f, 1f);
    }


    [YarnCommand("MoveObject")]
    public void TranslateObject(float x, float y)
    {
        book1.GetComponent<RectTransform>().DOAnchorPos(new Vector2(x, y), 1f).SetEase(Ease.OutQuad);
    }

    [YarnCommand("MoveObject2")]
    public void TranslateObject2(float x, float y)
    {
        book2.GetComponent<RectTransform>().DOAnchorPos(new Vector2(x, y), 1f).SetEase(Ease.OutQuad);
    }

    [YarnCommand("ParalaxBookShelf")]
    public void ParalaxBookShelfFunction()
    {

        book2.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -250), 2f).SetEase(Ease.OutQuad);
        book3.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -500), 2f).SetEase(Ease.OutQuad);

    }

    [YarnCommand("Move2Object")]
    public void Translate2Object(float x1, float y1, float x2, float y2)
    {

        book2.GetComponent<RectTransform>().DOAnchorPos(new Vector2(x1, y1), 1f).SetEase(Ease.OutQuad);
        book1.GetComponent<RectTransform>().DOAnchorPos(new Vector2(x2, y2), 1f).SetEase(Ease.OutQuad);

    }
    
    [YarnCommand("HideShelf")]
    public void HideShelfFunction()
    {

        book3.GetComponent<Image>().DOFade(0f, 1f);
        book2.GetComponent<Image>().DOFade(0f, 1f);
    
    }

    [YarnCommand("ShowBackground")]
    public void ShowBackgroundFunction(float duration)
    {

        if (background == null) 
        {
            Debug.Log("Background is null");
        }
        else
        {
            background.GetComponent<Image>().DOFade(1f, duration);    
        }
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
