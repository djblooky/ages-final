using UnityEngine;

public class InteractController : MonoBehaviour
{
    [SerializeField]
    private float distanceToSee = 10;
    private RaycastHit objectHit;

    private void Start()
    {

    }

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out objectHit, distanceToSee))
        {
            Debug.Log("Something was hit!");
        }
    }
}
