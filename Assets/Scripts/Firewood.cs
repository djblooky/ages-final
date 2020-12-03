using System.Collections;
using UnityEngine;

public class Firewood : Interactable
{
    //[SerializeField] private ParticleSystem dissolveParticles;
    [SerializeField] private ParticleSystem flameParticles;
    [SerializeField] private float logBurningDuration = 3f;
    [SerializeField] private string litFireText, collectedMatchesText;

    private bool canBeLit = false;

    public override void Interact()
    {
        base.Interact();
        if (canBeLit)
        {
            hoverText = litFireText;
            audioSource.Play();
            flameParticles.Play();
            StartCoroutine(BurnOutLogsAfterDelay());
        }
    }

    private IEnumerator BurnOutLogsAfterDelay()
    {
        yield return new WaitForSeconds(logBurningDuration);
        audioSource.Stop(); //polish: play extinguish sound
        flameParticles.Stop();
        Destroy(transform.root.gameObject);
    }

    private void OnCollectedMatches()
    {
        hoverText = collectedMatchesText;
        canBeLit = true;
    }

    private void OnEnable()
    {
        Matches.CollectedMatches += OnCollectedMatches;
    }

    private void OnDisable()
    {
        Matches.CollectedMatches -= OnCollectedMatches;
    }
}
