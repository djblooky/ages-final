using System;
using UnityEngine;

public class Note : Interactable
{
    public static event Action<string> OpenedNote;

    [SerializeField]
    [TextArea(1,10)]
    private string noteText;

    public override void Interact()
    {
        OpenedNote?.Invoke(noteText);
    }
}
