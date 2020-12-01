using UnityEngine;
using VHS;

public class Safe : Openable
{
    [Header("Safe.cs")]
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private Transform safeLock; //todo: rotate this transform with the combo

    [Header("Safe UI")]
    [SerializeField]
    private GameObject safeUIPanel;

    [Header("Safe Code")]
    [SerializeField]
    [Range(0, 59)]
    private int safeSolutionNum1;

    [SerializeField]
    [Range(0, 59)]
    private int safeSolutionNum2;

    [SerializeField]
    [Range(0, 59)]
    private int safeSolutionNum3; 

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        inputHandler.ResetInputData();
        inputHandler.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        safeUIPanel.SetActive(true);
    }

    //link button
    public void CloseSafeUI()
    {
        inputHandler.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        safeUIPanel.SetActive(false);
    }

    void OnCheckSafeEntry(int num1, int num2, int num3)
    {
        if(num1 == safeSolutionNum1 && num2 == safeSolutionNum2 && num3 == safeSolutionNum3)
        {
            isLocked = false;
        }
    }
}
