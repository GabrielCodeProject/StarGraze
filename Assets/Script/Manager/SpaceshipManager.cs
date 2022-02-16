using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipManager 
{
    private static SpaceShipManager instance = null;

    private SpaceShipManager()
    {
    }

    public static SpaceShipManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SpaceShipManager();
            }
            return instance;
        }
    }
    public SpaceShip krina;
    public void init()
    {
        krina = new SpaceShip();
       
        krina.init();

    }

    public void Update()
    {
        krina.UpToDate();
    }

    public void FixedUpdate()
    {


    }
}
