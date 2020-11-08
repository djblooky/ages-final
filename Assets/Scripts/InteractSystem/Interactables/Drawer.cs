﻿using UnityEngine;

public class Drawer : Interactable
{
    private Animator animator;
    private readonly int isOpenAnimatorParam = Animator.StringToHash("isOpen");

    private bool isOpen = false;
    private bool IsOpen
    {
        get { return isOpen; }

        set
        {
            animator.SetBool(isOpenAnimatorParam, value);
            isOpen = value;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnHoveredOver(Interactable i)
    {
        SetDrawerHoverText();
    }

    private void SetDrawerHoverText()
    {
        if (IsOpen)
        {
            textToDisplayOnHover = "Close drawer";
        }
        else
        {
            textToDisplayOnHover = "Open drawer";
        }
    }

    public override void Interact()
    {
        ToggleDrawer();
    }

    private void ToggleDrawer()
    {
        if (IsOpen)
        {
            IsOpen = false;
        }
        else
        {
            IsOpen = true;
        }
    }
}
