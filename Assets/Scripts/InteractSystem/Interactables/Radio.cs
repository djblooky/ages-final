using UnityEngine;

public class Radio : Toggleable
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        ToggleSound();
    }

    private void ToggleSound()
    {
        if (isOn)
        {
            audioSource.volume = 0.3f; //todo: magic number
        }
        else
        {
            audioSource.volume = 0; 
        }
    }
}
