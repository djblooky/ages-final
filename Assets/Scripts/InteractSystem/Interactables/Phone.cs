using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] AudioClip pickUpPhoneSound;

    public override void Interact()
    {
        base.Interact();
        audioSource.PlayOneShot(pickUpPhoneSound);
        audioSource.loop = false;
    }

}
