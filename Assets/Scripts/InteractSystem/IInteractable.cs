using TMPro;
using UnityEngine;

public interface IInteractable
{
    TMP_Text onHoverText { get; set; }
    Material defaultMaterial { get; set; }
    Material hoverMaterial { get; set; }

    void OnHover();


}
