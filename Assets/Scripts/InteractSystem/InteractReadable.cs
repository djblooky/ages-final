using System;
using UnityEngine;

public class InteractReadable : Interactable
{
    public static event Action<Sprite> OpenedNote;

    [SerializeField]
    private Sprite noteImage;

    public override void Interact()
    {
        OpenedNote?.Invoke(noteImage);
    }
}
