using UnityEngine;

public class Candle : Toggleable
{
    [SerializeField]
    private ParticleSystem flameParticle;

    public override void Interact()
    {
        base.Interact();
        ToggleCandle();
    }

    private void ToggleCandle()
    {
        if (isOn)
        {
            flameParticle.Play();
        }
        else
        {
            flameParticle.Stop();
        }
    }
}
