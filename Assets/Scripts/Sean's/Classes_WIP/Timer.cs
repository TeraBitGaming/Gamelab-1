using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// WIP.
    /// </summary>

    private float timerSecondCount = 0f;
    private bool timerEnabled;
    public bool timerAutoEnable = false;

    public Timer()
    {

    }

    private void Start()
    {
        timerEnabled = timerAutoEnable;
    }

    private void Update()
    {
        if(timerEnabled)
        {
            timerSecondCount += Time.deltaTime;
        }
    }

    public void PauseTimer()
    {
        timerEnabled = false;
    }

    public void StartTimer()
    {
        timerEnabled = true;
    }

    public void ResetTimer()
    {
        timerEnabled = false;
        timerSecondCount = 0;
    }

    public float GetTimerValue()
    {
        return timerSecondCount;
    }
}
