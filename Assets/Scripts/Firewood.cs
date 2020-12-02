using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewood : Interactable
{
    [SerializeField]
    private ParticleSystem flameParticles;

    [SerializeField]
    private float logBurningDuration = 3f;

    private bool canBeLit = false;

    public override void Interact()
    {
        base.Interact();
        if (canBeLit)
        {
            //play fire crackling sound
            flameParticles.Play();
            StartCoroutine(BurnOutLogsAfterDelay());
        }
    }

    IEnumerator BurnOutLogsAfterDelay()
    {
        yield return new WaitForSeconds(logBurningDuration);
        //play extinguish sound
        flameParticles.Stop();
        Destroy(gameObject);
    }

    void OnCollectedMatches()
    {
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
