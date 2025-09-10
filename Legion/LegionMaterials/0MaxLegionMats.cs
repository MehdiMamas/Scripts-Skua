/*
name: 0MaxLegionMats
description: Farms the max stack of all the legion materials using various methods based off the pets / quest you have avaiable.
tags: legion, dage, all, 🖕, you
*/

//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Legion/LegionMaterials/LetitBurn(SoulEssence).cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Legion/SwordMaster.cs
//cs_include Scripts/Legion/YamiNoRonin/CoreYnR.cs
//cs_include Scripts/Legion/Various/LegionBonfire.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs

using Skua.Core.Interfaces;

public class MaxLegionMats
{
    public CoreBots Core => CoreBots.Instance;
public CoreLegion CL
{
    get => _CL ??= new CoreLegion();
    set => _CL = value;
}
public CoreLegion _CL;

public LetItBurn LetItBurn
{
    get => _LetItBurn ??= new LetItBurn();
    set => _LetItBurn = value;
}
public LetItBurn _LetItBurn;

public AnotherOneBitesTheDust AnotherOneBitesTheDust
{
    get => _AnotherOneBitesTheDust ??= new AnotherOneBitesTheDust();
    set => _AnotherOneBitesTheDust = value;
}
public AnotherOneBitesTheDust _AnotherOneBitesTheDust;

public CoreYnR CoreYnR
{
    get => _CoreYnR ??= new CoreYnR();
    set => _CoreYnR = value;
}
public CoreYnR _CoreYnR;


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
        LetItBurn.SoulEssence();
        AnotherOneBitesTheDust.SoulSand();
        CoreYnR.YokaiSwordScroll();
        
        // Keep pvp as the last, as it takes **FUCKING FOREVER**
        CL.DagePvP();
    }
}
