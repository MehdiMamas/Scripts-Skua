/*
name: MoreSkullsWorldBoss
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using System.Linq.Expressions;
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Quests;
using Skua.Core.Options;

public class MoreSkullsWorldBoss
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv => new();
    private int GetMaxPristineSkull()
    {
        Quest? quest = Bot.Quests.EnsureLoad(10286);
        if (quest == null)
        {
            return 1; // Default max stack if quest is not found
        }
        ItemBase? reward = quest.Rewards.FirstOrDefault(r => r.Name == "Pristine Skull");
        return reward?.MaxStack ?? 1;
    }
    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.Add("Pristine Skull");
        Core.SetOptions();

        Core.OneTimeMessage("WARNING", "During the script, when it Does the zone bit, there will be a momentary Freeze (blame flash), dw about it itll continue", true, true);
        Setup(GetMaxPristineSkull());

        Core.SetOptions(false);
    }
    CancellationTokenSource? moveTokenSource;

    public void Setup(int? quant = null)
    {
        int target = quant ?? GetMaxPristineSkull();
        if (Core.CheckInventory("Pristine Skull", target))
            return;

        moveTokenSource = new CancellationTokenSource(); // Create token
        Bot.Events.ExtensionPacketReceived += Fuckyou;
        Core.AddDrop("Pristine Skull");
        Core.RegisterQuests(10286);

        Bot.Options.AttackWithoutTarget = true;
        Core.FarmingLogger("Pristine Skull", target);
        while (!Bot.ShouldExit && !Core.CheckInventory("Pristine Skull", target))
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive) { }

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

        // Cleanup
        moveTokenSource?.Cancel(); // Cancel any ongoing move task
        moveTokenSource?.Dispose();
        Bot.Events.ExtensionPacketReceived -= Fuckyou;
        Bot.Options.AttackWithoutTarget = false;
    }

    DateTime lastZoneChange = DateTime.MinValue;
    readonly TimeSpan ZoneChangeCooldown = TimeSpan.FromSeconds(2);
    string currentZone = "";
    Task? zoneMovementTask;

    void Fuckyou(dynamic packet)
    {
        if (moveTokenSource?.IsCancellationRequested ?? true)
            return; // Token already cancelled, script likely ended

        string? type = packet["params"]?.type;
        if (type != "json")
            return;

        dynamic? data = packet["params"]?.dataObj;
        string? cmd = data?.cmd?.ToString();
        if (cmd != "event")
            return;

        dynamic? args = data?.args;
        string? zone = args?.zoneSet?.ToString()?.Trim();
        if (string.IsNullOrEmpty(zone) || zone == currentZone)
            return;

        if (DateTime.Now - lastZoneChange < ZoneChangeCooldown)
            return;

        currentZone = zone;
        lastZoneChange = DateTime.Now;

        // Skip if a task is still running
        if (zoneMovementTask is { IsCompleted: false })
            return;

        CancellationToken token = moveTokenSource!.Token;
        zoneMovementTask = Task.Run(async () =>
            {
                // Randomize the delay to avoid being too predictable
                await Task.Delay(Bot.Random.Next(500, 1500), token);

                int x, y;

                // Determine the coordinates based on the zone
                // Zones are defined by their names, e.g., "A", "B", etc. ( gotten from the packet data via Packets > Intercepter)
                switch (zone)
                {
                    case "A":
                        if (Bot.Player.Position.X >= 741 && Bot.Player.Position.X <= 832 &&
                            Bot.Player.Position.Y >= 402 && Bot.Player.Position.Y <= 446)
                            return;

                        x = Bot.Random.Next(741, 833);
                        y = Bot.Random.Next(402, 447);
                        break;

                    case "B":
                        if (Bot.Player.Position.X >= 721 && Bot.Player.Position.X <= 819 &&
                            Bot.Player.Position.Y >= 330 && Bot.Player.Position.Y <= 371)
                            return;

                        x = Bot.Random.Next(721, 820);
                        y = Bot.Random.Next(330, 372);
                        break;

                    default:
                        return; // Do nothing on unknown zone
                }

                if (token.IsCancellationRequested ||
                    (Bot.Player.Position.X == x && Bot.Player.Position.Y == y))
                    return;

                Bot.Player.WalkTo(x, y);
                await Task.Delay(500, token);
            }, token);

    }



    public async Task WaitForTrueAsync(Func<bool> condition, int checkIntervalMs = 100, CancellationToken? token = null)
    {
        while (!condition())
        {
            if (token?.IsCancellationRequested == true)
                return;

            await Task.Delay(checkIntervalMs, token ?? CancellationToken.None);
        }
    }




}
