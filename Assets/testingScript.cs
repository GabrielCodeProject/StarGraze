using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testingScript : MonoBehaviour
{
    UILink ui;
    UIGame uiGame;
    Image oxygen;
    List<int> testlist;

    //UI setting
    public float maxOxygen = 1f;
    public float currentOxygen;

    void Start()
    {
        ui = GameObject.FindGameObjectsWithTag("UILink")[0].GetComponent<UILink>();
        uiGame = new UIGame();
        uiGame.Init();

        oxygen = ui.oxygenImage;
        testlist = new List<int>();
        currentOxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        ui.oxygenImage.fillAmount -= Time.deltaTime * 0.5f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RepairList.generateListOrders(7);
            SoundManager.PlaySound(SoundManager.EnumSound.spaceHit);
            //SoundManager.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.extincteur);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.hammer);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.menuSelectionSound);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.welder);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.wrench);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            uiGame.SetHighLigthActive(RequireListTool.Extincteur);
            Debug.Log("im press?");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            uiGame.SetHighLigthActive(RequireListTool.Hammer);
            Debug.Log("im press?");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            uiGame.SetHighLigthActive(RequireListTool.Welder);
            Debug.Log("im press?");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            uiGame.SetHighLigthActive(RequireListTool.Wrench);
            Debug.Log("im press?");
        }

    }
}
