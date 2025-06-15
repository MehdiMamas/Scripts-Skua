/*
name: ArmyLichWarGoldXP
description: Uses your army to gather gold and XP
tags: gold, xp, army, battleunderb
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Monsters;
using Skua.Core.Options;

public class ArmyLichWarGoldXP
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv => new();
    private CoreArmyLite Army = new();

    private static CoreBots sCore = new();
    private static CoreArmyLite sArmy = new();

    public string OptionsStorage = "ArmyLichWarGoldXP";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6,
        sArmy.player7,
        sArmy.player8,
        sArmy.player9,
        sArmy.player10,
        sArmy.player11,
        sArmy.player12,
        sArmy.player13,
        sArmy.player14,
        sArmy.player15,
        sArmy.player16,
        sArmy.player17,
        sArmy.player18,
        sArmy.player19,
        sArmy.player20,
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.Add("Grimskull's Favor");
        Core.SetOptions();

        Setup();

        Core.SetOptions(false);
    }

    public void Setup()
    {
        Core.PrivateRooms = true;
        Core.PrivateRoomNumber = Army.getRoomNr();
        Core.RegisterQuests(10278, 10279, 10280, 10282, 10283, 10284);
        Core.EquipClass(ClassType.Farm);
        string[] cells = new[] { "r2", "r3", "r4", "r5", "r6", "r7", "r8", "r9" };
        Army.AggroMonCells(cells.Take(Army.PartySize()).ToArray());
        Army.AggroMonStart("lichwar");
        Army.DivideOnCells(cells);

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(1000);
            }

            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");
            else
            {
                Bot.Wait.ForMonsterDeath();
                Bot.Combat.CancelTarget();
            }
            Bot.Sleep(500);
        }

        Army.AggroMonStop(true);
    }

}
