using UnityEngine;

public class Key : Interactable
{
    [SerializeField]
    private GameObject objectToUnlock;

    [SerializeField]
    private AudioClip pickupSound;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void Interact()
    {
        audioSource.PlayOneShot(pickupSound);
        objectToUnlock.GetComponentInChildren<Openable>().isLocked = false;
        meshRenderer.enabled = false;
        Destroy(gameObject, pickupSound.length);
    }
}
