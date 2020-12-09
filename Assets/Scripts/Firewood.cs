using System.Collections;
using UnityEngine;

public class Firewood : Interactable
{
    private ParticleSystem[] particleSystems;
    [SerializeField] private float logBurningDuration = 3f;
    [SerializeField] private string litFireText, collectedMatchesText;

    private bool canBeLit = false;

    private void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public override void Interact()
    {
        base.Interact();
        if (canBeLit)
        {
            hoverText = litFireText;
            audioSource.Play();
            foreach (ParticleSystem particles in particleSystems)
                particles.Play();
            StartCoroutine(BurnOutLogsAfterDelay());
        }
    }

    private IEnumerator BurnOutLogsAfterDelay()
    {
        yield return new WaitForSeconds(logBurningDuration);
        audioSource.Stop(); //polish: play extinguish sound
        foreach (ParticleSystem particles in particleSystems)
            particles.Stop();
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
