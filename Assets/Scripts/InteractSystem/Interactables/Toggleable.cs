using UnityEngine;

public class Toggleable : Interactable
{
    protected bool isOn;

    public override void Interact()
    {
        Toggle();
    }

    protected override void OnHoveredOver(Interactable i)
    {
        SetHoverText();
    }

    private void SetHoverText()
    {
        if (isOn)
        {
            interactText = "Turn off";
        }
        else
        {
            interactText = "Turn on";
        }
    }

    private void Toggle()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
    }

}
