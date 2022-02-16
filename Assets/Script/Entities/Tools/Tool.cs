using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{
    private int durability, durabilityCost, durabilityMax;
    private RequireListTool type;
    private double repairSpeed;

    virtual public void InitTool(RequireListTool type_, int durabilityMax_, int durabilityCost_)
    {
        type = type_;
        durabilityMax = durabilityMax_;
        durability = durabilityMax;
        durabilityCost = durabilityCost_;
    }

    virtual public void UpdateTool()
    {

    }

    virtual public void Use(Tiles t)
    {
        if (durability > 0)
        {
            durability -= durabilityCost;
            t.repairTile(type);
            updateUI();

        }
    }

    void updateUI()
    {
        if (type == RequireListTool.Extincteur)
        {
            UIManager.Instance.changeFuelExtincteur(durability);

        }
        else if (type == RequireListTool.Welder)
        {
            UIManager.Instance.changeFuelWelder(durability);

        }


    }



    public void FillEnergy()
    {
        Debug.Log("Refilling.....");
        durability = durabilityMax;
        updateUI();
    }
}
