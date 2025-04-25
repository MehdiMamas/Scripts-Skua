/*
name: Glacera REP
description: This script will farm Glacera reputation to rank 10.
tags: glacera, rank, rep, reputation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/CoreStory.cs

using Skua.Core.Interfaces;
public class GlaceraREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();
    public GlaceraStory GlaceraStory = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);

        GlaceraStory.DoAll();
        Farm.GlaceraREP();

        Core.SetOptions(false);
    }
}
