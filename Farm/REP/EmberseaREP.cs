/*
name: Embersea REP
description: This script will farm Embersea reputation to rank 10.
tags: embersea, ember sea, ember, sea, reputation, rank, rep
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs
using Skua.Core.Interfaces;
public class EmberseaREP
{
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreFireIsland FI
{
    get => _FI ??= new CoreFireIsland();
    set => _FI = value;
}
public CoreFireIsland _FI;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);
        FI.Feverfew();
        Farm.EmberseaREP();

        Core.SetOptions(false);
    }
}
