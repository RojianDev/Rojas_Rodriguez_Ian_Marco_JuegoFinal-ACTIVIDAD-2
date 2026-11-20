using System;
using System.Net.Http.Headers;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float TimeRemain;    
    private bool timerEnded = false;
    void Update()
    {
        if(timerEnded) return;

        if(TimeRemain > 0)
        {
            TimeRemain -= Time.deltaTime;
        }
        else if(TimeRemain < 0)
        {
            TimeRemain = 0;
            timerEnded = true;
            GameOver.Instance.PlayerLose();
        }

        int minutes = Mathf.FloorToInt(TimeRemain/60);
        int seconds = Mathf.FloorToInt(TimeRemain % 60);
        timerText.text = string.Format("{00:00}:{01:00}",minutes,seconds);

    }
}
