using System;
using UnityEngine;

[RequireComponent(typeof(RotateObjectWithMouse))]
public class Examinable : Interactable
{
    public static event Action<string, string> ExaminedObject;

    [Header("Examinable.cs")]
    private bool isBeingExamined = false;

    private void Start()
    {
        displayTextOnHover = false;
    }

    public override void Interact()
    {
        base.Interact();
        GetComponent<RotateObjectWithMouse>().enabled = true;
        ExaminedObject?.Invoke(objectName, interactText);
    }

  
}
