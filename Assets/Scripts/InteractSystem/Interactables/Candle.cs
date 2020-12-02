using UnityEngine;

public class Candle : Interactable
{
    private bool canBeLit = false;

    [SerializeField]
    private ParticleSystem flameParticle;

    public override void Interact()
    {
        base.Interact();
        ToggleCandle();
    }

    private void ToggleCandle()
    {
        if (canBeLit)
        {
            flameParticle.Play();
        }
    }

    private void OnCollectedMatches()
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
