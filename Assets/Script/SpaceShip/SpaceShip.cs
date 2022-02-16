using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip
{
    const float OXYGENELOST = 0.5f;
    float oxygeneLostPerSeconds = 0;
    float oxygene = 100;
    float oxygeneSeconds = 1;
    float oxygeneTime = 0;
    List<Room> mySpaceShip;
    float nextTime;
    float modifier;
    float minTime = 10;
    float maxTime = 25;

    public void init()
    {
        mySpaceShip = new List<Room>();
        nextTime = 0.0f;
        modifier = Random.Range(minTime, maxTime);
        nextTime = Time.time + modifier;
        mySpaceShip.AddRange(Object.FindObjectsOfType<Room>());

        foreach (Room r in mySpaceShip)
        {
            r.init();
        }
        
    }

    public void UpToDate()
    {
        if(oxygene <= 0)
        {
            GameFlow gameFlow = (GameFlow)FlowManager.Instance.currentFlow;
            gameFlow.EndGame();
        }

        if (mySpaceShip.Count > 0)
        {
            if (Time.time > nextTime)
            { int random = Random.Range(0, mySpaceShip.Count);     
                mySpaceShip[random].destroyRoom();
                modifier = Random.Range(minTime, maxTime);
                nextTime = Time.time + modifier;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            int random = Random.Range(0, mySpaceShip.Count);
            mySpaceShip[random].destroyRoom();
            modifier = Random.Range(minTime, maxTime);
            nextTime = Time.time + modifier;
        }


        Debug.Log("Oxygene: "+oxygene);
        Debug.Log("OxygeneLostSecondes: " + oxygeneLostPerSeconds);

        if (Time.time > oxygeneTime && oxygeneLostPerSeconds > 0) {    

            oxygene -= oxygeneLostPerSeconds;

            oxygeneTime = Time.time + oxygeneSeconds;

            UIManager.Instance.Oxygene(oxygene);

        }

    }

    public void AddOxygeneLost() {
        oxygeneLostPerSeconds +=  OXYGENELOST;
    }

    public void RemoveOxygeneLost()
    {
        oxygeneLostPerSeconds -= OXYGENELOST;
    }

    public void AddOxygene(float lvl) {

        oxygene += lvl;

        if (oxygene > 100)
            oxygene = 100;
    }
}
