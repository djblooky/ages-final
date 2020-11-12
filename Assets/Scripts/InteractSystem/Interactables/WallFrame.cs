using UnityEngine;

public class WallFrame : Interactable
{
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        rigidBody.useGravity = true;
        tag = "Untagged";
    }
}
