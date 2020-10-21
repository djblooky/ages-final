using System;
using UnityEngine;

public class InteractReadable : Interactable
{
    public static event Action<Sprite> OpenedNote;

    [SerializeField]
    private Sprite noteImage;

    private void Start()
    {
        //interactText = "Click to read";
    }


    public override void Interact()
    {
        OpenedNote?.Invoke(noteImage);
    }
}
