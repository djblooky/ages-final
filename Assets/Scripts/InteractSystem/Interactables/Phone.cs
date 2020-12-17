using System.Collections;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] AudioClip pickUpPhoneSound, toneSound;

    public override void Interact()
    {
        base.Interact();
        audioSource.PlayOneShot(pickUpPhoneSound);
        audioSource.loop = false;
        tag = "Untagged";
        StartCoroutine(PlayTone());
    }

    IEnumerator PlayTone()
    {
        yield return new WaitForSeconds(pickUpPhoneSound.length);
        audioSource.clip = toneSound;
        audioSource.loop = true;
        audioSource.volume = 0.1f;
        audioSource.maxDistance = 2;
        audioSource.Play();
        yield return new WaitForSeconds(10f);
        audioSource.Stop();
    }

}
