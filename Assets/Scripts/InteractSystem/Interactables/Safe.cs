using UnityEngine;

public class Safe : Openable
{
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Opened safe UI");
    }
}
