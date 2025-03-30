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
            StartCoroutine(Timer());
        }

        timerString = "Timer: ";
        if (timer >= 60)
        {
            timerString += (timer / 60).ToString() + ":";
            if (timer % 60 < 10)
            {
                timerString += "0";
            }
            timerString += (timer % 60).ToString();
        }
        else
        {
            timerString += timer.ToString();
        }
        canvas.GetComponentInChildren<TMP_Text>().text = timerString;

        if (timer <= 0)
        {
            timerFinished = true;
            Debug.Log("Timer finished.");
        }

        if (timerFinished)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator Timer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }
    }
}