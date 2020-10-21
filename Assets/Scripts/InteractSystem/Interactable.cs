using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    private Color hoverColor;

    [SerializeField]
    public string interactText;

    protected MeshRenderer meshRenderer;
    protected Color defaultColor;

    private void Start()
    {
        if (hoverColor == null)
            hoverColor = Color.white;

        meshRenderer = GetComponent<MeshRenderer>();
        tag = "Interactable";
    }

    protected virtual void OnHoveredOver(Interactable g)
    {
        //g.meshRenderer.material.color = hoverColor;
    }

    protected virtual void OnHoveredOff()
    {
        // g.meshRenderer.material.color = defaultColor;
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
