using System;
using System.Net.Http.Headers;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float TimeRemain;    
    void Update()
    {
        if(TimeRemain > 0)
        {
            TimeRemain -= Time.deltaTime;
        }
        else if(TimeRemain < 0)
        {
            TimeRemain = 0;
        }

        int minutes = Mathf.FloorToInt(TimeRemain/60);
        int seconds = Mathf.FloorToInt(TimeRemain % 60);
        timerText.text = string.Format("{0}:{1}",minutes,seconds);

    }
}
