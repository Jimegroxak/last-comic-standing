using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float roundTime = 60f;
    private float timerValue;

    public event EventHandler OnTimerFinished;

    [SerializeField] private Image timerImage;

    private void Start() 
    {
        timerValue = roundTime;      
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (GameController.Instance.isAlive)
        timerValue -= Time.deltaTime;
        timerImage.fillAmount = timerValue / roundTime;
        if (timerValue <= 0)
        {
            OnTimerFinished?.Invoke(this, EventArgs.Empty);
            timerValue = roundTime;
        }
    }

    public float GetTimerValue()
    {
        return timerValue;
    }
}
