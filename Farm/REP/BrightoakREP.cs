/*
name: Brightoak REP
description: This script will farm Brightoak REP to rank 10.
tags: bright, oak, reputation, rep, rank, farm
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/BrightOak.cs

using Skua.Core.Interfaces;
public class BrightoakREP
{
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public BrightOak BrightOak
{
    get => _BrightOak ??= new BrightOak();
    set => _BrightOak = value;
}
public BrightOak _BrightOak;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoRep();

        Core.SetOptions(false);
    }

    public void DoRep()
    {
        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);

        BrightOak.doall(true);
        Farm.BrightoakREP();

    }
}
