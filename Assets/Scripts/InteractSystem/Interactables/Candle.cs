using UnityEngine;

public class Candle : Interactable
{
    private bool canBeLit = false;

    [SerializeField] private ParticleSystem flameParticle;
    [SerializeField] private string litCandleText, collectedMatchesText;

    public override void Interact()
    {
        base.Interact();
        if (canBeLit)
        {
            hoverText = litCandleText;
            flameParticle.Play();
        }
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
