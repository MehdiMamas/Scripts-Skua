/*
name: Yew Mountains REP
description: This script will farm Yew Mountains REP to rank 10.
tags: yew mountains, rep, reputation, farm
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
public class YewMountainsREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Farm.YewMountainsREP();

        Core.SetOptions(false);
    }
}
