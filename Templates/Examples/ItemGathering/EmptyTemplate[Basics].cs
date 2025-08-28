/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Quests;

public class DefaultTemplate
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;

    private CoreAdvanced Adv = new();
    private CoreFarms Farm = new();
    private CoreStory Story = new();
    private CoreDailies Daily = new();

    public void ScriptMain(IScriptInterface Bot)
    {
        // Core.BankingBlackList.AddRange(new[] { "item1", "Item2", "Etc" });
        Core.SetOptions();

        Example();
        // Core.Logger($"Mob HP: {Core.GetMonsterHP("4")}");

        // Core.Join("doompirate", "r5", "LEfT");
        // foreach (int mobId in new[] { 5, 4, 7, 6, 9, 8, 11, 10 })
        // {
        //     Bot.Log($"Killing {mobId}");
        //     Bot.Kill.Monster(mobId);
        //     Bot.Wait.ForMonsterDeath(mobId);
        // }


        Core.SetOptions(false);
    }

    public void Example(bool TestMode = false)
    {
        Core.FarmingLogger("Gallaeon's Piece of Eight", 99);
        Core.RegisterQuests(9355);
        Core.EquipClass(ClassType.Solo);
        Core.Join("doompirate");

        bool restartKills = false;

        while (!Bot.ShouldExit && !Core.CheckInventory("Gallaeon's Piece of Eight", 99))
        {
        RestartKills:
            if (restartKills)
            {
                Bot.Map.Reload();
                Bot.Wait.ForMapLoad("doompirate");
                restartKills = false;
            }

            // Ensure player is in the correct cell
            while (!Bot.ShouldExit && Bot.Player.Cell != "r5")
            {
                Core.Jump("r5", "Left");
                Core.Sleep();
            }

            Bot.Player.SetSpawnPoint();

            // Kill mobs in specified order
            foreach (int mobId in new[] { 5, 4, 7, 6, 9, 8, 11, 10 })
            {
                Monster? mon = Bot.Monsters.CurrentAvailableMonsters.FirstOrDefault(x => x.MapID == mobId);
                if (mon == null)
                {
                    Core.Logger($"Skipping mob {mobId}, not found.");
                    continue;
                }

                Core.Logger($"Attacking: {mon.Name}[{mon.MapID}]");

                while (!Bot.ShouldExit)
                {
                    // Handle death: wait for respawn, then restart room
                    while (!Bot.ShouldExit && !Bot.Player.Alive){}

                    if (!Bot.Player.Alive)
                    {
                        restartKills = true;
                        goto RestartKills;
                    }

                    // Attack first
                    if (!Bot.Player.HasTarget)
                        Bot.Combat.Attack(mobId);

                    Bot.Sleep(1500); // slight delay before checking HP

                    if (Core.GetMonsterHP(mobId.ToString()) <= 0)
                    {
                        Bot.Combat.CancelTarget();
                        Core.Logger($"Killed: {mon.Name}[{mon.MapID}]");
                        break;
                    }
                }
            }

            // Final mob in the room
            Bot.Kill.Monster(12);
        }

        // Optional Test Mode
        if (TestMode)
        {
            if (Core.CheckInventory("item", 1))
                return;

            Core.RegisterQuests(000);
            while (!Bot.ShouldExit && !Core.CheckInventory("item", 1))
            {
                Core.HuntMonster("map", "mob", "item", 1, isTemp: false, log: false);
            }
            Core.CancelRegisteredQuests();
        }
    }


}



