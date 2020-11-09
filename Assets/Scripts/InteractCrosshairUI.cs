using UnityEngine;
using UnityEngine.UI;

public class InteractCrosshairUI : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultCrosshair, interactCrosshair;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void OnHoveredOverInteractable(Interactable i)
    {
        image.sprite = interactCrosshair;
    }

    private void OnHoveredOffInteractable()
    {
        image.sprite = defaultCrosshair;
    }

    private void OnEnable()
    {
        PlayerRaycast.HoveredOver += OnHoveredOverInteractable;
        PlayerRaycast.HoveredOff += OnHoveredOffInteractable;
    }

    private void OnDisable()
    {
        PlayerRaycast.HoveredOver -= OnHoveredOverInteractable;
        PlayerRaycast.HoveredOff -= OnHoveredOffInteractable;
    }
}
