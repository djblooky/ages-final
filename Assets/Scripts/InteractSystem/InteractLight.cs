public class InteractLight : Interactable
{
    private bool isOn = false;

    private void Start()
    {
        SetLightHoverText();
    }

    private void OnClick()
    {
        ToggleLight();
    }

    private void OnHoverOver()
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
