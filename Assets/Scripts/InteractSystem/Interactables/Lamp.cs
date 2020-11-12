using UnityEngine;

public class Lamp : Toggleable
{
    [SerializeField]
    private Light light;

    public override void Interact()
    {
        base.Interact();
        ToggleLight();
    }

    private void ToggleLight()
    {
        if (isOn)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
