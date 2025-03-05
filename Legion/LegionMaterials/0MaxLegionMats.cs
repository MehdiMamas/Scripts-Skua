/*
name: 0MaxLegionMats
description: Farms the max stack of all the legion materials using various methods based off the pets / quest you have avaiable.
tags: legion, dage, all, 🖕, you
*/
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
using Skua.Core.Interfaces;

public class MaxLegionMats
{
    public CoreBots Core => CoreBots.Instance;
    public CoreNation Nation = new();
    public CoreLegion CL = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        MaxLeg();

        Core.SetOptions(false);
    }

    public void MaxLeg()
    {
        // Make sure they're part of the legion
        CL.JoinLegion();

        // Materials
        CL.ApprovalAndFavor();
        CL.FarmLegionToken();
        CL.EmblemofDage();
        CL.DarkToken();
        CL.BoneSigil();
        CL.DarkToken();
        CL.DiamondTokenofDage();
        CL.ObsidianRock();

        // Keep pvp as the last, as it takes **FUCKING FOREVER**
        CL.DagePvP();
    }
}
