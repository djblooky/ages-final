using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
