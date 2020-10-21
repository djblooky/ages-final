using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static event Action<string> InteractTextChanged;

    [SerializeField]
    private Shader hoverShader;

    [SerializeField]
    protected string interactText;

    private MeshRenderer meshRenderer;
    private Shader defaultShader;

    private void Start()
    {
        if (hoverShader == null)
            hoverShader = Shader.Find("TestShader");

        meshRenderer = GetComponent<MeshRenderer>();
        defaultShader = meshRenderer.material.shader;
        tag = "Interactable";
    }

    private void OnHoveredOverInteractable()
    {
        //meshRenderer.material.shader = hoverShader;
        InteractTextChanged?.Invoke(interactText);
    }

    private void OnHoveredOffInteractable()
    {
        //meshRenderer.material.shader = defaultShader;
    }

    private void OnEnable()
    {
        InteractController.HoveredOverInteractable += OnHoveredOverInteractable;
        InteractController.HoveredOffInteractable += OnHoveredOffInteractable;
    }

    private void OnDisable()
    {
        InteractController.HoveredOverInteractable -= OnHoveredOverInteractable;
        InteractController.HoveredOffInteractable -= OnHoveredOffInteractable;
    }
}
