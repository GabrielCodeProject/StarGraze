using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private static PlayerManager instance = null;
    private Player player;

    private PlayerManager()
    {
    }

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }

    public void init()
    {
        GameObject temp = GameObject.Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject))) as GameObject;
        player = temp.GetComponent<Player>();
        player.InitPlayer();

    }

    public void Update() {
        player.UpdatePlayer();

    }

    public void FixedUpdate() {
        player.FixedUpdatePlayer();

    }


        
}
