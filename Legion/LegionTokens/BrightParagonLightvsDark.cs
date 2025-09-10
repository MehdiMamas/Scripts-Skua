/*
name: BrightParagonLightvsDark
description: Uses the appropriate pet to farm Legion Tokens
tags: legion, legion token
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class BrightParagonLightvsDark
{
    public CoreBots Core => CoreBots.Instance;
public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Legion.LTBrightParagon();

        Core.SetOptions(false);
    }
}
