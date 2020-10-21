using System;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public static event Action HoveredOverInteractable;
    public static event Action HoveredOffInteractable;

    [SerializeField]
    private float distanceToSee = 3;
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

        if (Physics.Raycast(transform.position, transform.forward, out objectHit, distanceToSee)) //if ray hit something
        {
            if (objectHit.collider.CompareTag("Interactable")) //if the thing it hit was interactable
            {
                HoveredOverInteractable?.Invoke();
                Debug.Log($"{objectHit} was hit!");
            }
            else //if hit something that's not interactable
            {
                HoveredOffInteractable?.Invoke();
            }
        }
        else //if didn't hit anything
        {
            HoveredOffInteractable?.Invoke();
        }
    }
}
