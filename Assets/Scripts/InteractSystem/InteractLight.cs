using UnityEngine;

public class InteractLight : Interactable
{
    [SerializeField]
    private Light light;

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
        if (light.enabled)
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
        if (light.enabled)
        {
            light.enabled = false;
        }
        else
        {
            light.enabled = true;
        }
    }




}
