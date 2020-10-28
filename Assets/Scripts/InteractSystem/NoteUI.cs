using UnityEngine;
using UnityEngine.UI;
using VHS;

public class NoteUI : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private Image noteImage;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void OnOpenedNote(Sprite s)
    {
        inputHandler.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        noteImage.sprite = s;
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
