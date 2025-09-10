/*
name: TheGameofGemstones(Gold[Members])
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class TheGameofGemstones
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Tendurrr The Assistant", "Unidentified 13" });
        Core.SetOptions();

        Gold();

        Core.SetOptions(false);
    }

    public void Gold(int quant = 100000000)
    {
        if (!Core.IsMember)
            return;

        Nation.FarmUni13(1);
        if (!Core.CheckInventory("Tendurrr The Assistant"))
            Core.KillMonster("tercessuinotlim", "m2", "Left", "*", "Tendurrr The Assistant", isTemp: false);

        Bot.Quests.UpdateQuest(597);
        Core.RegisterQuests(5815);
        while (!Bot.ShouldExit && Bot.Player.Gold < quant)
        {
            Nation.ApprovalAndFavor(1, 0);
            Core.HuntMonster("Lavarun", "Mega Tyndarius", "Archfiend's Amber", isTemp: false);
            Core.KillMonster("Catacombs", "Boss2", "Left", "Dr. De'Sawed", "Phantasmia's Charoite", isTemp: false);
            Farm.BludrutBrawlBoss("Yoshino's Citrine", 1);
            Core.HuntMonster("Wolfwing", "Wolfwing", "Tendou's Moonstone", isTemp: false);
            Core.HuntMonsterMapID("baconcatyou", 1, "Asuka's Ruby", isTemp: false);
        }
        Core.CancelRegisteredQuests();
    }
}
