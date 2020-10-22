using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public static event Action<Interactable> HoveredOver;
    public static event Action HoveredOff;

    [SerializeField]
    private float distanceToSee = 3;
    private RaycastHit objectHit;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, distanceToSee)) //if ray hit something
        {
            if (objectHit.collider.CompareTag("Interactable")) //if the thing it hit was interactable
            {
                Interactable i = objectHit.collider.gameObject.GetComponent<Interactable>();
                HoveredOver?.Invoke(i);
                if (Input.GetMouseButtonDown(0))
                    i.Interact();
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
