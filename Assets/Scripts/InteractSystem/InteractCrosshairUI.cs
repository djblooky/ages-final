﻿using UnityEngine;
using UnityEngine.UI;

public class InteractCrosshairUI : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultCrosshair, examineCrosshair, handCrosshair, lookCrosshair;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void OnHoveredOverInteractable(Interactable i)
    {
        switch (i)
        {
            case Note n:
                image.sprite = examineCrosshair;
                break;
            case Toggleable t:
            case Door d:
            case Drawer dr:
                image.sprite = handCrosshair;
                break;
            default:
                image.sprite = lookCrosshair;
                break;
        }

        /*case Lockable: if locked sprite = lockCrosshair
         * else sprite = handCrosshair
         */
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
