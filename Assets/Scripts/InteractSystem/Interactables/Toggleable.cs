using UnityEngine;

public class Toggleable : Interactable
{
    [Header("Toggleable.cs")]
    [SerializeField]
    protected bool isOn;

    [SerializeField]
    private string turnOnText = "Turn on", turnOffText = "Turn off";

    [SerializeField]
    private AudioClip switchSound;

    public override void Interact()
    {
        Toggle();
    }

    protected override void OnHoveredOver(Interactable i)
    {
        base.OnHoveredOver(i);
        SetHoverText();
    }

    private void SetHoverText()
    {
        if (isOn)
        {
            nextHoverText = turnOffText;
        }
        else
        {
            nextHoverText = turnOnText;
        }
    }

    private void Toggle()
    {
        audioSource.PlayOneShot(switchSound);
        if (isOn)
            isOn = false;
        else
            isOn = true;
    }
}
