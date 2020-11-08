using UnityEngine;

public class Door : Interactable
{
    public static bool isLocked = true;

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

    public override void Interact()
    {
        if (isLocked)
        {
            textToDisplayOnHover = "Locked";
            //play locked sound
        }
        else
        {
            IsOpen = true;
            //play opening sound
            gameObject.tag = "Untagged"; //no longer interactable
        }  
    }
}
