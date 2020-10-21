using UnityEngine;

public class InteractLight : Interactable
{
    [SerializeField]
    private Light light;

    private bool isOn = false;

    public override void Interact()
    {
        ToggleLight();
    }

    protected override void OnHoveredOver(Interactable i)
    {
        SetLightHoverText();
    }

    private void SetLightHoverText()
    {
        if (isOn)
        {
            interactText = "Turn light off";
        }
        else
        {
            interactText = "Turn light on";
        }
    }

    private void ToggleLight()
    {
        if (isOn)
        {
            light.enabled = false;
            isOn = false;
        }
        else
        {
            light.enabled = true;
            isOn = true;
        }
    }




}
