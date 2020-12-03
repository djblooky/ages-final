using System;
using UnityEngine;

//[RequireComponent(typeof(RotateObjectWithMouse))]
public class Examinable : Interactable
{
    public static event Action<string, string> ExaminedObject;

    private void Start()
    {
        displayTextOnHover = false;
    }

    public override void Interact()
    {
        base.Interact();
        var rotateScript = GetComponent<RotateObjectWithMouse>();
            rotateScript.enabled = true;
        ExaminedObject?.Invoke(objectName, hoverText);
        rotateScript.ClickObject();//Decide What Object To Examine
        tag = "Untagged";
    }
}
