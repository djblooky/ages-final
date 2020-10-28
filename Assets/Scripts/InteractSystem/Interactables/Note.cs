using System;
using UnityEngine;

public class Note : Interactable
{
    public static event Action<Sprite> OpenedNote;

    [SerializeField]
    private Sprite noteImage;

    public override void Interact()
    {
        OpenedNote?.Invoke(noteImage);
    }
}
