using System;
using UnityEngine;

public class EndCreditsTrigger : MonoBehaviour
{
    public static event Action EndCreditsTriggered;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            EndCreditsTriggered?.Invoke();
        }
    }
}
