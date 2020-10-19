using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public Material defaultMaterial { get; set; }
    public Material hoverMaterial { get; set; }
    public TMP_Text onHoverText { get; set; }

    public void OnHover()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
