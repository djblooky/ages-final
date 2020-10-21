using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    [SerializeField]
    Image noteImage;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void OnOpenedNote(Sprite s)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        noteImage.sprite = s;
    }

    // links to button event
    public void CloseNote()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        InteractReadable.OpenedNote += OnOpenedNote;
    }

    private void OnDisable()
    {
        InteractReadable.OpenedNote -= OnOpenedNote;
    }
}
