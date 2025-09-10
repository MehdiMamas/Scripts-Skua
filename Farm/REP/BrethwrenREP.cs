/*
name: Brethwren REP [Seasonal]
description: This script will farm Brethwren reputation to rank 10.
tags: reputation, rep, seasonal, rank, farm
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Seasonal/HarvestDay/CoreHarvestDay.cs

using Skua.Core.Interfaces;
public class BrethwrenREPFarm
{
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreHarvestDay HarvestDay
{
    get => _HarvestDay ??= new CoreHarvestDay();
    set => _HarvestDay = value;
}
public CoreHarvestDay _HarvestDay;

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
        HarvestDay.BirdsWithHarms();

        Farm.BrethwrenREP();
    }
}
