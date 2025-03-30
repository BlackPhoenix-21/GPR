using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using AC;
using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    private float timer = 300f;
    public bool timerActive = false;
    public bool timerFinished = false;
    public bool timerStarted = false;
    private string timerString;
    private GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("TimerCanvas");
    }
    void Update()
    {
        if (!timerActive)
        {
            canvas.SetActive(false);
            return;
        }
        else
        {
            canvas.SetActive(true);
        }

        if (!timerStarted)
        {
            timerStarted = true;
            StartCoroutine(CountdownTimer());
        }

        timerString = "Timer: ";
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerString += string.Format("{0:00}:{1:00}", minutes, seconds);
        canvas.GetComponentInChildren<TMP_Text>().text = timerString;

        if (timer <= 0)
        {
            timerFinished = true;
        }

        if (timerFinished)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator CountdownTimer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }
    }
}