using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Interactable
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
        animator = GetComponentInParent<Animator>();
    }

    protected override void OnHoveredOver(Interactable i)
    {
        SetSafeHoverText();
    }

    private void SetSafeHoverText()
    {
        if (IsOpen)
        {
            interactText = "Close safe";
        }
        else
        {
            interactText = "Open safe";
        }
    }

    public override void Interact()
    {
        ToggleSafe();
    }

    private void ToggleSafe()
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
