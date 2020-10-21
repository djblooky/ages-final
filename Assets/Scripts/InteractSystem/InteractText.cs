using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    private TMP_Text textComponent;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private void OnHoveredOverInteractable()
    {
        canvasGroup.alpha = 1;
    }

    private void OnHoveredOffInteractable()
    {
        canvasGroup.alpha = 0;
    }

    void OnInteractTextChanged(string interactText) 
    {
        textComponent.text = interactText;
    }

    private void OnEnable()
    {
        Interactable.InteractTextChanged += OnInteractTextChanged;
        InteractController.HoveredOverInteractable += OnHoveredOverInteractable;
        InteractController.HoveredOffInteractable += OnHoveredOffInteractable;
    }

    private void OnDisable()
    {
        Interactable.InteractTextChanged -= OnInteractTextChanged;
        InteractController.HoveredOverInteractable -= OnHoveredOverInteractable;
        InteractController.HoveredOffInteractable -= OnHoveredOffInteractable;
    }
}
