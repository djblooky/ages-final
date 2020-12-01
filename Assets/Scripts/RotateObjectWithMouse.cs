using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
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
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
