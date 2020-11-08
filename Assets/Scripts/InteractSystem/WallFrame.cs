using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFrame : Interactable
{
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        rigidBody.useGravity = true;
    }
}
