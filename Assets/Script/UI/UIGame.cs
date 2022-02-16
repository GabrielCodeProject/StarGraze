using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame
{
    UILink ui;
    Image toolBox1;
    Image toolBox2;
    Image toolBox3;
    Image toolBox4;

    public bool isSelected = false;
    List<Image> toolList;
    public void Init()
    {
        toolList = new List<Image>();
        ui = GameObject.FindGameObjectWithTag("UILink").GetComponent<UILink>();
        //asigne all image with is ui element
        toolBox1 = ui.tool1;
        toolBox2 = ui.tool2;
        toolBox3 = ui.tool3;
        toolBox4 = ui.tool4;

        //add all image to list
        toolList.Add(toolBox1);
        toolList.Add(toolBox2);
        toolList.Add(toolBox3);
        toolList.Add(toolBox4);
    }

    public void SetHighLigthActive(RequireListTool toolID)
    {

        for (int i = 0; i < toolList.Count; i++)
        {
            toolList[i].color = Color.black;
        }
        toolList[(int)toolID].color = Color.green;

    }

    public void Oxygene(float oxylvl) {

        ui.oxygenImage.fillAmount = oxylvl / 100;
    }

    public void EndGame()
    {
        ui.endgame.SetActive(true);
    }

    public void changeFuelExtincteur(float fuel) {

        ui.fuelExtin.fillAmount = fuel / 100;

    }


    public void changeFuelWelder(float fuel)
    {
        ui.fuelWelder.fillAmount = fuel / 100;
    }


}
