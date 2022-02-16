using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager 
{
    private static ToolsManager instance = null;

    private ToolsManager()
    {
    }

    public static ToolsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ToolsManager();
            }
            return instance;
        }
    }

    public void init()
    {


    }

    public void Update()
    {


    }

    public void FixedUpdate()
    {


    }
}
