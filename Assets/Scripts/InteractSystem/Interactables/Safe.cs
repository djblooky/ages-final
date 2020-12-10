using SafeUnlockSystem;
using UnityEngine;
using VHS;

public class Safe : Openable
{
    [Header("Safe.cs")]
    [SerializeField]private InputHandler inputHandler;

    [SerializeField]private SafeController safeController;

    private bool UIOpen = false;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
        safeController.Initialize();
    }

    public override void Interact()
    {
        base.Interact();

        if (!UIOpen)
        {
            inputHandler.ResetInputData();
            inputHandler.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            safeController.ShowSafeLock();
            UIOpen = true;
            tag = "Untagged";
        }
    }

    private void Update()
    {
        safeController.UpdateSafe();
    }

    //links to button
    public void UpKeyButtonPressed(int number)
    {
        safeController.UpKey(number);
    }

    //links to button
    public void AcceptKeyButtonPressed()
    {
        safeController.AcceptKey();
    }

    private void OnSafeOpened()
    {
        inputHandler.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = false;
        IsOpen = true;
        tag = "Untagged";
    }

    private void OnSafeUIClosed()
    {
        inputHandler.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UIOpen = false;
        tag = "Interactable";
    }

    private void OnEnable()
    {
        SafeController.SafeOpened += OnSafeOpened;
        SafeController.SafeUIClosed += OnSafeUIClosed;
    }

    private void OnDisable()
    {
        SafeController.SafeOpened -= OnSafeOpened;
        SafeController.SafeUIClosed -= OnSafeUIClosed;
    }
}
