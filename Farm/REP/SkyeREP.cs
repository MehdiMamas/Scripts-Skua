/*
name: Skye REP
description: This script will farm Skye reputation to rank 10.
tags: skye, rep, rank, reputation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/AgeOfRuin/CoreAOR.cs
using Skua.Core.Interfaces;
public class Skye
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

private CoreAOR AOR
{
    get => _AOR ??= new CoreAOR();
    set => _AOR = value;
}
private CoreAOR _AOR;

private CoreSoW SoW
{
    get => _SoW ??= new CoreSoW();
    set => _SoW = value;
}
private CoreSoW _SoW;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        AOR.SeaVoice();
        Farm.SkyeREP();

        Core.SetOptions(false);
    }
}
