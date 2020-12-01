using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineUI : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnExamined(string objectName, string interactText)
    {

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
