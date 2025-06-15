/*
name: MoreSkullsWorldBoss
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Monsters;
using Skua.Core.Options;

public class MoreSkullsWorldBoss
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv => new();
    private CoreArmyLite Army = new();


    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.Add("Pristine Skull");
        Core.SetOptions();

        Core.OneTimeMessage("WARNING", "During the script, when it Does the zone bit, there will be a momentary Freeze (blame flash), dw about it itll continue", true, true);
        Setup();

        Core.SetOptions(false);
    }

    public void Setup()
    {
        Bot.Events.RunToArea += Event_RunToArea;
        Core.EquipClass(ClassType.Solo);
        Core.AddDrop("Pristine Skull");
        if (Core.isCompletedBefore(10286))
            Core.RegisterQuests(10286);
        Bot.Options.AttackWithoutTarget = true;
        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "MoreSkulls")
                Core.Join($"MoreSkulls", "r2", "Left");
            if (Bot.Player.Cell != "r2")
                Core.Jump("r2");

            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");
            else
            {
                Bot.Wait.ForMonsterDeath();
                Bot.Combat.CancelTarget();
            }
            Bot.Sleep(500);
        }
        Bot.Options.AttackWithoutTarget = false;
        Bot.Events.RunToArea -= Event_RunToArea;
    }

    void Event_RunToArea(string zone)
    {
        switch (zone.ToLower())
        {
            case "a":
                if (Bot.Player.Position.X >= 685 && Bot.Player.Position.X <= 869
                    && Bot.Player.Position.Y >= 400 && Bot.Player.Position.Y <= 409)
                    return; // Already in Zone A, no need to move

                // Zone A area: x: 685–869, y: 400–409
                Bot.Player.WalkTo(
                    Bot.Random.Next(685, 870),  // max is exclusive
                    Bot.Random.Next(400, 410),
                    speed: 8
                );
                Bot.Events.RunToArea += Event_RunToArea;
                break;

            case "b":
                // Zone B area: x: 646–861, y: 333–367
                if (Bot.Player.Position.X >= 646 && Bot.Player.Position.X <= 861
                    && Bot.Player.Position.Y >= 333 && Bot.Player.Position.Y <= 367)
                    return; // Already in Zone B, no need to move

                Bot.Player.WalkTo(
                    Bot.Random.Next(646, 862),
                    Bot.Random.Next(333, 368),
                    speed: 8
                );
                Bot.Events.RunToArea += Event_RunToArea;
                break;

            case null:
                break;
        }
    }

}
