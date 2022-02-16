using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerLabel;

    float time;

    public void Start()
    {
        time = 0;
    }

    public void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 120;
        var seconds = time % 60;
        var miliseconds = (time * 1000) % 1000 - 1;

        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, miliseconds);
    }


}
