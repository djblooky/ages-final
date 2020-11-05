using TMPro;
using System;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public static event Action TimerRanOut;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private float timeRemaining = 300f;

    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Timer is out");
                timeRemaining = 0;
                timerIsRunning = false;
                TimerRanOut?.Invoke();
            }
        }
    }

    private void DisplayTime(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
