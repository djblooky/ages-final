using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
    /*
    private Vector3 lastFramePosition = Vector3.zero;
    private Vector3 deltaPosition = Vector3.zero;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            deltaPosition = Input.mousePosition - lastFramePosition;

            if(Vector3.Dot(transform.up, Vector3.up) >= 0)
                transform.Rotate(transform.up, -Vector3.Dot(deltaPosition, Camera.main.transform.right), Space.World);
            else
                transform.Rotate(transform.up, Vector3.Dot(deltaPosition, Camera.main.transform.right), Space.World);

            transform.Rotate(Camera.main.transform.right, Vector3.Dot(deltaPosition, Camera.main.transform.up), Space.World);
        }

        lastFramePosition = Input.mousePosition;
    }*/

    
    Camera mainCam;//Camera Object Will Be Placed In Front Of

    //Holds Original Postion And Rotation So The Object Can Be Replaced Correctly
    Vector3 originaPosition;
    Vector3 originalRotation;

    //If True Allow Rotation Of Object
    bool examineMode;

    private void Start()
    {
        mainCam = Camera.main;
        examineMode = false;
    }

    private void Update()
    {
       
        TurnObject();//Allows Object To Be Rotated

        ExitExamineMode();//Returns Object To Original Postion
    }


    public void ClickObject()
    {
        //Save The Original Postion And Rotation
        originaPosition = PlayerRaycast.lastObjectInteractedWith.transform.position;
        originalRotation = PlayerRaycast.lastObjectInteractedWith.transform.rotation.eulerAngles;

        //Now Move Object In Front Of Camera
        PlayerRaycast.lastObjectInteractedWith.transform.position = mainCam.transform.position + (-transform.forward );

        //Pause The Game
       // Time.timeScale = 0;

        //Turn Examine Mode To True
        examineMode = true;
    }

    void TurnObject()
    {
        if (Input.GetMouseButton(0) && examineMode)
        {
            float rotationSpeed = 15;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            PlayerRaycast.lastObjectInteractedWith.transform.Rotate(Vector3.up, -xAxis, Space.Self);
            PlayerRaycast.lastObjectInteractedWith.transform.Rotate(Vector3.right, yAxis, Space.Self);
        }
    }

    void ExitExamineMode()
    {
        if (Input.GetMouseButtonDown(1) && examineMode)
        {
            //Reset Object To Original Position
            PlayerRaycast.lastObjectInteractedWith.transform.position = originaPosition;
            PlayerRaycast.lastObjectInteractedWith.transform.eulerAngles = originalRotation;

            //Unpause Game
            //Time.timeScale = 1;

            //Return To Normal State
            examineMode = false;
        }
    }




}
