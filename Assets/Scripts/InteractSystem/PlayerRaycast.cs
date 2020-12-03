using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public static event Action<Interactable> HoveredOver;
    public static event Action HoveredOff;

    public static GameObject lastObjectInteractedWith;

    [SerializeField]
    private float distanceToSee = 3;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceToSee)) //if ray hit something
        {
            if (hit.collider.CompareTag("Interactable")) //if the thing it hit was interactable
            {
                Interactable i = hit.collider.gameObject.GetComponent<Interactable>();
                HoveredOver?.Invoke(i);
                if (Input.GetMouseButtonDown(0))
                    i.Interact(); lastObjectInteractedWith = hit.transform.gameObject;
            }
            else //if hit something that's not interactable
            {
                HoveredOff?.Invoke();
            }
        }
        else //if didn't hit anything
        {
            HoveredOff?.Invoke();
        }
    }
}
