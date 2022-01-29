using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public string timeText;
    public UnityEvent TimerEndEvent;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
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
                TimerEndEvent.Invoke();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void addTime(int seconds){
        timeRemaining += (float) seconds;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}