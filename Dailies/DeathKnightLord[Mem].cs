/*
name: Death Knight Lord Daily
description: Death Knight Lord
tags: daily, death knight lord, member, class
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class DeathKnightLord
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Daily.DeathKnightLord();

        Core.SetOptions(false);
    }
}
