public class InteractLight : Interactable
{
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
            //turn light emission off
            isOn = false;
        }
        else
        {
            //turn light emission on
            isOn = true;
        }
    }




}
