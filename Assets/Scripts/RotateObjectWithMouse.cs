using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField]Vector3 examineRotation;
    [SerializeField] float distanceFromCameraOffset = 0.5f;

    private Vector3 lastFramePosition = Vector3.zero;
    private Vector3 deltaPosition = Vector3.zero;
    private Vector3 defaultPos;

    private void Start()
    {
        defaultPos = transform.position;
    }

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
        transform.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane + distanceFromCameraOffset));
        transform.rotation = Quaternion.Euler(examineRotation);
    }

    private void OnDisable()
    {
        transform.position = defaultPos;
    }
}
