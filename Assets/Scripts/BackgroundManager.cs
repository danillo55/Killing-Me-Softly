using UnityEngine;
using DG.Tweening; // Import DOTween namespace
using System; 

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
    void FixedUpdate()
    {
    //    GameObject center2D = GetObjectAtLeft();

        Background1.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
        Background2.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
        Background3.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
        Background4.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);
        Background5.background.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);

        if(Background1.background.transform.position.x <= -25.6f)
            {
                Background1.background.transform.DOMove(new Vector3(38.4f, 0, -4), 0.0001f);

                BackgroundList tempBackground = Background1;

                Background1 = Background2;
                Background2 = Background3;
                Background3 = Background4;
                Background4 = Background5; 
                Background5 = tempBackground;

            }

    /*    GameObject center2D = GetObjectAtScreenCenter2D();
    
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("2D center object: " + center2D.name);

            mainCamera.transform.Translate(Vector3.left * Time.deltaTime * CameraSpeed);

            if(center2D == LeftBackground.background)
            {
                RightBackground.background.transform.DOMove(new Vector3(RightBackground.background.transform.position.x - 64,
                                                        RightBackground.background.transform.position.y,
                                                        RightBackground.background.transform.position.z), 0.0001f);

                LeftBackground = RightBackground;

                if (RightBackground == background[0])
                {
                    RightBackground = background[4];
                }
                else
                {
                    RightBackground = background[Array.IndexOf(background, RightBackground) - 1]; 
                }
            }
       

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.Translate(Vector3.right * Time.deltaTime * CameraSpeed);
            Debug.Log("2D center object: " + center2D.name);

            if(center2D == RightBackground.background)
            {
                LeftBackground.background.transform.DOMove(new Vector3(LeftBackground.background.transform.position.x + 64,
                                                        LeftBackground.background.transform.position.y,
                                                        LeftBackground.background.transform.position.z), 0.0001f);

                RightBackground = LeftBackground;

                if (LeftBackground == background[4])
                {
                    LeftBackground = background[4];
                }
                else
                {
                    LeftBackground = background[Array.IndexOf(background, LeftBackground) + 1]; 
                }
            }
        }*/


    }

    // 2D: requires Collider2D on sprites
    private GameObject GetObjectAtScreenCenter2D()
    {
        if (mainCamera == null) return null;
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, Mathf.Abs(mainCamera.transform.position.z));
        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenCenter);
        Collider2D col = Physics2D.OverlapPoint(new Vector2(worldPoint.x, worldPoint.y));
        return col ? col.gameObject : null;
    }

    private GameObject GetObjectAtLeft()
    {
        if (secondCamera == null) return null;
        Vector3 screenLeft = new Vector3(secondCamera.transform.position.x, secondCamera.transform.position.y, Mathf.Abs(secondCamera.transform.position.z));
        Vector3 leftPoint = mainCamera.ScreenToWorldPoint(screenLeft);
        Collider2D col = Physics2D.OverlapPoint(new Vector2(leftPoint.x, leftPoint.y));
        return col ? col.gameObject : null;
    }

}
