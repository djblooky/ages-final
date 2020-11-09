using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool displayTextOnHover = true;

    public string nextHoverText;

    protected virtual void OnHoveredOver(Interactable i)
    {
        Debug.Log("Hovered over " + i);
    }

    protected virtual void OnHoveredOff()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacted with {gameObject}");
    }

    private void OnEnable()
    {
        PlayerRaycast.HoveredOver += OnHoveredOver;
        PlayerRaycast.HoveredOff += OnHoveredOff;
    }

    private void OnDisable()
    {
        PlayerRaycast.HoveredOver -= OnHoveredOver;
        PlayerRaycast.HoveredOff -= OnHoveredOff;
    }

}
