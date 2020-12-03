using SafeUnlockSystem;
using UnityEngine;
using VHS;

public class Safe : Openable
{
    [Header("Safe.cs")]
    [SerializeField]private InputHandler inputHandler;

    //[SerializeField]private SafeController safeController;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        //inputHandler.ResetInputData();
        //inputHandler.enabled = false;
        //Cursor.lockState = CursorLockMode.None;
       // Cursor.visible = true;

        //safeUIPanel.SetActive(true);
    }

    //link button
    public void CloseSafeUI()
    {
        inputHandler.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //safeUIPanel.SetActive(false);
    }

}
