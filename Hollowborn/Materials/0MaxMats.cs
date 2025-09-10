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
private VindicatorBadge VB
{
    get => _VB ??= new VindicatorBadge();
    set => _VB = value;
}
private VindicatorBadge _VB;

private DeathsPower DP
{
    get => _DP ??= new DeathsPower();
    set => _DP = value;
}
private DeathsPower _DP;

private GraceOrb GO
{
    get => _GO ??= new GraceOrb();
    set => _GO = value;
}
private GraceOrb _GO;

private GramielsEmblem GE
{
    get => _GE ??= new GramielsEmblem();
    set => _GE = value;
}
private GramielsEmblem _GE;

private VindicatorCrest VC
{
    get => _VC ??= new VindicatorCrest();
    set => _VC = value;
}
private VindicatorCrest _VC;

private HollowSoul HS
{
    get => _HS ??= new HollowSoul();
    set => _HS = value;
}
private HollowSoul _HS;


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