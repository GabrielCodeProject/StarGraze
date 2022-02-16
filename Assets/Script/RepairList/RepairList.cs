using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RequireListTool
{
    Hammer,
    Extincteur,
    Welder,
    Wrench,
}
public static class RepairList
{

    public static int enumLength = Enum.GetNames(typeof(RequireListTool)).Length;

    public static List<RequireListTool> generateListOrders(int numberToolNeeded)
    {
        List<RequireListTool> toolList = new List<RequireListTool>();
        int randomTool = 0;
        for (int i = 0; i < numberToolNeeded; i++)
        {
            randomTool = UnityEngine.Random.Range(0, enumLength);
            toolList.Add((RequireListTool)randomTool);
        }


        foreach (RequireListTool toolID in toolList)
        {
            //Debug.Log("Tool ID in list : " + toolID);
        }
        //Debug.Log("Random number :" + randomTool);
        //Debug.Log(enumLength);
        return toolList;
    }
}
