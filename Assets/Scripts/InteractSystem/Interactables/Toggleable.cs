using UnityEngine;

public class Toggleable : Interactable
{
    [SerializeField]
    protected bool isOn;

    [SerializeField]
    private string turnOnText = "Turn on", turnOffText = "Turn off";

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
