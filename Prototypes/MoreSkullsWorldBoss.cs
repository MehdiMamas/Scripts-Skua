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
        Bot.Events.ExtensionPacketReceived += Fuckyou;
        Core.EquipClass(ClassType.Solo);
        Core.AddDrop("Pristine Skull");
        if (Core.isCompletedBefore(10286))
            Core.RegisterQuests(10286);

        Bot.Options.AttackWithoutTarget = true;

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
                Bot.Sleep(1000);

            if (Bot.Map.Name != "MoreSkulls")
                Core.Join("MoreSkulls", "r2", "Left");

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

        Bot.Events.ExtensionPacketReceived -= Fuckyou;
        Bot.Options.AttackWithoutTarget = false;
    }

    DateTime lastZoneChange = DateTime.MinValue;
    readonly TimeSpan ZoneChangeCooldown = TimeSpan.FromSeconds(2);
    string currentZone = "";
    Task? zoneMovementTask;

    void Fuckyou(dynamic packet)
    {
        string? type = packet["params"]?.type;
        if (type != "json")
            return;

        dynamic? data = packet["params"]?.dataObj;
        string? cmd = data?.cmd?.ToString();
        if (cmd != "event")
            return;

        dynamic? args = data?.args;
        if (args == null)
        {
            Core.Logger("[Fuckyou] args is null");
            return;
        }

        string? zone = args.zoneSet?.ToString()?.Trim();
        if (string.IsNullOrEmpty(zone))
        {
            Core.Logger("[Fuckyou] zoneSet missing or empty");
            return;
        }

        if (zone == currentZone)
        {
            Core.Logger($"[Fuckyou] Already in zone {zone}, skipping");
            return;
        }

        if (DateTime.Now - lastZoneChange < ZoneChangeCooldown)
        {
            Core.Logger($"[Fuckyou] Zone change throttled: {zone}");
            return;
        }

        currentZone = zone;
        lastZoneChange = DateTime.Now;
        Core.Logger($"[Fuckyou] zoneSet = {zone}");

        // Cancel ongoing movement task if any, then start new
        if (zoneMovementTask is { IsCompleted: false })
            return; // Avoid overlapping moves - or optionally cancel with a CancellationToken if you want to support that

        zoneMovementTask = Task.Run(async () =>
        {
            await Task.Delay(300); // Let frame settle, helps on Wi-Fi lag

            int x = 0, y = 0;
            switch (zone)
            {
                case "A":
                    if (Bot.Player.Position.X >= 685 && Bot.Player.Position.X <= 869 &&
                        Bot.Player.Position.Y >= 400 && Bot.Player.Position.Y <= 409)
                        return;

                    x = Bot.Random.Next(685, 870);
                    y = Bot.Random.Next(400, 410);
                    Core.Logger($"[Fuckyou] Moving to Zone A: ({x}, {y})");
                    break;

                case "B":
                    if (Bot.Player.Position.X >= 646 && Bot.Player.Position.X <= 861 &&
                        Bot.Player.Position.Y >= 333 && Bot.Player.Position.Y <= 367)
                        return;

                    x = Bot.Random.Next(646, 862);
                    y = Bot.Random.Next(333, 368);
                    Core.Logger($"[Fuckyou] Moving to Zone B: ({x}, {y})");
                    break;

                default:
                    Core.Logger($"[Fuckyou] Unknown zone: {zone}");
                    return;
            }

            Bot.Player.WalkTo(x, y, speed: 8);
        });
    }


}
