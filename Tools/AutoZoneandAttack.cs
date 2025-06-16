/*
name: Auto Zone and ttack
description:  This tool will automatically move to the specified zones and attack monsters.
tags:  autozone, nightmare carnax, ultradage, moreskulls
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Skills;
using Skua.Core.Options;

public class AAWithMove
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();

    public string OptionsStorage = "AutoZoneandAttack";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        new Option<PickYourBoss>("PickYourBoss", "Choose Your Boss", "Select the boss you want to farm", PickYourBoss.None),
       new Option<bool>("AttemptSoloNMCarnax", "Attempt Solo Nightmare Carnax", "If you have the Dragon of Time, this will attempt to solo Nightmare Carnax.", false),
        CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions(disableClassSwap: true);

        AutoMove();

        Core.SetOptions(false);
    }


    // Shared fields for movement throttling and async task tracking
    private DateTime lastMove = DateTime.MinValue;
    private readonly TimeSpan moveCooldown = TimeSpan.FromSeconds(2);
    private string currentZone = "";
    private Task? moveTask;

    // Entry point for auto-move depending on current map
    public void AutoMove()
    {
        PickYourBoss boss = Bot.Config!.Get<PickYourBoss>("PickYourBoss");
        bool AttemptSoloNMCarnax = Bot.Config!.Get<bool>("AttemptSoloNMCarnax");
        switch (boss)
        {
            case PickYourBoss.NightmareCarnax:
                FarmDarkCarnax(AttemptSoloNMCarnax ? true : false);
                break;

            case PickYourBoss.UltraDage:
                FarmUltraDage();
                break;

            case PickYourBoss.MoreSkulls:
                SetupMoreSkulls();
                break;

            default:
                break;
        }
    }

    #region DarkCarnax Farming

    private void FarmDarkCarnax(bool attemptSolo)
    {
        Core.AddDrop("Synthetic Viscera");
        Core.Jump("Boss", "Left");
        Bot.Player.SetSpawnPoint();
        Core.RegisterQuests(8872);
        Bot.Options.AttackWithoutTarget = true;

        Bot.Events.RunToArea += MoveNightmareCarnax;
        if (attemptSolo)
        {
            if (Core.CheckInventory("Dragon of Time"))
            {
                Core.Equip("Dragon of Time");
                Bot.Skills.StartAdvanced("3|2|4|2|1|2", 250, SkillUseMode.WaitForCooldown);
            }
            else if (Core.CheckInventory("Healer (Rare)"))
                Bot.Skills.StartAdvanced("Healer (Rare)", true, ClassUseMode.Base);
            else if (Core.CheckInventory("Healer"))
                Bot.Skills.StartAdvanced("Healer", true, ClassUseMode.Base);
            else
                Core.EquipClass(ClassType.Solo);

            Adv.GearStore();
            Adv.EnhanceEquipped(EnhancementType.Healer, wSpecial: WeaponSpecial.Elysium);
        }

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
                Bot.Sleep(1000);

            if (Bot.Map.Name != "DarkCarnax")
                Core.Join("DarkCarnax", "Boss", "Right");
            if (Bot.Player.Cell != "Boss")
                Core.Jump("Boss", "Right");

            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");
            else
            {
                Bot.Wait.ForMonsterDeath();
                Bot.Combat.CancelTarget();
            }

        }
        Core.CancelRegisteredQuests();
        Bot.Options.AttackWithoutTarget = false;
        Adv.GearStore(true);

        Bot.Events.RunToArea -= MoveNightmareCarnax;
    }

    private void MoveNightmareCarnax(string zone)
    {
        string zoneLower = zone.ToLower();

        if (zoneLower == currentZone)
        {
            return;
        }

        if (DateTime.Now - lastMove < moveCooldown)
        {
            return;
        }

        currentZone = zoneLower;
        lastMove = DateTime.Now;

        if (moveTask is { IsCompleted: false })
        {
            return;
        }

        moveTask = Task.Run(async () =>
        {
            await Task.Delay(300);

            int y = Bot.Random.Next(380, 475);
            int x = zoneLower switch
            {
                "a" => Bot.Random.Next(600, 931),
                "b" => Bot.Random.Next(25, 326),
                _ => Bot.Random.Next(325, 601)
            };

            Bot.Player.WalkTo(x, y);

            await Task.Delay(2500);
        });
    }

    #endregion

    #region UltraDage Farming

    private void FarmUltraDage()
    {
        Core.AddDrop("Dage the Evil Insignia");
        Core.Jump("Boss", "Right");
        Bot.Player.SetSpawnPoint();
        Bot.Events.RunToArea += MoveUltraDage;

        Bot.Options.AttackWithoutTarget = true;

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
                Bot.Sleep(1000);

            if (Bot.Map.Name != "UltraDage")
                Core.Join("UltraDage", "Boss", "Right");
            if (Bot.Player.Cell != "Boss")
                Core.Jump("Boss", "Right");
            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");
            else
            {
                Bot.Wait.ForMonsterDeath();
                Bot.Combat.CancelTarget();
            }
        }

        Bot.Events.RunToArea -= MoveUltraDage;
    }

    private void MoveUltraDage(string zone)
    {
        string zoneLower = zone.ToLower();

        if (zoneLower == currentZone)
        {
            return;
        }

        if (DateTime.Now - lastMove < moveCooldown)
        {
            return;
        }

        currentZone = zoneLower;
        lastMove = DateTime.Now;

        if (moveTask is { IsCompleted: false })
        {
            return;
        }

        moveTask = Task.Run(async () =>
        {
            await Task.Delay(300);

            int y = zoneLower switch
            {
                "a" => Bot.Random.Next(400, 410),
                "b" => Bot.Random.Next(410, 415),
                _ => Bot.Random.Next(300, 420)
            };

            int x = zoneLower switch
            {
                "a" => Bot.Random.Next(40, 175),
                "b" => Bot.Random.Next(760, 930),
                _ => Bot.Random.Next(480, 500)
            };

            Bot.Player.WalkTo(x, y);

            await Task.Delay(2500);
        });
    }

    #endregion

    #region MoreSkulls Farming (Setup + Movement)

    public void SetupMoreSkulls()
    {
        Bot.Events.ExtensionPacketReceived += Fuckyou;
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

    private void Fuckyou(dynamic packet)
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
            return;

        string? zone = args.zoneSet?.ToString()?.Trim();
        if (string.IsNullOrEmpty(zone))
            return;

        if (zone == currentZone)
            return;

        if (DateTime.Now - lastMove < moveCooldown)
            return;

        currentZone = zone;
        lastMove = DateTime.Now;

        if (moveTask is { IsCompleted: false })
            return;

        moveTask = Task.Run(async () =>
        {
            await Task.Delay(300);

            int x = 0, y = 0;
            switch (zone.ToUpper())
            {
                case "A":
                    if (Bot.Player.Position.X >= 685 && Bot.Player.Position.X <= 869 &&
                        Bot.Player.Position.Y >= 400 && Bot.Player.Position.Y <= 409)
                        return;

                    x = Bot.Random.Next(685, 870);
                    y = Bot.Random.Next(400, 410);
                    break;

                case "B":
                    if (Bot.Player.Position.X >= 646 && Bot.Player.Position.X <= 861 &&
                        Bot.Player.Position.Y >= 333 && Bot.Player.Position.Y <= 367)
                        return;

                    x = Bot.Random.Next(646, 862);
                    y = Bot.Random.Next(333, 368);
                    break;

                default:
                    return;
            }

            Bot.Player.WalkTo(x, y, speed: 8);
        });
    }

    #endregion


    private enum PickYourBoss
    {
        None,
        NightmareCarnax,
        UltraDage,
        MoreSkulls
    }
}
