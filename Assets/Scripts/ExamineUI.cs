using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VHS;

public class ExamineUI : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private TMP_Text objectName, objectText;
    
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void OnExamined(string objectName, string interactText)
    {
        inputHandler.ResetInputData();
        inputHandler.enabled = false;

        objectText.text = interactText;
        this.objectName.text = objectName;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //to do: hook up close
    private void CloseExamineUI()
    {
        inputHandler.enabled = true;
        camera.targetTexture = null;
        //lock cursor
        //hide UI
        
    }

    private void OnEnable()
    {
        Examinable.ExaminedObject += OnExamined;
    }

    private void OnDisable()
    {
        Examinable.ExaminedObject -= OnExamined;
    }

}
