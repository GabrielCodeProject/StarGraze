using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GameFlow : Flow
{
    bool lose = false;
    override
    public void InitializeFlow()
    {
        PlayerManager.Instance.init();
        ToolsManager.Instance.init();
        SpaceShipManager.Instance.init();
        SoundManager.Initialize();
        UIManager.Instance.init();
        MeteoriteManager.Instance.init();
        CallerManager.Instance.init();
    }

    override
    public void UpdateFlow(float dt)
    {
        if (!lose)
        {
            PlayerManager.Instance.Update();
            ToolsManager.Instance.Update();
            SpaceShipManager.Instance.Update();
            UIManager.Instance.Update();
            MeteoriteManager.Instance.Update();
            CallerManager.Instance.Update();
        }
    }

    override
    public void FixedUpdateFlow(float dt)
    {
        if (!lose)
        {
            PlayerManager.Instance.FixedUpdate();
            ToolsManager.Instance.FixedUpdate();
            SpaceShipManager.Instance.FixedUpdate();
            UIManager.Instance.FixedUpdate();
        }
    }

    override
    public void CloseFlow()
    {
       
    }

    public void SetPause()
    {
       
    }

    public void Restart()
    {

        FlowManager.Instance.ChangeFlows(FlowManager.SceneNames.Game);

    }

    public void EndGame()
    {
        Debug.Log("endgame");
        lose = true;
        UIManager.Instance.EndGame();
    }
}
