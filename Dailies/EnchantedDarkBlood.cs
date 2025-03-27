/*
name: Enchanted Dark Blood
description: This script will complete the daily quest for Enchanted Dark Blood.
tags: daily, dark blood,darkblood,enchanted dark blood,falguard,windren,iaste,iaste armor
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class EnchantedDarkBlood
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreDailies Daily = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Daily.EnchantedDarkBlood();

        Core.SetOptions(false);
    }
}
