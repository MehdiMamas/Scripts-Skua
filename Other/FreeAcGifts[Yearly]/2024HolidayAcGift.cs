/*
name: Holdiay Ac Gift 2024
description: This script will kill burlingster in /borgars to get free 500 AC.
tags: ac, free, 500, 2024
*/
//cs_include Scripts/CoreBots.cs
using Skua.Core.Interfaces;

public class HoldiayAcGift2024
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        GetFreeAcs();
        Core.SetOptions(false);
    }

    public void GetFreeAcs()
    {
        if (Bot.Quests.IsAvailable(10035))
        {
            Core.EquipClass(ClassType.Solo);
            Core.EnsureAccept(10035);
            Core.KillMonster("borgars", "r2", "Left", "*", "Cookie Dough");
            Core.EnsureComplete(10035);
            Bot.Wait.ForQuestComplete(10035);
        }
    }
}
