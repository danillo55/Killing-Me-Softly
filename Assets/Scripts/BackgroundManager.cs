using UnityEngine;
using DG.Tweening; // Import DOTween namespace
using System; 
using UnityEngine.SceneManagement;

[System.Serializable]
public class BackgroundList
{
    public GameObject background;
}


public class BackgroundManager : MonoBehaviour
{

    [SerializeField] private BackgroundList[] background;
    [SerializeField] private Camera mainCamera, secondCamera; // assign in inspector or will use Camera.main

    [SerializeField] private float CameraSpeed = 5f;

//    [SerializeField] private BackgroundList LeftBackground, RightBackground;
    [SerializeField] private BackgroundList Background1, Background2, Background3, Background4, Background5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

//        LeftBackground = background[0];
//        RightBackground = background[4];
        Background1 = background[0];
        Background2 = background[1];
        Background3 = background[2];
        Background4 = background[3];
        Background5 = background[4];    
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
    //    GameObject center2D = GetObjectAtLeft();
        if (currentSceneName == "Scene 6")
        {
            Background1.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
            Background2.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
            Background3.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
            Background4.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
            Background5.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);

            if(Background1.background.GetComponent<RectTransform>().anchoredPosition.x <= -735f)
            {
                Background1.background.GetComponent<RectTransform>().anchoredPosition = 
                    new Vector2(490f, 0);

                BackgroundList tempBackground = Background1;

                Background1 = Background2;
                Background2 = Background3;
                Background3 = Background4;
                Background4 = Background5; 
                Background5 = tempBackground;
            }

        }
        else if (currentSceneName == "Scene 23")
        {
            Background1.background.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed);
            Background2.background.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed);
            Background3.background.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed);
            Background4.background.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed);
            Background5.background.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed); 
          


        if (Background5.background.GetComponent<RectTransform>().anchoredPosition.x >= 490f)
    {
            Background5.background.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(-735f, 0);

            BackgroundList tempBackground = Background5;
            Background5 = Background4;
            Background4 = Background3;
            Background3 = Background2;
            Background2 = Background1;
            Background1 = tempBackground;
    }
        }
        

    }
    private GameObject GetObjectAtScreenCenter2D()
    {
        if (mainCamera == null) return null;
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, Mathf.Abs(mainCamera.transform.position.z));
        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenCenter);
        Collider2D col = Physics2D.OverlapPoint(new Vector2(worldPoint.x, worldPoint.y));
        return col ? col.gameObject : null;
    }

/*    private GameObject GetObjectAtLeft()
    {
        if (secondCamera == null) return null;
        Vector3 screenLeft = new Vector3(secondCamera.transform.position.x, secondCamera.transform.position.y, Mathf.Abs(secondCamera.transform.position.z));
        Vector3 leftPoint = mainCamera.ScreenToWorldPoint(screenLeft);
        Collider2D col = Physics2D.OverlapPoint(new Vector2(leftPoint.x, leftPoint.y));
        return col ? col.gameObject : null;
    }*/

}
