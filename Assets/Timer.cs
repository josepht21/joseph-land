using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Text bestTimeText;
    [SerializeField] string bestTimeStorageName;

    public float currentTime;
    private bool runTimer = true;

    private void Start()
    {
        UpdateBestTimeText();
    }

    void Update()
    {
        if(runTimer)
        {
            currentTime = currentTime += Time.deltaTime;
            timerText.text = $"Current: {currentTime.ToString("0.00")}";
        }
    }

    public void StopTimer()
    {
        runTimer = false;
    }

    public void CheckBestTime()
    {
        if(currentTime < PlayerPrefs.GetFloat(bestTimeStorageName, float.PositiveInfinity))
        {
            PlayerPrefs.SetFloat(bestTimeStorageName, currentTime);
        }
    }

    public void UpdateBestTimeText()
    {
        bestTimeText.text = $"Best: {PlayerPrefs.GetFloat(bestTimeStorageName, float.NaN).ToString("0.00")}";
    }
}
