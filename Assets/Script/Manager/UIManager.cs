using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    private static UIManager instance = null;
    UIGame uigame;
    private UIManager()
    {
    }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    public void init()
    {
        uigame = new UIGame();
        uigame.Init();

    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {


    }

    public void ChangeActiveTools(RequireListTool toolID)
    {
        uigame.SetHighLigthActive(toolID);
    }

    public void Oxygene(float lvl)
    {
        uigame.Oxygene(lvl);
    }

    public void EndGame()
    {
        uigame.EndGame();
    }

    public void changeFuelWelder(float fuel)
    {
        uigame.changeFuelWelder(fuel);
    }
    public void changeFuelExtincteur(float fuel)
    {
        uigame.changeFuelExtincteur(fuel);
    }
}
