/*
name: Max Hollowborn Materials
description: Farms the maximum quantity of all Hollowborn materials.
tags: hollowborn, vindicator, farm, max, materials, hbv, hollow soul, deaths power, death's power, grace orb, gramiels emblem,gramiel's emblem, vindicator crest, vindicator badge
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Hollowborn/Materials/VindicatorBadge.cs
//cs_include Scripts/Hollowborn/Materials/DeathsPower.cs
//cs_include Scripts/Hollowborn/Materials/GraceOrb.cs
//cs_include Scripts/Hollowborn/Materials/GramielsEmblem.cs
//cs_include Scripts/Hollowborn/Materials/VindicatorCrest.cs
//cs_include Scripts/Hollowborn/Materials/HollowSoul.cs

using Skua.Core.Interfaces;

public class MaxHollowbornVindicatorMats
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private VindicatorBadge VB = new();
    private DeathsPower DP = new();
    private GraceOrb GO = new();
    private GramielsEmblem GE = new();
    private VindicatorCrest VC = new();
    private HollowSoul HS = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetMax();

        Core.SetOptions(false);
    }

    public void GetMax()
    {
        HS.GetYaSoulsHeeeere();
        DP.GetDP();
        GO.GetGraceOrb();
        GE.GetGramielsEmblem();
        VC.GetVindicatorCrest();
        VB.GetVindicatorBadge();
    }
}