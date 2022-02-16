using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caller : MonoBehaviour
{
    float lastCallTime, nextCallTime, callTimer;
    float minTimer, maxTimer;
    float timeUntilEnd, endTime, endTimer;

    public void Init()
    {
        minTimer = 20;
        maxTimer = 60;
        endTime = 30;
        lastCallTime = 0;
        callTimer = 0;
        endTimer = 0;
        nextCallTime = Random.Range(minTimer, maxTimer);

        gameObject.SetActive(false);
    }

    public void updateCaller()
    {
        if (!gameObject.activeSelf)
        {
            callTimer += Time.deltaTime;
            if (lastCallTime + callTimer >= nextCallTime)
            {
                callTimer = 0;
                gameObject.SetActive(true);
                lastCallTime = Time.time;
                timeUntilEnd = lastCallTime + endTime;
                nextCallTime = Random.Range(minTimer, maxTimer);
            }
        }

        if (gameObject.activeSelf)
        {
            endTimer += Time.deltaTime;
            if (lastCallTime + endTimer >= timeUntilEnd)
            {
                endTimer = 0;
                lastCallTime = Time.time;
                GameFlow gameFlow = (GameFlow)FlowManager.Instance.currentFlow;
                gameFlow.EndGame();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if (p)
            p.canAnswer = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if (p)
            p.canAnswer = false;
    }

    public void Hangup()
    {
        gameObject.SetActive(false);
        endTimer = 0;
    }
}
