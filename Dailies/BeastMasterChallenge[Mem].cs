/*
name: Beast Master Challenge Daily
description: This script does BeastMaster Challenge daily quest.
tags: daily, beast master challenge
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class BeastMasterChallenge
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

        Daily.BeastMasterChallenge();

        Core.SetOptions(false);
    }
}
