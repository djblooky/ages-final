using System;
using System.Collections;
using UnityEngine;

public class EndCreditsTrigger : MonoBehaviour
{
    public static event Action EndCreditsTriggered;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(StartCreditsAfterDelay());
        }
    }

    IEnumerator StartCreditsAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        EndCreditsTriggered?.Invoke();
    }
}
