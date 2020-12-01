using TMPro;
using UnityEngine;
using VHS;

public class ExamineUI : MonoBehaviour
{
    [SerializeField] private GameObject examineCamera;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private TMP_Text objectName, objectText;

    private void OnExamined(string objectName, string interactText)
    {
        inputHandler.ResetInputData();
        inputHandler.enabled = false;

        objectText.text = interactText;
        this.objectName.text = objectName;

        examineCamera.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //hooks up to button
    public void CloseExamineUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        examineCamera.SetActive(false);

        inputHandler.enabled = true;
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
