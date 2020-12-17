using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{

    [SerializeField] private GameObject StartRoom, ConcreteRoom;

    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();

            StartRoom.SetActive(false);
            ConcreteRoom.SetActive(true);
            Destroy(gameObject);
        }
    }
}
