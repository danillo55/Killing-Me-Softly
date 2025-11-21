using UnityEngine;
using UnityEngine.InputSystem;
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float moveDistance = 5f;

/*    public InputAction CameraControls;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        CameraControls.Enable();
    }

        private void OnDisable()
    {
        CameraControls.Disable();
    } */
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {    
//          moveDirection = CameraControls.ReadValue<Vector2>();
        
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
           {
               transform.Translate(Vector3.left * Time.deltaTime * speed);
           }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
           {
               transform.Translate(Vector3.right * Time.deltaTime * speed);
           }
    }
    /*   public void MoveLeft()
       {
           transform.position += Vector3.left * moveDistance;
       }

       public void MoveRight()
       {
           transform.position += Vector3.right * moveDistance;
       }*/
 /*   public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position += Vector3.left * moveDistance;
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position += Vector3.right * moveDistance;
        }
    }*/
}
