using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeResetLevel = 5f;

    private void OnTimerRanOut()
    {
        //TODO: display death message
        StartCoroutine(ResetSceneAfterDelay());
    }

    private IEnumerator ResetSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeResetLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        DeathTimer.TimerRanOut += OnTimerRanOut;
    }

    private void OnDisable()
    {
        DeathTimer.TimerRanOut -= OnTimerRanOut;
    }
}
