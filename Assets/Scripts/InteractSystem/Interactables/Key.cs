using UnityEngine;

public class Key : Interactable
{
    [SerializeField]
    private GameObject objectToUnlock;

    public override void Interact()
    {
        objectToUnlock.GetComponentInChildren<Openable>().isLocked = false;
        Destroy(gameObject);
    }
}
