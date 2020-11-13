using UnityEngine;
using VHS;

public class Safe : Openable
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private Transform safeLock; //todo: rotate this transform with the combo

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

    [Header("Safe UI")]
    [SerializeField]
    private GameObject safeUIPanel;

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

    void OnChangedSafeEntry(int num1, int num2, int num3)
    {
        if(num1 == safeSolutionNum1 && num2 == safeSolutionNum2 && num3 == safeSolutionNum3)
        {
            isLocked = false;
        }
    }
}
