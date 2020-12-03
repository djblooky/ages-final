using System;
using UnityEngine;

public class Matches : Interactable
{
    public static event Action CollectedMatches;

    [SerializeField]
    private AudioClip pickupSound;

    private MeshRenderer [] meshRenderers;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public override void Interact()
    {
        //audioSource.PlayOneShot(pickupSound);
        foreach(MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = false;
        Destroy(gameObject); //Destroy(gameObject, pickupSound.length);
        CollectedMatches?.Invoke();
    }
}
