using System;
using UnityEngine;

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
        ExaminedObject?.Invoke(objectName, interactText);
    }

  
}
