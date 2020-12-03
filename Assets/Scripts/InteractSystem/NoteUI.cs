using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VHS;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Image noteImage;
    [SerializeField] private TMP_Text noteText;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void OnOpenedNote(string text)
    {
        inputHandler.ResetInputData();
        inputHandler.enabled = false;
        
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        noteText.text = text;
    }

    // links to button event
    public void CloseNote()
    {
        inputHandler.enabled = true;

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        Note.OpenedNote += OnOpenedNote;
    }

    private void OnDisable()
    {
        Note.OpenedNote -= OnOpenedNote;
    }
}
