/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
using Skua.Core.Interfaces;
using Skua.Core.Models;
using Skua.Core.Models.Factions;
using Skua.Core.Models.Items;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Quests;
using Skua.Core.Models.Shops;

public class CoreFarms
{
    // [Can Change] Can you solo the boss without killing the ads
    public bool canSoloInPvP { get; set; } = true;

    // [Can Change] Use boosts on Gold farming
    public bool doGoldBoost { get; set; } = false;
    // [Can Change] Use boosts on Class farming
    public bool doClassBoost { get; set; } = false;
    // [Can Change] Use boosts on Reputation farming
    public bool doRepBoost { get; set; } = false;
    // [Can Change] Use boosts on Experience farming
    public bool doExpBoost { get; set; } = false;

    // Thousand-level Constants
    const int OneK = 1000;        // 1k
    const int TenK = 10000;       // 10k
    const int OneHundredK = 100000; // 100k
    const int FiveHundredK = 500000; // 500k

    // Million-level Constants
    const int OneMillion = 1000000;   // 1m
    const int FiveMillion = 5000000;  // 5m
    const int TenMillion = 10000000;  // 10m
    const int FiftyMillion = 50000000; // 50m
    const int OneHundredMillion = 100000000; // 100m

    //Max integer
    const int maxint = Int32.MaxValue;

    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.RunCore();
    }

    public void ToggleBoost(BoostType type, bool enabled = true)
    {
        if (enabled)
        {
            if (Core.CBOBool("doGoldBoost", out bool _doGoldBoost))
                doGoldBoost = _doGoldBoost;
            if (Core.CBOBool("doClassBoost", out bool _doClassBoost))
                doClassBoost = _doClassBoost;
            if (Core.CBOBool("doRepBoost", out bool _doRepBoost))
                doRepBoost = _doRepBoost;
            if (Core.CBOBool("doExpBoost", out bool _doExpBoost))
                doExpBoost = _doExpBoost;

            switch (type)
            {
                case BoostType.Gold:
                    if (!doGoldBoost || Bot.Boosts.UseGoldBoost || Bot.Player.Gold >= 100000000)
                        return;
                    Bot.Boosts.SetGoldBoostID();
                    Bot.Boosts.UseGoldBoost = true;
                    break;

                case BoostType.Class:
                    if (!doClassBoost || Bot.Boosts.UseClassBoost)
                        return;
                    Bot.Boosts.SetClassBoostID();
                    Bot.Boosts.UseClassBoost = true;
                    break;

                case BoostType.Reputation:
                    if (!doRepBoost || Bot.Boosts.UseReputationBoost)
                        return;
                    Bot.Boosts.SetReputationBoostID();
                    Bot.Boosts.UseReputationBoost = true;
                    break;

                case BoostType.Experience:
                    if (!doExpBoost || Bot.Boosts.UseExperienceBoost || Bot.Player.Level == 100)
                        return;
                    Bot.Boosts.SetExperienceBoostID();
                    Bot.Boosts.UseExperienceBoost = true;
                    break;
            }
            Bot.Boosts.Start();
        }
        else
        {
            switch (type)
            {
                case BoostType.Gold:
                    if (!Bot.Boosts.UseGoldBoost)
                        return;
                    Bot.Boosts.UseGoldBoost = false;
                    break;

                case BoostType.Class:
                    if (!Bot.Boosts.UseClassBoost)
                        return;
                    Bot.Boosts.UseClassBoost = false;
                    break;

                case BoostType.Reputation:
                    if (!Bot.Boosts.UseReputationBoost)
                        return;
                    Bot.Boosts.UseReputationBoost = false;
                    break;

                case BoostType.Experience:
                    if (!Bot.Boosts.UseExperienceBoost)
                        return;
                    Bot.Boosts.UseExperienceBoost = false;
                    break;
            }
            if (new[] { Bot.Boosts.UseGoldBoost, Bot.Boosts.UseClassBoost, Bot.Boosts.UseReputationBoost, Bot.Boosts.UseExperienceBoost }.All(on => !on))
                Bot.Boosts.Stop();
        }
    }

    #region Gold
    public void Gold(int quant = 100000000)
    {
        // quant -= Bot.Player.Gold;
        if (Bot.Player.Gold >= quant)
            return;

        ToggleBoost(BoostType.Gold);

        HonorHall(quant);
        BattleGroundE(quant);
        BerserkerBunny(quant);

        ToggleBoost(BoostType.Gold, false);
    }

    /// <summary>
    /// Farms Gold in HonorHall (members) with quests HonorHall Mobs and 61-75
    /// </summary>
    /// <param name="goldQuant">How much gold to farm</param>
    public void HonorHall(int goldQuant = 100000000)
    {
        if (!Core.IsMember || Bot.Player.Level < 61 || Bot.Player.Gold >= goldQuant)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        Core.Logger($"Farming {goldQuant:N0} gold using HonorHall Method");


        Core.RegisterQuests(3992, 3993);
        while (!Bot.ShouldExit && Bot.Player.Gold < goldQuant)
        {
            Core.KillMonster("honorhall", "r1", "Center", "Ice Demon");
        }
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
    }

    public void LovePotion(int goldQuant = 100000000)
    {
        if (Bot.Player.Gold >= goldQuant)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        Core.Logger($"Farming {goldQuant:N0} gold using \"A Lovely An-Sewer [Love Potion]\" method");

        #region  Side Quests that require stories and may not be unlocked:
        List<int> QuestIDs = new() { 9643 };
        foreach (int q in new[] { 4319, 4328 })
        {
            if (!Core.isCompletedBefore(q))
                continue;

            QuestIDs.Add(q);
        }
        #endregion
        Core.RegisterQuests(QuestIDs.ToArray());
        while (!Bot.ShouldExit && Bot.Player.Gold < goldQuant)
        {
            Core.KillMonster("sewerpink", "Sewer2", "Left", "Pink Rat", log: false);
        }
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
    }

    /// <summary>
    /// Farms Gold in Battle Ground E with quests Level 46-60 and 61-75
    /// </summary>
    /// <param name="goldQuant">How much gold to farm</param>
    public void BattleGroundE(int goldQuant = 100000000)
    {
        if (Bot.Player.Level < 61 || Bot.Player.Gold >= goldQuant)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        Core.Logger($"Farming {goldQuant:N0} gold using BattleGroundE Method");

        Core.RegisterQuests(3991, 3992);
        while (!Bot.ShouldExit && Bot.Player.Gold < goldQuant)
        {
            // Core.KillMonster("battlegrounde", "r2", "Left", "*", "Battleground E Opponent Defeated", 10, log: false);
            // Core.KillMonster("battlegrounde", "r2", "Left", "*", "Battleground D Opponent Defeated", 10, log: false);
            Core.KillMonster("battlegrounde", "r2", "Left", "*", log: false);
        }
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
    }

    /// <summary>
    /// Farms Gold by selling Berserker Bunny
    /// </summary>
    /// <param name="goldQuant">How much gold to farm</param>
    /// <param name="sell"></param>
    public void BerserkerBunny(int goldQuant = 100000000, bool sell = true)
    {
        if (Bot.Player.Gold >= goldQuant)
            return;

        Core.AddDrop("Berserker Bunny");
        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        Core.Logger($"Farming {goldQuant:N0}  using BerserkerBunny Method");

        Core.RegisterQuests(236);
        while (!Bot.ShouldExit && Bot.Player.Gold < goldQuant)
        {
            Core.KillMonster("greenguardwest", "West12", "Up", "*");

            if (Bot.Inventory.Contains("Berserker Bunny"))
                SellItem("Berserker Bunny");
        }
        Core.CancelRegisteredQuests();
        Core.SavedState(false);

        // Helper method *specificly* for berserker bunny
        void SellItem(string itemName)
        {
            if (!sell || !Bot.Inventory.Contains(itemName))
                return;

            // Jump to exit (potential) combat
            Bot.Map.Jump(Bot.Player.Cell, Bot.Player.Pad, autoCorrect: false);
            // Sleep to ensure we've loaded into cell
            Bot.Sleep(1000);

            // Keep trying to sell it till we sell it ( with a delay to not spam)
            while (!Bot.ShouldExit && Bot.Inventory.Contains(itemName))
            {
                Bot.Wait.ForActionCooldown(GameActions.SellItem);
                Bot.Send.Packet($"%xt%zm%sellItem%{Bot.Map.RoomID}%34417%1%{1049211823}%");
                Bot.Wait.ForItemSell();
                Core.Sleep();
                if (!Bot.Inventory.Contains(itemName))
                    break;
            }
        }
    }

    // <summary>
    // Farms Gold by Kill mobs in "darkwarlegion" for Badges and turning the quest in. (ignore the missign turning reqs.. its to quick)
    // </summary>
    // <param name="goldQuant">How much gold to farm</param>
    public void DarkWarLegion(int goldQuant = 100000000) //Slower then BattleGroundE
    {
        if (Bot.Player.Gold >= goldQuant)
            return;

        Core.EquipClass(ClassType.Farm);
        ToggleBoost(BoostType.Gold);
        Core.SavedState();
        Core.Logger($"Farming {goldQuant:N0}  using DarkWarLegion Method");

        Core.RegisterQuests(8584, 8585);
        while (!Bot.ShouldExit && Bot.Player.Gold < goldQuant)
            Core.KillMonster("darkwarlegion", "r2", "Left", "*", "Nation Badge", 5, log: false);
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
        ToggleBoost(BoostType.Gold, false);
    }
    #endregion

    #region Experience
    public void Experience(int level = 100, bool rankUpClass = false)
    {
        if (Bot.Player.Level >= level && !rankUpClass)
            return;

        if (!rankUpClass)
            Core.EquipClass(ClassType.Farm);
        if (rankUpClass)
            ToggleBoost(BoostType.Class);

        ToggleBoost(BoostType.Experience);
        if (rankUpClass)
            IcestormArena(level, rankUpClass);
        else
        {
            if (Bot.Player.Level < 10)
            {
                Core.Logger("Doing Oaklore \"Bone Berserker\" Quest till level 10");
                Core.RegisterQuests(4007, 6257);
                while (!Bot.ShouldExit && Bot.Player.Level < 10)
                    Core.KillMonster("oaklore", "r3", "Left", "Bone Berserker", log: false);
                Core.CancelRegisteredQuests();
            }

            if (Bot.Player.Level < 20)
            {
                UndeadGiantUnlock();
                Core.Logger("Doing swordhavenundead \"Undead Giant\" Quest till level 20");
                Core.RegisterQuests(178);
                while (!Bot.ShouldExit && Bot.Player.Level < 20)
                    Core.KillMonster("swordhavenundead", "Gates", "Left", "Undead Giant", log: false);
                Core.CancelRegisteredQuests();
            }
        }

        IcestormArena(level, rankUpClass);

        if (rankUpClass)
            ToggleBoost(BoostType.Class, false);
        ToggleBoost(BoostType.Experience, false);

    }


    // /// <summary>
    // /// Farms level in Ice Storm Arena
    // /// </summary>
    // /// <param name="level">Desired level</param>
    // /// <param name="rankUpClass"></param>
    // public void IcestormArena(int level = 100, bool rankUpClass = false)
    // {
    //     if (Bot.Player.Level >= level && !rankUpClass)
    //         return;

    //     if (!rankUpClass)
    //         Core.EquipClass(ClassType.Farm);
    //     if (rankUpClass)
    //         ToggleBoost(BoostType.Class);
    //     Core.ToggleAggro(true);
    //     Core.SavedState();
    //     if (NotYetLevel(level) && Bot.Player.Level < 100)
    //         ToggleBoost(BoostType.Experience, true);
    //     //Between level 1 and 5
    //     while (!Bot.ShouldExit && NotYetLevel(5))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r4", "Bottom", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 5 and 10
    //     while (!Bot.ShouldExit && NotYetLevel(10))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r5", "Left", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 10 and 20
    //     while (!Bot.ShouldExit && NotYetLevel(20))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r6", "Left", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 20 and 25
    //     if (NotYetLevel(25))
    //     {
    //         Core.RegisterQuests(6628);
    //         while (!Bot.ShouldExit && NotYetLevel(25))
    //         {
    //             Core.ByPassCheck();
    //             Core.KillMonster("icestormarena", "r7", "Left", "*", log: false, publicRoom: true);
    //         }
    //         Core.CancelRegisteredQuests();
    //     }

    //     //Between level 25 and 30
    //     while (!Bot.ShouldExit && NotYetLevel(30))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r10", "Left", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 30 and 35
    //     if (NotYetLevel(35))
    //     {
    //         if (!rankUpClass)
    //             Core.EquipClass(ClassType.Solo);

    //         Core.RegisterQuests(6629);
    //         while (!Bot.ShouldExit && NotYetLevel(35))
    //         {
    //             Core.ByPassCheck();
    //             Core.KillMonster("icestormarena", "r11", "Left", "*", log: false, publicRoom: true);
    //         }
    //         Core.CancelRegisteredQuests();
    //     }

    //     if (!rankUpClass)
    //         Core.EquipClass(ClassType.Farm);

    //     //Between level 35 and 50
    //     while (!Bot.ShouldExit && NotYetLevel(50))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r14", "Left", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 50 and 61(for BGE)
    //     while (!Bot.ShouldExit && NotYetLevel(61))
    //     {
    //         Core.ByPassCheck();
    //         Core.KillMonster("icestormarena", "r16", "Left", "*", log: false, publicRoom: true);
    //     }

    //     //Between level 61 and 75
    //     if (NotYetLevel(75))
    //     {
    //         if (rankUpClass)
    //         {
    //             while (!Bot.ShouldExit && NotYetLevel(75))
    //             {
    //                 Core.ByPassCheck();
    //                 Core.KillMonster("icestormarena", NotYetLevel(65) ? "r17" : NotYetLevel(70) ? "r18" : "r20", "Left", "*", log: false, publicRoom: true);
    //             }
    //         }
    //         else
    //         {
    //             ToggleBoost(BoostType.Gold);
    //             Core.RegisterQuests(3991, 3992);
    //             while (!Bot.ShouldExit && NotYetLevel(75))
    //                 Core.KillMonster("battlegrounde", "r2", "Center", "*", log: false, publicRoom: true);
    //             Core.CancelRegisteredQuests();
    //             ToggleBoost(BoostType.Gold, false);
    //         }
    //     }

    //     //Between level 75 and 100
    //     while (!Bot.ShouldExit && NotYetLevel(level))
    //     {
    //         if (!Bot.Player.IsMember)
    //             Core.ByPassCheck();

    //         Core.KillMonster(
    //             Core.IsMember
    //             ? "nightmare"
    //             : "icestormunder",

    //             Core.IsMember
    //             ? "r13"
    //             : "r2",

    //             Core.IsMember
    //             ? "Left"
    //             : "Top",

    //             Core.IsMember
    //             ? "*"
    //             : "*",

    //             log: false);
    //     }
    //     Core.ToggleAggro(false);
    //     Core.JumpWait();
    //     Core.Rest();

    //     if (rankUpClass)
    //         ToggleBoost(BoostType.Class, false);
    //     ToggleBoost(BoostType.Experience, false);

    //     bool NotYetLevel(int _level)
    //     {
    //         // Check for an equipped class item in the inventory.
    //         InventoryItem? item = Bot.Inventory.Items
    //             .FirstOrDefault(x => x != null && x.Equipped && x.Category == ItemCategory.Class);

    //         // If no class item is found, log and return level comparison.
    //         if (item == null)
    //         {
    //             Core.Logger("Class not found.");
    //             return !rankUpClass
    //                 ? Bot.Player.Level < _level && Bot.Player.Level < level
    //                 : Bot.Player.Level <= _level;
    //         }

    //         // Return level comparison based on class item conditions.
    //         return !rankUpClass
    //             ? Bot.Player.Level < _level && Bot.Player.Level < level
    //             : Bot.Player.Level <= _level && Bot.Player.Level <= level && item.Quantity < 302500;
    //     }

    // }




    /// <summary>
    /// Farms level in Ice Storm Arena
    /// </summary>
    /// <param name="level">Desired level</param>
    /// <param name="rankUpClass">Whether to rank up the class (true or false)</param>
    public void IcestormArena(int level = 100, bool rankUpClass = false)
    {
        // Exit if the player's level has already reached the desired level and we are not ranking up the class
        if (Bot.Player.Level >= level && !rankUpClass)
            return;

        #region level checks
        // Equip the class for farming or rank up boost as needed
        if (!rankUpClass)
            Core.EquipClass(ClassType.Farm);
        if (rankUpClass)
            ToggleBoost(BoostType.Class);

        // Enable aggro for the farm
        Core.ToggleAggro(true);
        Core.SavedState();

        // Toggle experience boost if we are farming for experience
        if (Bot.Player.Level < 100)
            ToggleBoost(BoostType.Experience);

        Core.ByPassCheck();
        // Farming between levels 1-5
        while (!Bot.ShouldExit && Bot.Player.Level < 5)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r4", "Bottom");
                    Bot.Wait.ForCellChange("r4");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r4")
            {
                Core.Jump("r4", "Bottom");
                Bot.Wait.ForCellChange("r4");
            }

            Core.CanWeAggro();
            Bot.Combat.Attack("*");
            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;
        }

        Core.ByPassCheck();
        // Farming between levels 5-10
        while (!Bot.ShouldExit && Bot.Player.Level >= 5 && Bot.Player.Level < 10)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r5", "Left");
                    Bot.Wait.ForCellChange("r5");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r5")
            {
                Core.Jump("r5", "Left");
                Bot.Wait.ForCellChange("r5");
            }

            Core.CanWeAggro();
            Core.Sleep();
            Bot.Combat.Attack("*");
            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;
        }

        Core.ByPassCheck();
        // Farming between levels 10-20
        while (!Bot.ShouldExit && Bot.Player.Level >= 10 && Bot.Player.Level < 20)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r6", "Left");
                    Bot.Wait.ForCellChange("r6");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r6")
            {
                Core.Jump("r6", "Left");
                Bot.Wait.ForCellChange("r6");
            }

            Core.CanWeAggro();
            Bot.Combat.Attack("*");
            Core.Sleep();
            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;
        }

        Core.ByPassCheck();
        // Farming between levels 20-25
        if (Bot.Player.Level < 25)
        {
            Core.RegisterQuests(6628);
            while (!Bot.ShouldExit && Bot.Player.Level >= 20 && Bot.Player.Level < 25)
            {
                while (!Bot.ShouldExit && !Bot.Player.Alive)
                {
                    if (Bot.Player.Alive)
                    {
                        Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                        Bot.Sleep(1000);
                        Core.Jump("r7", "Left");
                        Bot.Wait.ForCellChange("r7");
                        break;
                    }
                    else
                        Bot.Sleep(1000);
                }

                if (Bot.Map.Name != "icestormarena")
                {
                    Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                    Bot.Wait.ForMapLoad("icestormarena");
                }
                if (Bot.Player.Cell != "r7")
                {
                    Core.Jump("r7", "Left");
                    Bot.Wait.ForCellChange("r7");
                }
                Core.CanWeAggro();

                Bot.Combat.Attack("*");
                Core.Sleep();
                if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                    break;
            }
            Core.AbandonQuest(6628);
        }

        Core.ByPassCheck();
        // Farming between levels 25-30
        while (!Bot.ShouldExit && Bot.Player.Level >= 25 && Bot.Player.Level < 30)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r10", "Left");
                    Bot.Wait.ForCellChange("r10");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r10")
            {
                Core.Jump("r10", "Left");
                Bot.Wait.ForCellChange("r10");
            }

            Core.CanWeAggro();
            Bot.Combat.Attack("*");
            Core.Sleep();
            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;
        }

        Core.ByPassCheck();
        // Farming between levels 30-35 (and switching to solo class if needed)
        if (Bot.Player.Level >= 30 && Bot.Player.Level < 35)
        {
            if (!rankUpClass)
                Core.EquipClass(ClassType.Solo);
            Core.RegisterQuests(6629);
            while (!Bot.ShouldExit && Bot.Player.Level >= 30 && Bot.Player.Level < 35)
            {
                while (!Bot.ShouldExit && !Bot.Player.Alive)
                {
                    if (Bot.Player.Alive)
                    {
                        Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                        Bot.Sleep(1000);
                        Core.Jump("r11", "Left");
                        Bot.Wait.ForCellChange("r11");
                        break;
                    }
                    else
                        Bot.Sleep(1000);
                }

                if (Bot.Map.Name != "icestormarena")
                {
                    Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                    Bot.Wait.ForMapLoad("icestormarena");
                }
                if (Bot.Player.Cell != "r11")
                {
                    Core.Jump("r11", "Left");
                    Bot.Wait.ForCellChange("r11");
                }
                Core.CanWeAggro();

                Bot.Combat.Attack("*");
                Core.Sleep();
                if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                    break;
            }
            Core.AbandonQuest(6629);
        }

        if (!rankUpClass)
            Core.EquipClass(ClassType.Farm);

        Core.ByPassCheck();
        // Farming between levels 35-50
        while (!Bot.ShouldExit && Bot.Player.Level >= 35 && Bot.Player.Level < 50)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r14", "Left");
                    Bot.Wait.ForCellChange("r14");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r14")
            {
                Core.Jump("r14", "Left");
                Bot.Wait.ForCellChange("r14");
            }

            Core.CanWeAggro();
            Bot.Combat.Attack("*");
            Core.Sleep();
        }

        Core.ByPassCheck();
        // Farming between levels 50-61
        while (!Bot.ShouldExit && Bot.Player.Level >= 50 && Bot.Player.Level < 61)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    Core.Jump("r16", "Left");
                    Bot.Wait.ForCellChange("r16");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            Core.CanWeAggro();
            if (Bot.Map.Name != "icestormarena")
            {
                Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                Bot.Wait.ForMapLoad("icestormarena");
            }
            if (Bot.Player.Cell != "r16")
            {
                Core.Jump("r16", "Left");
                Bot.Wait.ForCellChange("r16");
            }

            Bot.Combat.Attack("*");
            Core.Sleep();
            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;
        }

        Core.ByPassCheck();
        // Farming between levels 61-75 with BattleGroundE for non-rank-up class
        if (Bot.Player.Level >= 61 && Bot.Player.Level < 75)
        {
            if (rankUpClass)
            {
                while (!Bot.ShouldExit && Bot.Player.Level >= 61 && Bot.Player.Level < 75)
                {
                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                    {
                        if (Bot.Player.Alive)
                        {
                            Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                            Bot.Sleep(1000);
                            if (Bot.Player.Cell != "r17")
                                Core.Jump("r17", "Left");
                            break;
                        }
                        else
                            Bot.Sleep(1000);
                    }

                    if (Bot.Map.Name != "icestormarena")
                        Core.Join("icestormarena", publicRoom: Core.PrivateRooms);
                    if (Bot.Player.Cell != "r17")
                        Core.Jump("r17", "Left");

                    Core.CanWeAggro();
                    Bot.Combat.Attack("*");
                    Core.Sleep();
                    if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                        break;
                }
            }
            else
            {
                if (Bot.Player.Gold < OneHundredMillion)
                    ToggleBoost(BoostType.Gold);

                Core.RegisterQuests(3991, 3992);
                while (!Bot.ShouldExit && Bot.Player.Level >= 61 && Bot.Player.Level < 75)
                {
                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                    {
                        if (Bot.Player.Alive)
                        {
                            Bot.Sleep(1000);
                            if (Bot.Player.Cell != "r2")
                                Core.Jump("r2", "center");
                            break;
                        }
                        else
                            Bot.Sleep(1000);
                    }

                    if (Bot.Map.Name != "battlegrounde")
                        Core.Join("battlegrounde", publicRoom: Core.PrivateRooms);
                    if (Bot.Player.Cell != "r2")
                        Core.Jump("r2", "center");

                    Core.CanWeAggro();
                    Bot.Combat.Attack("*");
                    Core.Sleep();
                }
                Core.AbandonQuest(3991, 3992);
                ToggleBoost(BoostType.Gold, false);
            }
        }

        Core.ByPassCheck();
        // Farming between levels 75-100
        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                if (Bot.Player.Alive)
                {
                    Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json");
                    Bot.Sleep(1000);
                    if (Bot.Player.Cell != "r2")
                        if (Bot.Player.Cell != (Core.IsMember
                ? "r13"
                : "r2"))
                            Core.Jump(Core.IsMember
                            ? "r13"
                            : "r2", "Left");
                    break;
                }
                else
                    Bot.Sleep(1000);
            }

            if (!rankUpClass && Bot.Player.Level >= level)
                break;

            if (Bot.Player.Alive && rankUpClass && Bot.Player.CurrentClass != null && Bot.Player.CurrentClassRank >= 10)
                break;

            if (!Bot.Player.IsMember)
                Core.ByPassCheck();

            if (Bot.Map.Name != (Core.IsMember
                ? "nightmare"
                : "icestormunder"))
                Core.Join(Core.IsMember
                ? "nightmare"
                : "icestormunder", publicRoom: Core.PrivateRooms);

            if (Bot.Player.Cell != (Core.IsMember
                ? "r13"
                : "r2"))
                Core.Jump(Core.IsMember
                ? "r13"
                : "r2", "Left");
            Core.CanWeAggro();

            Bot.Combat.Attack("*");
            Core.Sleep();
        }
        #endregion level checks


        Bot.Options.AttackWithoutTarget = false;
        Core.ToggleAggro(false);
        Core.Jump();
        Bot.Options.AggroMonsters = false;
        Core.JumpWait();
        Core.Rest();

        // Disable any active boosts
        if (rankUpClass)
            ToggleBoost(BoostType.Class, false);
        ToggleBoost(BoostType.Experience, false);
    }




    /// <summary>
    /// Farms in Seven Circles War for level and items
    /// </summary>
    /// <param name="level">Desired level</param>
    /// <param name="gold"></param>
    public void SevenCirclesWar(int level = 100, int gold = 100000000)
    {
        if (Bot.Player.Level >= level && Bot.Player.Gold >= gold)
            return;

        if (!Core.isCompletedBefore(7979))
        {
            Core.Logger("Please use Scripts/Story/Legion/SevenCircles(War).cs to use the SevenCircles method");
            return;
        }

        if (Bot.Player.Level < level)
            ToggleBoost(BoostType.Experience);
        if (Bot.Player.Gold < gold)
            ToggleBoost(BoostType.Gold);

        Core.AddDrop("Essence of Wrath", "Souls of Heresy");
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        Core.Logger($"Farming {gold} gold using SCW Method");

        Core.RegisterQuests(7979, 7980, 7981);

        while (!Bot.ShouldExit && (level == 101 ? Bot.Player.Gold < gold : (Bot.Player.Level < level && Bot.Player.Gold < gold)))
            Core.KillMonster("sevencircleswar", "Enter", "Right", "*", log: false);

        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Experience, false);
        ToggleBoost(BoostType.Gold, false);
        Core.SavedState(false);
    }


    /// <summary>
    /// Farms level in FireWar Turnins
    /// </summary>
    /// <param name="level">Desired level</param>
    public void FireWarxp(int level)
    {
        if (Bot.Player.Level >= 60)
            return;

        Core.EquipClass(ClassType.Farm);
        if (Bot.Player.Level < level)
            ToggleBoost(BoostType.Experience);
        Core.SavedState();

        Core.RegisterQuests(6294, 6295);
        while (!Bot.ShouldExit && Bot.Player.Level < level)
            Core.KillMonster("Firewar", "r2", "Right", "*", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Experience, false);
        Core.SavedState(false);
    }
    #endregion

    #region Misc
    /// <summary>
    /// Farms the Black Knight Orb
    /// </summary>
    public void BlackKnightOrb()
    {
        if (Core.CheckInventory("Black Knight Orb"))
            return;

        Core.AddDrop("Black Knight Orb");
        Core.EnsureAccept(318);

        Core.HuntMonster("well", "Gell Oh No", "Black Knight Leg Piece");
        Core.HuntMonster("greendragon", "Greenguard Dragon", "Black Knight Chest Piece");
        Core.HuntMonster("deathgazer", "Deathgazer", "Black Knight Shoulder Piece");
        Core.HuntMonster("trunk", "GreenGuard Basilisk", "Black Knight Arm Piece");

        Core.EnsureComplete(318);
        Bot.Wait.ForPickup("Black Knight Orb");
    }

    /// <summary>
    /// Kills the Restorers from /BludrutBrawl for "The Secret 4" item
    /// </summary>
    public void TheSecret4()
    {
        if (Core.CheckInventory("The Secret 4"))
            return;
        Core.EquipClass(ClassType.Solo);
        Core.JumpWait();
        while (!Bot.ShouldExit && !Core.CheckInventory("The Secret 4"))
        {
            while (!Bot.ShouldExit && Bot.Map.Name != "bludrutbrawl")
            {
                Core.Sleep(5000);
                Core.JumpWait();
                Core.Join("bludrutbrawl", "Enter0", "Spawn");
            }

            Core.PvPMove(5, "Morale0C");
            Core.PvPMove(4, "Morale0B");
            Core.PvPMove(7, "Morale0A");
            Core.PvPMove(9, "Crosslower");
            Core.PvPMove(14, "Crossupper", 528, 255);

            Core.PvPMove(18, "Resource1A");
            Bot.Kill.Monster("(B) Defensive Restorer");
            if (Bot.Drops.Exists("The Secret 4"))
            {
                Bot.Drops.Pickup("The Secret 4");
                Bot.Wait.ForPickup("The Secret 4");
            }

            Core.PvPMove(20, "Resource1B");
            Bot.Kill.Monster("(B) Defensive Restorer");
            if (Bot.Drops.Exists("The Secret 4"))
            {
                Bot.Drops.Pickup("The Secret 4");
                Bot.Wait.ForPickup("The Secret 4");
            }

            while (!Bot.ShouldExit && Bot.Map.Name != "battleon")
            {
                Core.Sleep(5000);
                Core.JumpWait();
                Core.Join("battleon");
            }
        }
    }

    /// <summary>
    /// Defeats the Team B Captain in /BludrutBrawl to farm the specified item.
    /// </summary>
    /// <param name="item">The name of the item to be obtained (e.g., "Combat Trophy" or "Yoshino's Citrine").</param>
    /// <param name="quant">The target quantity of the item.</param>
    /// <param name="canSoloBoss">Indicates if the boss can be soloed; true by default.</param>
    public void BludrutBrawlBoss(string item = "Combat Trophy", int quant = 5000, bool canSoloBoss = true)
    {
        if (Core.CheckInventory(item, quant))
            return;

        if (Bot.Map.Name == "bludrutbrawl")
        {
            Core.Logger("Started in PvP map, which doesnt allow us to equip things if needed and can cause issues. Joining whitemap first.");
            Core.Join("whitemap");
        }

        canSoloBoss = Core.CBOBool("PvP_SoloPvPBoss", out bool KillAds);
        Core.Logger($"`Kill Ads` Enabled? {KillAds}");
        Core.AddDrop(new[] { item } ?? new[] { "The Secret 4", "Yoshino's Citrine" });

        Core.EquipClass(ClassType.Solo);
        Core.FarmingLogger(item, quant);
        Bot.Options.AggroAllMonsters = false;
        Bot.Options.AggroMonsters = false;

        // Find the first matching amulet in inventory or bank
        string? amulet = AcceptablePvPAmulets
            .FirstOrDefault(name => Bot.Inventory.Items.Concat(Bot.Bank.Items).Any(i => i?.Name == name));

        // Equip the amulet if found in inventory or bank
        if (amulet != null)
        {
            Core.Unbank(amulet);
            Core.Equip(amulet);
        }

    Start:
        int ExitAttempt = 0;
        int Death = 0;
        Random random = new();
        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.Join("bludrutbrawl-999999", "Enter0", "Spawn");
            Bot.Wait.ForMapLoad("bludrutbrawl");

            Core.PvPMove(5, "Morale0C", random.Next(784, 862), random.Next(254, 274));
            Core.PvPMove(4, "Morale0B", random.Next(786, 850), random.Next(262, 287));
            Core.PvPMove(7, "Morale0A", random.Next(783, 857), random.Next(263, 293));
            Core.PvPMove(9, "Crosslower", random.Next(777, 857), random.Next(254, 290));

            // If CBO setting for `Kill ads before boss` is enabled do:
            if (KillAds)
            {
                if (!Bot.Inventory.Items.Any(x => x != null && Core.CheckInventory(AcceptablePvPAmulets, any: true) && x.Equipped))
                    Core.OneTimeMessage("Wheres your amulet retard?", "Hey ChuckleFuck, you forgot your amulet! So now you get to kill the minions.");

                Core.PvPMove(14, "Crossupper", random.Next(399, 545), random.Next(255, 256));
                Core.PvPMove(18, "Resource1A", random.Next(786, 860), random.Next(255, 274));

                Core.PVPKilling();
                if (!Bot.Player.Alive)
                    goto RestartOnDeath;

                Core.PvPMove(20, "Resource1B", random.Next(784, 852), random.Next(254, 293));

                Core.PVPKilling();
                if (!Bot.Player.Alive)
                    goto RestartOnDeath;

                Core.PvPMove(21, "Resource1A", random.Next(123, 189), random.Next(262, 297));
                Core.PvPMove(19, "Crossupper", random.Next(122, 189), random.Next(258, 282));
                Core.PvPMove(17, "Crosslower", random.Next(439, 536), random.Next(467, 470));
            }

            Core.PvPMove(15, "Morale1A", random.Next(781, 858), random.Next(258, 290));

            Bot.Kill.Monster(13);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(23, "Morale1B", random.Next(782, 850), random.Next(259, 276));

            Bot.Kill.Monster(14);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(25, "Morale1C", random.Next(802, 865), random.Next(264, 286));

            Bot.Kill.Monster(15);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(28, "Captain1", random.Next(430, 537), random.Next(254, 255));
            Bot.Kill.Monster(16);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Bot.Wait.ForDrop(item, 40);
            Core.Sleep(1500);
            Bot.Wait.ForPickup(item, 40);
            if (!string.IsNullOrEmpty(item))
                Core.FarmingLogger(item, quant);
            Core.Sleep(1500);
            goto Exit;

        Exit:
            while (!Bot.ShouldExit && Bot.Map.Name != "battleon")
            {
                Core.Logger($"Attempting Exit {ExitAttempt++}.");
                Bot.Combat.CancelTarget();
                Bot.Wait.ForCombatExit();
                Bot.Map.Join("battleon-999999");
                Core.Sleep(1500);
                if (Bot.Map.Name != "battleon")
                    Core.Logger("Failed!? HOW.. try agian");
                else
                {
                    Core.Logger("Successful!");
                    goto Start;
                }
            }

        RestartOnDeath:
            Core.Logger($"Death: {Death++}, resetting");
            while (!Bot.ShouldExit)
            {
                Bot.Wait.ForTrue(() => Bot.Player.Alive, 100);
                Core.Logger($"Attempting Death Exit {ExitAttempt++}.");
                Bot.Map.Join("battleon-999999");
                Bot.Wait.ForMapLoad("battleon");
                Core.Sleep(1500);
                if (Bot.Map.Name != "battleon")
                    Core.Logger("Failed!? HOW.. try agian");
                else
                {
                    Core.Logger("Successful!");
                    goto Start;
                }
            }
        }

        foreach (string reward in new[] { "Yoshino's Citrine", "The Secret 4" })
        {
            if (item != reward && Bot.Inventory.Contains(reward))
                Core.ToBank(reward);
        }
    }

    public void BattleUnderB(string item = "Bone Dust", int quant = 10000, bool isTemp = false)
    {
        if (isTemp ? Bot.TempInv.Contains(item, quant) : Core.CheckInventory(item, quant))
        {
            Core.FarmingLogger(item, quant);
            return;
        }

        if (item == "Undead Energy" && !Core.isCompletedBefore(2084))
        {
            Core.Logger("Making it so undead energy can drop..");

            // 2066 - Reforging the Blinding Light
            if (!Core.isCompletedBefore(2066))
            {
                Core.EnsureAccept(2066);
                Core.BuyItem("doomwood", 276, "Blinding Light of Destiny Handle");
                Core.EnsureComplete(2066);
            }

            Core.EquipClass(ClassType.Farm);
            // 2067 - Secret Order of Undead Slayers
            if (!Core.isCompletedBefore(2067))
            {
                Core.EnsureAccept(2067);
                Core.BuyItem("doomwood", 276, "Bonegrinder Medal");
                Core.EnsureComplete(2067);
            }

            // 2082 - Essential Essences
            if (!Core.isCompletedBefore(2082))
            {
                Core.EnsureAccept(2082);
                Core.HuntMonster("battleunderb", "Skeleton Warrior", "Undead Essence", 25, isTemp: false);
                Core.EnsureComplete(2082);
            }

            // 2083 - Bust some Dust
            if (!Core.isCompletedBefore(2083))
            {
                Core.EnsureAccept(2083);
                Core.HuntMonster("battleunderb", "Skeleton Warrior", "Bone Dust", 40, isTemp: false);
                Core.EnsureComplete(2083);
            }

            // 2084 - A Loyal Follower
            if (!Core.isCompletedBefore(2084))
            {
                Core.EnsureAccept(2084);
                BoneSomeDust(100);
                Core.HuntMonster("timevoid", "Ephemerite", "Celestial Compass");
                Core.EnsureComplete(2084);
            }
        }

        Core.AddDrop(item);
        Core.FarmingLogger(item, quant);
        Core.EquipClass(ClassType.Farm);
        Core.KillMonster("battleunderb", "Enter", "Spawn", "*", item, quant, isTemp, log: false);
    }

    public void BoneSomeDust(int quant = 65000)
    {
        if (Core.CheckInventory("Spirit Orb", quant))
            return;

        Core.AddDrop("Bone Dust", "Undead Essence", "Undead Energy", "Spirit Orb");
        Core.EquipClass(ClassType.Farm);
        Core.FarmingLogger("Spirit Orb", quant);

        Core.RegisterQuests(2082, 2083);
        while (!Bot.ShouldExit && !Core.CheckInventory("Spirit Orb", quant))
            Core.KillMonster("battleunderb", "Enter", "Spawn", "*", log: false);
        Core.CancelRegisteredQuests();
    }

    #endregion Misc

    #region Reputation
    public void GetAllRanks(bool doDeathPit)
    {
        ToggleBoost(BoostType.Reputation);

        AegisREP();
        AlchemyREP();
        ArcangroveREP();
        BaconCatREP();
        if (Core.IsMember)
            BeastMasterREP();
        BlacksmithingREP();
        BladeofAweREP(farmBoA: false);
        if (Core.isSeasonalMapActive("birdswithharms"))
            BrethwrenREP();
        BrightoakREP();
        ChaosMilitiaREP();
        ChaosREP();
        ChronoSpanREP();
        CraggleRockREP();
        DiabolicalREP();
        DoomWoodREP();
        DreadfireREP();
        DreadrockREP();
        DruidGroveREP();
        DwarfholdREP();
        ElementalMasterREP();
        EmberseaREP();
        EternalREP();
        EtherStormREP();
        EvilREP();
        if (Core.isSeasonalMapActive("rainbow"))
            FaerieCourtREP();
        FishingREP();
        GlaceraREP();
        GoodREP();
        HollowbornREP();
        HorcREP();
        InfernalArmyREP();
        LoremasterREP();
        LycanREP();
        MonsterHunterREP();
        MysteriousDungeonREP();
        MythsongREP();
        NecroCryptREP();
        NorthpointeREP();
        PetTamerREP();
        RavenlossREP();
        SandseaREP();
        if (Core.IsMember)
            SkyguardREP();
        SomniaREP();
        SpellCraftingREP();
        SwordhavenREP();
        ThunderForgeREP();
        TreasureHunterREP();
        TrollREP();
        VampireREP();
        YewMountainsREP();
        YokaiREP();
        if (doDeathPit)
        {
            DeathPitBrawlREP();
            DeathPitArenaREP();
        }

        ToggleBoost(BoostType.Reputation, false);
    }

    public void AegisREP(int rank = 10)
    {
        if (FactionRank("Aegis") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(4900, 4910, 4914); //Kick Some Can 4900, The Best You Can Buy 4910, Testing My Metal 4914
        while (!Bot.ShouldExit && FactionRank("Aegis") < rank)
        {
            Core.HuntMonster("skytower", "Seraphic Assassin", "Seraphic Assassin Dueled", 10, log: false);
            Core.HuntMonster("skytower", "Virtuous Warrior", "Warriors Dueled", 10, log: false);
            Core.HuntMonster("skytower", "Seraphic Assassin", "Assassins Handed To Them", 6, log: false);
            Core.HuntMonster("skytower", "Virtuous Warrior", "Warrior Butt Beaten", 6, log: false);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    /// <summary>
    /// Uses the specified parameters to make an Alchemy misture
    /// </summary>
    /// <param name="reagent1">The first reagent.</param>
    /// <param name="reagent2">The second reagent</param>
    /// <param name="rune">The rune to be used (AlchemyRunes.Gebo by default).</param>
    /// <param name="rank">The minimum rank to make the misture, use 0 for any rank.</param>
    /// <param name="loop">Whether loop till you run out of reagents</param>
    /// <param name="modifier">Some mistures have specific packet modifiers, default is Moose but you can find Man, mRe and others.</param>
    /// <param name="trait"></param>
    /// <param name="YMB"></param>
    /// <param name="item"></param>
    /// <param name="quant"></param>
    public void AlchemyPacket(string reagent1, string reagent2, AlchemyRunes rune = AlchemyRunes.Gebo, int rank = 0, bool loop = true, string modifier = "Moose", AlchemyTraits trait = AlchemyTraits.APw, bool YMB = false, string? item = null, int quant = 1)
    {
        if (rank != 0 && FactionRank("Alchemy") < rank || (item != null && Core.CheckInventory(item, quant)))
            AlchemyREP(rank);


        // Core.Join("Alchemy");
        if (!Core.CheckInventory(reagent1) || !Bot.Inventory.TryGetItem(reagent1, out var reg1))
        {
            Core.Logger("Something went wrong, you do not own " + reagent1, messageBox: true, stopBot: true);
            return;
        }
        if (!Core.CheckInventory(reagent2) || !Bot.Inventory.TryGetItem(reagent2, out var reg2))
        {
            Core.Logger("Something went wrong, you do not own " + reagent2, messageBox: true, stopBot: true);
            return;
        }

        int reagentid1 = reg1!.ID;
        int reagentid2 = reg2!.ID;

        if (reagent1 == "Dragon Scale")
            reg1!.ID = 11475;

        Core.Logger($"Reagents: [{reagent1}], [{reagent2}].");
        Core.Logger($"Rune: {rune}.");
        Core.Logger($"Modifier: {modifier}.");
        if (YMB)
            Core.Logger("\"YouMadBro\" Mode: Enabled (this will only buy 1 Dragon Runestone as it doesnt use it :D)");
        Core.Join("alchemy");
        int i = 1;
        if (loop)
        {
            while (!Bot.ShouldExit && Core.CheckInventory(new[] { reagent1, reagent2, "Dragon Runestone" }))
            {
                if (!Core.CheckInventory(new[] { reagent1, reagent2 }) || (item != null && Core.CheckInventory(item, quant)))
                    break;
                Packet();
                Core.Logger($"Completed alchemy x{i++}");
            }
        }
        else Packet();

        void Packet()
        {
            /*  
                YMB Mode: only uses 1 Dragon Runestone
                Non-YMB Mode: uses 1 of each reagent + 1 Dragon Runestone.
                Both Methods Have Been Tested. in YMB Badge & Potions.
                Potions Can be gotten from either but specific potions must use the non-YMB mode. 
            */

            if (Core.CheckInventory("Dragon Runestone"))
                Core.SendPackets(
                    YMB ?
                     $"%xt%zm%crafting%1%getAlchWait%{reagentid1}%{reagentid2}%true%Ready to Mix%{reagent1}%{reagent2}%{rune}%{modifier}%"
                    : $"%xt%zm%crafting%1%getAlchWait%{reagentid1}%{reagentid2}%true%Ready to Mix%{reagent1}%{reagent2}%{rune}%{trait}%");

            Core.Sleep();

            // This was the Required client packetfor alchemy (due to it not being here before.. and people spent billions of gold[sorry])
            if (Core.CheckInventory("Dragon Runestone"))
                Core.SendPackets("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"bVerified\":true,\"cmd\":\"alchOnStart\"}}}", toClient: true);

            Core.Sleep(4000);

            if (Core.CheckInventory("Dragon Runestone"))
                Core.SendPackets(
                    YMB ?
                    $"%xt%zm%crafting%1%checkAlchComplete%{reagentid1}%{reagentid2}%false%Mix Complete%{reagent1}%{reagent2}%{rune}%{modifier}%"
                   : $"%xt%zm%crafting%1%checkAlchComplete%{reagentid1}%{reagentid2}%true%Mix Complete%{reagent1}%{reagent2}%{rune}%{trait}%");
        }

    }

    /// <summary>
    /// Uses the Jera:hOu in the alchemy packet for starting rep.
    /// to find the correct trait for a specific pot, goto /join alchemy with the correct reagents
    /// and open packet logger, enable it, start "help me", "use dragon stones"
    /// slect the level/type/kind(atk, int, spell, etc), and start it, grab the packet(copy it)
    /// make request with that and the Potion's name+itemid(from tools > grabber > inventory > grab)
    /// </summary>
    public enum AlchemyTraits
    {
        Dam = 0, // Potent Honor Potion (trait, itemID)
        APw = 1, // Potent Battle Elixir
        Luc = 2, // Fate Tonic
        Int = 3, // Sage Tonic
        SPw = 4, // Potent Malevolence Elixir    
        hOu = 5, // Healer Elixer / Potent Guard Potion / Unstable Healer Elixer // rep spam with jerra
        hRe = 6, // Potent Revitalize Elixi
        mRe = 7, // Potent Destruction Elixir
        End = 8, // Body Tonic
        Eva = 9, //
        Str = 10,
        Cri = 11,
        Dex = 12,
        Wis = 13,
        Hea = 14 // Health Potion
        //more to be added by request
    };

    public void Voucher(string Voucher, int quant, string? shopName = null)
    {
        if (Core.CheckInventory(Voucher, quant))
            return;

        string map = "";
        int shopID = 0;

        Core.FarmingLogger(Voucher, quant);

        switch (Voucher)
        {
            case "Gold Voucher 500k":
            case "Gold Voucher 100k":
            case "Gold Voucher 200k":
                map = "alchemyacademy";
                shopID = 2036;
                shopName = "Gebo Shop";
                break;

            case "Gold Voucher 25k":
                map = "hydrachallenge";
                shopID = 1597;
                shopName = "Hydra Merge";
                break;

            case "Gold Voucher 7k":
                map = "alchemyacademy";
                shopID = 2116;
                shopName = "Fehu Shop";
                break;

            default:
                Core.Logger($"Invalid Gold Voucher: {Voucher}");
                return;
        }

        // Load shop safely
        int retry = 0;
        while (!Bot.ShouldExit && Bot.Shops.ID != shopID)
        {
            if (Bot.Map.Name != map)
            {
                Core.Join(map);
                Bot.Wait.ForMapLoad(map);
            }

            Bot.Shops.Load(shopID);
            Bot.Wait.ForActionCooldown(GameActions.LoadShop);
            Bot.Wait.ForTrue(() => Bot.Shops.IsLoaded && Bot.Shops.ID == shopID, 20);
            Core.Sleep(1000);
            if (Bot.Shops.ID == shopID || retry++ >= 20)
                break;
        }

        ShopItem? item = Bot.Shops.Items.FirstOrDefault(x => x?.Name == Voucher);
        if (item == null)
        {
            Core.Logger($"Item \"{Voucher}\" not found in the shop.");
            return;
        }

        int current = Bot.Inventory.GetQuantity(Voucher);
        int needed = Math.Min(item.MaxStack, quant - current);
        if (needed <= 0)
            return;

        // Extract voucher value in gold (e.g. "500k" => 500000)
        int valuePerItem = int.Parse(item.Name.Split(' ')[2].Replace("k", "000"));
        const int goldCap = 100_000_000;

        while (!Bot.ShouldExit && needed > 0)
        {
            // Max amount that fits within the 100M cap
            int maxBuyable = Math.Min(needed, goldCap / valuePerItem);
            if (maxBuyable <= 0)
            {
                Core.Logger($"Cannot buy any '{Voucher}' without exceeding the gold cap.");
                return;
            }

            Gold(maxBuyable * valuePerItem);
            Core.BuyItem(map, shopID, item.Name, maxBuyable);

            needed -= maxBuyable;
        }
    }

    public void DragonRunestone(int quant = 100)
    {
        if (Core.CheckInventory("Dragon Runestone", quant))
            return;

        if (Bot.Map.Name != "alchemyacademy")
            Core.Join("alchemyacademy");

        Core.FarmingLogger("Dragon Runestone", quant);

        Voucher("Gold Voucher 100k", quant);
        int amountToBuy = Math.Min(quant, 100);

        Core.BuyItem("alchemyacademy", 395, "Dragon Runestone", amountToBuy, 8844);
    }

    public void AlchemyREP(int rank = 10, bool goldMethod = true)
    {
        if (FactionRank("Alchemy") >= rank)
            return;

        if (!Bot.Reputation.FactionList.Exists(f => f.Name == "Alchemy"))
        {
            Core.Logger("Getting Pre-Ranking XP");
            if (!Core.CheckInventory(new[] { 11478, 11475, 7132 }))
            {
                DragonRunestone(2);
                Core.BuyItem("alchemy", 397, 11475, 2, 1232);
                Core.BuyItem("alchemy", 397, 11478, 1, 1235);
                Core.Join("alchemy");
                AlchemyPacket("Dragon Scale", "Ice Vapor", AlchemyRunes.Jera, loop: false, trait: CoreFarms.AlchemyTraits.hOu, YMB: goldMethod);
            }
        }

        Core.AddDrop("Dragon Scale", "Ice Vapor");
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank} Alchemy");

        int i = 1;
        while (!Bot.ShouldExit && FactionRank("Alchemy") < rank)
        {

            if (goldMethod)
            {
                if (!Core.CheckInventory(new[] { 11478, 11475, 7132 }))
                {
                    DragonRunestone(25);
                    Core.BuyItem("alchemy", 397, 11475, 20, 1232);
                    Core.BuyItem("alchemy", 397, 11478, 10, 1235);
                }

                AlchemyPacket(
                "Dragon Scale",
                "Ice Vapor",
                        // If Alchemy rank is less than 5, use Jera rune
                        FactionRank("Alchemy") < 5
                            ? AlchemyRunes.Jera
                        // Else if rank is less than 8 (but >= 5), use Fehu rune
                        : FactionRank("Alchemy") < 8
                            ? AlchemyRunes.Fehu
                            // Else (rank is 8 or higher), use Gebo rune
                            : AlchemyRunes.Gebo,
                trait: AlchemyTraits.hOu);


            }
            else
            {
                Core.EquipClass(ClassType.Farm);
                while (!Core.CheckInventory(11475, 30))
                    Core.KillMonster("lair", "Hole", "Center", "*", isTemp: false, log: false);
                Core.KillMonster("lair", "Enter", "Spawn", "*", "Ice Vapor", 30, isTemp: false, log: false);

                AlchemyPacket(
                "Dragon Scale",
                "Ice Vapor",
                        // If Alchemy rank is less than 5, use Jera rune
                        FactionRank("Alchemy") < 5
                            ? AlchemyRunes.Jera
                        // Else if rank is less than 8 (but >= 5), use Fehu rune
                        : FactionRank("Alchemy") < 8
                            ? AlchemyRunes.Fehu
                            // Else (rank is 8 or higher), use Gebo rune
                            : AlchemyRunes.Gebo,
                trait: AlchemyTraits.hOu);

            }
            Core.Logger($"Iteration {i++} completed");
        }
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void ArcangroveREP(int rank = 10)
    {
        if (FactionRank("Arcangrove") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        // A Necessary Sacrifice 794, Gorillaphant Poaching 795, Mustard and Pretzel Root 796
        // Thyme and a Half 797, Thistle Do Nicely 798, Pleased to Meat You 799, ArcanRobe 800
        // Ebony and Ivory Tusks 801
        Core.RegisterQuests(794, 795, 796, 797, 798, 799, 800, 801);
        while (!Bot.ShouldExit && FactionRank("Arcangrove") < rank)
        {
            for (int i = 0; i < 10; i++)
                Core.KillMonster("arcangrove", "LeftBack", "Left", "*", log: false); // Gorillaphant
            for (int i = 0; i < 10; i++)
                Core.KillMonster("arcangrove", "RightBack", "Left", "*", log: false); // Seed Spitter
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void BaconCatREP(int rank = 10)
    {
        if (FactionRank("BaconCat") >= rank)
            return;

        if (!Bot.Quests.IsUnlocked(5120))
        {
            Core.Logger($"Quest [5120] \"Ziri Is Also Tough\", has yet to be completed, please run \"Farm/REP/BaconCatREP.cs\"", messageBox: true);
            return;
        }

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(5112, 5120);
        while (!Bot.ShouldExit && FactionRank("BaconCat") < rank)
            Core.HuntMonster("baconcatlair", "Ice Cream Shark", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void BeastMasterREP(int rank = 10)
    {
        if (FactionRank("BeastMaster") >= rank)
            return;

        if (!Core.IsMember)
        {
            Core.Logger("Beast Master REP is Member-Only", messageBox: true);
            return;
        }

        Core.EquipClass(ClassType.Farm);
        Experience(50);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");
        // Core.RegisterQuests(3757);

        // 3754 | Beat the Beasts
        while (!Bot.ShouldExit && FactionRank("BeastMaster") < 3)
        {
            Core.EnsureAccept(3754);
            Core.HuntMonster("boxes", "Sneevil", "Beast Crate", 6, log: false);
            Core.HuntMonster("pirates", "Fishwing", "Fish Scale", 6, log: false);
            Core.EnsureComplete(3754);
        }

        // 3755 | Secrets and Scrolls
        while (!Bot.ShouldExit && FactionRank("BeastMaster") < 4)
        {
            Core.EnsureAccept(3755);
            Core.HuntMonster("bamboo", "Tanuki", "Secret Scroll of Beast Commanding", 7, log: false);
            Core.HuntMonster("pines", "Pine Troll", "Troll's Treatise on Beasts", log: false);
            Core.EnsureComplete(3755);
        }

        // 3756 | Taming the Elementals
        while (!Bot.ShouldExit && FactionRank("BeastMaster") < 6)
        {
            Core.EnsureAccept(3756);
            Core.HuntMonster("mafic", "Living Fire", "Living Flame Core", 6, log: false);
            Core.HuntMonster("elemental", "Mana Imp", "Mana Manipulation Orb", 5, log: false);
            Core.EnsureComplete(3756);
        }

        // 3757 | Dark Creature Demands
        while (!Bot.ShouldExit && FactionRank("BeastMaster") < rank)
        {
            Core.EnsureAccept(3757);
            Core.HuntMonster("pyramid", "Golden Scarab", "Gleaming Gems of Containment", 16, log: false);
            Core.HuntMonster("dreamnexus", "Solar Phoenix", "Bright Binding of Submission", 16, log: false);
            Core.EnsureComplete(3757);
        }

        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    #region BlacksmithingREP
    public void BlacksmithingREP(int rank = 10, bool UseGold = false, bool BulkFarmGold = false)
    {
        if (FactionRank("Blacksmithing") >= rank)
            return;

        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.EquipClass(ClassType.Farm);
        Core.Logger($"Farming rank {rank}");

        if (UseGold)
        {
            Core.Logger("Using Gold Method");

            while (!Bot.ShouldExit && FactionRank("Blacksmithing") < rank)
            {
                Core.EnsureAccept(8737);

                // Get remaining reputation XP needed to reach next rank
                int remainingRepXP = RemainingFactionXp("Blacksmithing");
                int itemsNeeded = (remainingRepXP + 999) / 1000; // Round up
                int currentQuantity = Bot.Inventory.GetQuantity("Gold Voucher 500k");

                Core.Logger($"Remaining Reputation XP: {remainingRepXP}");
                Core.Logger($"Current Gold Voucher Quantity: {currentQuantity}");
                Core.Logger($"Items Needed: {itemsNeeded}");

                if (remainingRepXP > 0)
                {
                    // Cap items at 200 per transaction
                    int itemsToBuy = Math.Min(200, Math.Max(0, Math.Min(itemsNeeded, 300 - currentQuantity)));
                    Core.Logger($"Items to Buy in this Transaction: {itemsToBuy}");

                    // Calculate exact gold needed for this transaction

                    int goldNeeded = itemsToBuy * FiveHundredK;
                    Core.Logger($"Gold Needed for {itemsToBuy} vouchers: {goldNeeded}");

                    // Only farm as much gold as needed for this batch
                    Gold(goldNeeded);

                    if (Core.CheckInventory("Gold Voucher 500k", itemsToBuy))
                        Core.Logger($"Already have {itemsToBuy} Gold Vouchers, skipping purchase.");
                    else
                        Core.BuyItem("alchemyacademy", 2036, "Gold Voucher 500k", itemsToBuy);
                    Core.BuyItem("alchemyacademy", 2036, "Gold Voucher 500k", itemsToBuy);
                    Core.EnsureCompleteMulti(8737, itemsNeeded);
                }
                else
                {
                    Core.Logger("Already at max rank.");
                    return;
                }
            }


            ToggleBoost(BoostType.Reputation, false);
            Core.SavedState(false);
            Core.Logger("Reputation boost deactivated and state saved.");
            return;
        }
        Core.Logger("Using Non-Gold Method");
        // Core.Logger($"If you can't Solo SlugButter, Either use the Gold method or Run the AP Script (Found in: Good-ArchPaladin) as it can Solo the boss 👍");

        Core.RegisterQuests(2777);
        while (!Bot.ShouldExit && FactionRank("Blacksmithing") < 4 && !UseGold)
        {
            // Core.EnsureAccept(2777);
            Core.HuntMonster("greenguardeast", "Wolf", "Furry Lost Sock", 2, log: false);
            Core.HuntMonster("greenguardwest", "Slime", "Slimy Lost Sock", 5, log: false);
            // Core.EnsureComplete(2777);
        }
        Core.CancelRegisteredQuests();

        // Core.AbandonQuest(2777);

        Core.RegisterQuests(8736);
        Core.EquipClass(ClassType.Solo);
        while (!Bot.ShouldExit && FactionRank("Blacksmithing") < rank && !UseGold)
        {
            // Core.EnsureAccept(8736);
            Core.HuntMonster("hydrachallenge", "Hydra Head 25", "Hydra Scale Piece", 75, isTemp: false, log: false);
            Core.HuntMonster("maul", "Creature Creation", "Creature Shard", isTemp: false, log: false);
            Core.HuntMonster("towerofdoom", "Dread Klunk", "Monster Trophy", 15, isTemp: false, log: false);
            // Core.EnsureComplete(8736);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }
    #endregion BlacksmithingREP

    /// <summary>
    /// Farms reputation for the "Blade of Awe" faction and optionally purchases the Blade of Awe.
    /// </summary>
    /// <param name="rank">The target faction rank to achieve. Defaults to rank 10.</param>
    /// <param name="farmBoA">
    /// If true, the method farms to rank 6 if needed to buy the Blade of Awe from the museum,
    /// then continues farming to the specified rank.
    /// </param>
    /// <remarks>
    /// The method unlocks the necessary quest, farms to the required rank, and purchases the Blade of Awe 
    /// if <paramref name="farmBoA"/> is true and the item is not already in the inventory.
    /// </remarks>
    public void BladeofAweREP(int rank = 10, bool farmBoA = true)
    {
        //Quests will now be done regardless of farmboa bool, purely to unlock them.
        UnlockBoA();

        int targetRank = farmBoA && !Core.CheckInventory(17585) ? 6 : rank;

        if (FactionRank("Blade of Awe") < targetRank || (farmBoA && FactionRank("Blade of Awe") < rank))
        {
            Core.SavedState();
            Core.EquipClass(ClassType.Farm);
            Core.Logger($"Farming rank {(FactionRank("Blade of Awe") < targetRank ? targetRank : rank)}");

            Core.RegisterQuests(2935);
            while (!Bot.ShouldExit && (FactionRank("Blade of Awe") < targetRank || (farmBoA && FactionRank("Blade of Awe") < targetRank)))
                Core.KillMonster("castleundead", "Enter", "Left", "Skeletal Viking");
            Core.CancelRegisteredQuests();
            Core.SavedState(false);
        }

        if (farmBoA && !Core.CheckInventory(17585))
            Core.BuyItem("museum", 631, 17585);
    }

    public void UnlockBoA()
    {
        if (Core.isCompletedBefore(2937))
            return;

        if (!Core.isCompletedBefore(2933))
        {
            Core.Logger($"Doing Quest: [2933] - \"Find the Stonewrit!\"");
            Core.EquipClass(ClassType.Solo);
            Core.EnsureAccept(2933);
            Core.HuntMonster("j6", "Sketchy Dragon", "Stonewrit Found!", 1, false, log: false);
            Core.EnsureComplete(2933);
            Core.Logger($"Completed Quest: [2933] - \"Find the Stonewrit!\"");
        }
        else Core.Logger($"Already Completed: [2933] - \"Find the Stonewrit!\"");

        if (!Core.isCompletedBefore(2934))
        {
            Core.Logger($"Doing Quest: [2934] - \"Find the Handle!\"");
            Core.EquipClass(ClassType.Solo);
            Core.EnsureAccept(2934);
            Core.HuntMonster("gilead", "Fire Elemental", "Handle Found!", 1, false, log: false);
            Core.EnsureComplete(2934);
            Core.Logger($"Completed Quest: [2934] - \"Find the Handle!\"");
        }
        else Core.Logger($"Already Completed: [2934] - \"Find the Handle!\"");

        if (!Core.isCompletedBefore(2935))
        {
            Core.Logger($"Doing Quest: [2935] - \"Find the Hilt!\"");
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAccept(2935);
            Core.HuntMonster("castleundead", "Skeletal Viking", "Hilt Found!", 1, false, log: false);
            Core.EnsureComplete(2935);
            Core.Logger($"Completed Quest: [2935] - \"Find the Hilt!\"");
        }
        else Core.Logger($"Already Completed: [2935] - \"Find the Hilt!\"");

        if (!Core.isCompletedBefore(2936))
        {
            Core.Logger($"Doing Quest: [2936] - \"Find the Blade!\"");
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAccept(2936);
            Core.HuntMonster("hydra", "Hydra Head", "Blade Found!", 1, false, log: false);
            Core.EnsureComplete(2936);
            Core.Logger($"Completed Quest: [2936] - \"Find the Blade!\"");
        }
        else Core.Logger($"Already Completed: [2936] - \"Find the Blade!\"");

        if (!Core.isCompletedBefore(2937))
        {
            Core.ResetQuest(2937);
            Core.Logger($"Doing Quest: [2937] - \"Find the Runes!\"");
            Core.EquipClass(ClassType.Solo);
            Core.EnsureAccept(2937);
            Core.KillEscherion("Runes Found!", log: false);
            Core.EnsureComplete(2937);
            Core.Logger($"Completed Quest: [2937] - \"Find the Runes!\"");
        }
        else Core.Logger($"Already Completed: [2937] - \"Find the Runes!\"");
    }

    public void BrethwrenREP(int rank = 10)
    {
        if (FactionRank("Brethwren") >= rank || !Core.isSeasonalMapActive("birdswithharms"))
            return;

        if (!Bot.Quests.IsAvailable(8989))
        {
            Core.Logger("Quest not avaible for farm, run the complete Birds With Harms storyline script.");
            return;
        }

        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.EquipClass(ClassType.Farm);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(8989);
        while (!Bot.ShouldExit && FactionRank("Brethwren") < rank)
            Core.HuntMonster("birdswithharms", "Turkonian", log: false);

        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void BrightoakREP(int rank = 10)
    {
        if (FactionRank("Brightoak") >= rank)
            return;

        if (!Bot.Quests.IsAvailable(4667))
        {
            Core.Logger("Quest not available for farm, do Brightoak saga till Elfhame [Unlocking the Guardian's Mouth]");
            return;
        }

        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        while (!Bot.ShouldExit && FactionRank("Brightoak") < rank)
        {
            if (Bot.Map.Name != "elfhame")
            {
                Core.Join("elfhame");
                Bot.Wait.ForMapLoad("elfhame");
            }
            if (!Bot.Quests.IsInProgress(4667))
            {
                Bot.Quests.Accept(4667);
                Bot.Wait.ForQuestAccept(4667);
            }
            Bot.Map.GetMapItem(3984);
            while (Bot.ShouldExit && !Bot.TempInv.Contains("Puzzle Completed")) { Core.Sleep(); }
            if (Bot.Quests.CanComplete(4667))
            {
                Bot.Quests.Complete(4667);
                Bot.Wait.ForQuestComplete(4667);
            }
            Core.Sleep();
        }
        // Core.Jump("Enter", "Spawn");
        Bot.Options.SkipCutscenes = true;
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void ChaosMilitiaREP(int rank = 10)
    {
        if (FactionRank("Chaos Militia") >= rank)
            return;

        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(5775); //Expect the Inquisitors 5775
        while (!Bot.ShouldExit && FactionRank("Chaos Militia") < rank)
            Core.HuntMonster("citadel", "Inquisitor Guard", log: false);
        Bot.Wait.ForQuestComplete(5775);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void ChaosREP(int rank = 10)
    {
        if (FactionRank("Chaos") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(3594); //Embrace Your Chaos 3594
        while (!Bot.ShouldExit && FactionRank("Chaos") < rank)
            Core.KillMonster("mountdoomskull", "b1", "Left", "*", log: false);
        Bot.Wait.ForQuestComplete(3594);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void ChronoSpanREP(int rank = 10)
    {
        if (FactionRank("ChronoSpan") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(2204); //Do the 'do 2204
        while (!Bot.ShouldExit && FactionRank("ChronoSpan") < rank)
        {
            // Core.EnsureAccept(2204); //Do the 'do 2204
            Core.KillMonster("thespan", "r6", "Left", "Moglin Ghost", "Tin of Ghost Dust", 2, log: false);
            Core.KillMonster("thespan", "r4", "Left", "Minx Fairy", "8 oz Fairy Glitter", 3, log: false);
            Core.KillMonster("thespan", "r4", "Left", "Tog", "Tog Fang", 4, log: false);
            // Core.EnsureComplete(2204); //Do the 'do 2204
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void CraggleRockREP(int rank = 10)
    {
        if (FactionRank("CraggleRock") >= rank)
            return;

        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");
        Core.AddDrop("Empowered Voidstone");
        Core.RegisterQuests(7277);
        //Star of the Sandsea 7277
        Core.Join("wanders");
        while (!Bot.ShouldExit && FactionRank("CraggleRock") < rank)
        {
            foreach (Monster mob in Bot.Monsters.MapMonsters.Where(x => x.ID == 560))
            {
                while (Bot.Player.Cell != mob.Cell)
                {
                    Core.Jump(mob.Cell, "Left");
                    Core.Sleep();
                }

                Bot.Kill.Monster(mob.MapID);
                Core.Sleep();

                if (FactionRank("CraggleRock") >= rank)
                    break;
            }
        }
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
        Core.CancelRegisteredQuests();
    }

    public void DeathPitArenaREP(int rank = 10)
    {
        if (FactionRank("Death Pit Arena") >= rank)
            return;

        if (!Bot.Quests.IsAvailable(5154))
        {
            Core.Logger("Quest not available for farm, do the Death Pit Arena saga and unlock the quest [Pax Defeated]");
            return;
        }

        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        while (!Bot.ShouldExit && FactionRank("Death Pit Arena") < rank)
        {
            Core.EnsureAccept(5153);
            Core.HuntMonster("deathpit", "General Hun'Gar", "General Hun'Gar Defeated", log: false);
            Core.EnsureComplete(5153);
        }
        Bot.Wait.ForQuestComplete(5153);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DiabolicalREP(int rank = 10)
    {
        if (FactionRank("Diabolical") >= rank)
            return;

        if (!Bot.Quests.IsUnlocked(7877))
        {
            Core.EnsureAccept(7875);
            Core.HuntMonster("timevoid", "Unending Avatar", "Everlasting Scale");
            Core.EnsureComplete(7875);

            Core.EnsureAccept(7876);
            Core.HuntMonster($"twilightedge", "ChaosWeaver Warrior", "Chaotic Arachnid's Flesh");
            Core.EnsureComplete(7876);
        }

        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        while (!Bot.ShouldExit && FactionRank("Diabolical") < rank)
        {
            Core.EnsureAccept(7877);
            Core.HuntMonster("mudluk", "Tiger Leech", "Swamped Leech Tooth", log: false);
            Core.EnsureComplete(7877);
        }
        Bot.Wait.ForQuestComplete(7877);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void SkyeREP(int rank = 10)
    {
        if (!Core.isCompletedBefore(9125))
        {
            Core.Logger("Quest \"Your Hero [9125]\" Not complete (Run \"09SeaVoice\"), cannot continue the rep");
            return;
        }

        if (FactionRank("Skye") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");
        Core.RegisterQuests(9709, 9710, 9711, 9717);
        while (!Bot.ShouldExit && FactionRank("Skye") < rank)
            Core.KillMonster("balemorale", "r10", "Bottom", "*", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DoomWoodREP(int rank = 10)
    {
        if (FactionRank("DoomWood") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(1151, 1152, 1153); //Minion Morale 1151, Shadowfall is DOOMed 1152, Grave-lyn Danger, 1153
        while (!Bot.ShouldExit && FactionRank("DoomWood") < rank)
            Core.KillMonster("shadowfallwar", "Garden1", "Left", "*", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DreadfireREP(int rank = 10)
    {
        if (FactionRank("Dreadfire") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(5697); //Gather Crystals 5697
        while (!Bot.ShouldExit && FactionRank("Dreadfire") < rank)
            Core.KillMonster("dreadfire", "r13", "Bottom", "Arcane Crystal", log: false);
        Bot.Wait.ForQuestComplete(5697);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DreadrockREP(int rank = 10)
    {
        if (FactionRank("Dreadrock") >= rank)
            return;

        Core.AddDrop("Ghastly Dreadrock Blade");
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(4863, 4862, 4865, 4868); //Endurance Tesssssst 4863, Supply Run 4862, Ghastly Blades 4865, Glub, Glub, Glub 4868
        while (!Bot.ShouldExit && FactionRank("Dreadrock") < rank)
            Core.KillMonster("dreadrock", "r3", "Bottom", "*", log: false);
        Bot.Wait.ForQuestComplete(4868);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DruidGroveREP(int rank = 10)
    {
        if (FactionRank("Druid Grove") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(3049); //Help Professor Maedoc 3049
        while (!Bot.ShouldExit && FactionRank("Druid Grove") < rank)
            Core.HuntMonster("bloodtusk", "Crystal-Rock", log: false);
        Bot.Wait.ForQuestComplete(3049);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void DwarfholdREP(int rank = 10)
    {
        if (FactionRank("Dwarfhold") >= rank)
            return;


        if (!Bot.Quests.IsUnlocked(320))
        {
            // Seven Sisters
            Core.EnsureAccept(319);
            Core.GetMapItem(56, 7, "tavern");
            Core.EnsureComplete(319);
        }

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(320, 321); //Warm and Furry 320, Shell Shock 321
        while (!Bot.ShouldExit && FactionRank("Dwarfhold") < rank)
        {
            Core.EnsureAcceptmultiple(new[] { 320, 321 }); //Warm and Furry 320, Shell Shock 321
            Core.KillMonster("pines", "Enter", "Right", "Pine Grizzly", "Bear Skin", 5, log: false);
            Core.KillMonster("pines", "Enter", "Right", "Red Shell Turtle", "Red Turtle Shell", 5, log: false);
            Core.EnsureComplete(new[] { 320, 321 }); //Warm and Furry 320, Shell Shock 321
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);

    }

    public void ElementalMasterREP(int rank = 10)
    {
        if (FactionRank("Elemental Master") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        if (!Core.isCompletedBefore(3052))
        {
            Core.EnsureAccept(3052);
            Core.GetMapItem(1921, 1, "dragonrune");
            Core.GetMapItem(1922, 1, "dragonrune");
            Core.GetMapItem(1923, 1, "dragonrune");
            Core.GetMapItem(1924, 1, "dragonrune");
            Core.EnsureComplete(3052);
        }

        // Define a dictionary to store the secondary items for each elemental
        Dictionary<string, (string, string)> elementalItems = new()
        {
            { "Water", ("Water Drop", "Water Core") },
            { "Fire", ("Flame", "Fire Core") },
            { "Wind", ("Breeze", "Air Core") },
            { "Earth", ("Stone", "Earth Core") }
        };

        if (!Bot.Quests.IsDailyComplete(3299) && Core.IsMember)
        {
            Core.Logger("Doing daily first.");
            Core.EnsureAccept(3299);
            foreach (var element in elementalItems)
                Core.HuntMonster("gilead", $"{element.Key} Elemental", element.Value.Item1, 6, log: false); // Use the second item
            Core.EnsureComplete(3299);
        }

        Core.Logger(!Core.IsMember ? "Daily is mem only, Onto the Farm" : "Daily complete, onto the farm.");

        while (!Bot.ShouldExit && FactionRank("Elemental Master") < rank)
        {
            Core.EnsureAcceptmultiple(new[] { 3050, 3298 });
            Core.EquipClass(ClassType.Farm);
            foreach (var element in elementalItems)
            {
                Core.HuntMonster("gilead", $"{element.Key} Elemental", element.Value.Item2, log: false); // Use the second item
                Core.HuntMonster("gilead", $"{element.Key} Elemental", element.Value.Item1, 5, log: false); // Use the second item
            }
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("gilead", "Mana Elemental", "Mana Core", log: false);
            Core.EnsureComplete(new[] { 3050, 3298 });
        }

        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void EmberseaREP(int rank = 10)
    {
        if (FactionRank("Embersea") >= rank)
            return;

        // MembershipDues(MemberShipsIDS.Embersea, rank);

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        //  Slay the Blazebinders (500rep - 5 kills)
        Core.RegisterQuests(4228);
        while (!Bot.ShouldExit && FactionRank("Embersea") < rank)
            Core.HuntMonster("fireforge", "Blazebinder", log: false);

        ToggleBoost(BoostType.Reputation, false);
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
    }

    public void EternalREP(int rank = 10)
    {
        if (FactionRank("Eternal") >= rank)
            return;

        if (!Bot.Quests.IsAvailable(5198))
        {
            Core.Logger("Can't do farming quest [Sphynxes are Riddled with Gems] (/fourdpyramid)", messageBox: true);
            return;
        }

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(5198);
        while (!Bot.ShouldExit && FactionRank("Eternal") < rank)
        {
            Core.EnsureAccept(5198);
            Core.HuntMonsterMapID("fourdpyramid", 19, "White Gem", 2, log: false);
            Core.HuntMonsterMapID("fourdpyramid", 20, "Black Gem", 2, log: false);
            Core.EnsureComplete(5198);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void EtherStormREP(int rank = 10)
    {
        if (FactionRank("Etherstorm") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(1721); //Defend Your Master! 1721
        while (!Bot.ShouldExit && FactionRank("Etherstorm") < rank)
        {
            Core.EnsureAccept(1721);
            Core.HuntMonster("etherwardes", "Water Dragon Warrior", "Water Dragon Tears", 3, log: false);
            Core.HuntMonster("etherwardes", "Fire Dragon Warrior", "Fire Dragon Flames", 3, log: false);
            Core.HuntMonster("etherwardes", "Air Dragon Warrior", "Air Dragon Breaths", 3, log: false);
            Core.HuntMonster("etherwardes", "Earth Dragon Warrior", "Earth Dragon Claws", 3, log: false);
            Core.EnsureComplete(1721);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void EvilREP(int rank = 10)
    {
        if (FactionRank("Evil") >= rank)
            return;

        Core.ChangeAlignment(Alignment.Evil);
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(364); //Youthanize 364
        while (!Bot.ShouldExit && FactionRank("Evil") < 4)
            Core.HuntMonster("swordhavenbridge", "Slime", "Youthanize", log: false);
        Core.CancelRegisteredQuests();

        // Core.RegisterQuests(Core.IsMember ? 366 : 367); //Dangerous Decor 366, Bone-afide 367

        if (!Core.IsMember)
            Core.RegisterQuests(367); //Youthanize 364
        while (!Bot.ShouldExit && FactionRank("Evil") < rank)
        {
            if (Core.IsMember)
            {
                Core.EnsureAccept(366);
                Core.HuntMonster("sleuthhound", "Chair", "Chair", 4, log: false);
                Core.HuntMonster("sleuthhound", "Table", "Table", 2, log: false);
                Core.HuntMonster("sleuthhound", "Bookcase", "Bookcase", log: false);
                Core.EnsureComplete(366);
            }
            else
            {
                Core.KillMonster("castleundead", "Enter", "Left", "*", "Replacement Tibia", 6, log: false);
                Core.KillMonster("castleundead", "Enter", "Left", "*", "Phalanges", 3, log: false);
            }
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void FishingREP(int rank = 10, bool shouldDerp = false, bool trashBait = true, bool getBoosts = true)
    {
        if (FactionRank("Fishing") >= rank)
        {
            if (trashBait)
                Core.TrashCan("Fishing Bait", "Fishing Dynamite");
            return;
        }

        if (!Bot.Reputation.FactionList.Exists(f => f.Name == "Fishing"))
        {
            Core.TrashCan(new[] { "Fishing Bait", "Fishing Dynamite" });
            GetBaitandDynamite(0, 1);
        }

        int waitTimer = 3500;
        int successful = 1;
        int failed = 1;
        int startingRep = FactionRep("Fishing");
        int currentRep = FactionRep("Fishing");
        Core.AddDrop("Fishing Bait", "Fishing Dynamite");
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        Core.Logger($"Farming rank {rank}");

        Bot.Events.ExtensionPacketReceived += FishingWaiter;
        while (!Bot.ShouldExit && FactionRank("Fishing") < rank)
        {
            GetBaitandDynamite(0, 50); // Always get dynamite since we're above rank 2

            Core.Join("fishing");
            Bot.Wait.ForCellChange("Enter");
            Bot.Wait.ForTrue(() => Bot.Player.Loaded, 20);

            Core.Logger("Fishing With: Dynamite");

            while (!Bot.ShouldExit && Core.CheckInventory("Fishing Dynamite") && FactionRank("Fishing") < rank && (!shouldDerp || !Core.HasAchievement(14)))
            {
                Core.Sleep(1000);
                Bot.Send.Packet("%xt%zm%FishCast%1%Dynamite%30%");
                Core.Logger($"CatchTimer™ Delay: {waitTimer}ms");
                Core.Sleep(waitTimer);
                Bot.Send.Packet("%xt%zm%getFish%1%false%");
                Core.Sleep(1000);

                currentRep = FactionRep("Fishing");
                Core.Logger(currentRep > startingRep ? $"Successful! [Dynamite Cast x{successful++}]" : $"Failed! [Dynamite Cast x{failed++}]");
            }
        }

        Bot.Events.ExtensionPacketReceived -= FishingWaiter;
        waitTimer = 0;
        if (trashBait)
            Core.TrashCan(new[] { "Fishing Bait", "Fishing Dynamite" });
        Core.SavedState(false);

        void FishingWaiter(dynamic packet)
        {
            var type = packet["params"].type;
            var data = packet["params"].dataObj;

            if (type is not null && type == "json")
            {
                var cmd = data.cmd.ToString();

                switch (cmd)
                {
                    case "castWait":
                        if (data.wait is not null)
                        {
                            waitTimer = data.wait;
                            Core.Logger($"Derp Moosefish: {data.derp}, Set CatchTimer™: {waitTimer}ms");
                        }
                        break;


                    //idt this one works
                    case "CatchResult":
                        foreach (var c in data.catchResult)
                        {
                            if (c is null || (string)c["act"] == null || (int)c["myRep"] == 0)
                                continue;

                            switch ((string)c["act"])
                            {
                                case "Miss":
                                case "CatchPole":
                                    Core.Logger($"{(string)c["act"]}");
                                    break;
                            }

                            if ((int)c["myRep"] != 0)
                            {
                                Core.Logger($"{(int)c["myRep"]}");
                            }
                        }
                        break;
                }
            }
        }

    }

    public void GetBaitandDynamite(int fishingBaitQuant, int fishingDynamiteQuant)
    {
        if (Core.CheckInventory("Fishing Bait", fishingBaitQuant) && Core.CheckInventory("Fishing Dynamite", fishingDynamiteQuant))
            return;

        void FarmItem(string itemName, int quantity, string map, string cell, string pad, string monster)
        {
            if (quantity <= 0) return;

            Core.AddDrop(itemName);
            Core.RegisterQuests(1682);
            Core.FarmingLogger(itemName, quantity);

            while (!Bot.ShouldExit && !Core.CheckInventory(itemName, quantity))
            {
                Core.KillMonster(map, cell, pad, monster, log: false);
                Bot.Wait.ForPickup(itemName);
            }
        }

        FarmItem("Fishing Bait", fishingBaitQuant, "greenguardwest", "West3", "Right", "Frogzard");
        FarmItem("Fishing Dynamite", fishingDynamiteQuant, "greenguardwest", "West4", "Right", "Slime");

        Bot.Quests.UnregisterQuests(1682);
        Core.AbandonQuest(1682);
        Core.Logger("Returning to Fishing Map");
    }


    public void GetFish(int itemID, int quant, int quest)
    {
        if (Core.CheckInventory(itemID, quant)) return;

        ItemBase? reward = Core.EnsureLoad(quest)?.Rewards.Find(x => x.ID == itemID);
        if (reward != null)
            Core.FarmingLogger(reward.Name, quant);

        while (!Bot.ShouldExit && !Core.CheckInventory(itemID, quant))
        {
            if (!Core.CheckInventory("Fishing Dynamite"))
                GetBaitandDynamite(0, 20);

            Core.Join("fishing");

            while (!Bot.ShouldExit && Core.CheckInventory("Fishing Dynamite") && !Core.CheckInventory(itemID, quant))
            {
                int CurrentDynamiteQuant = Bot.Inventory.GetQuantity("Fishing Dynamite");
                Bot.Send.Packet($"%xt%zm%FishCast%1%Dynamite%30%");
                Core.Sleep(3500);
                Bot.Wait.ForTrue(() => CurrentDynamiteQuant == CurrentDynamiteQuant - 1, 20);
                Core.SendPackets($"%xt%zm%getFish%1%false");
                Core.Logger($"Dynamite: {Bot.Inventory.GetQuantity("Fishing Dynamite")} Fish: {Bot.TempInv.GetQuantity(itemID)}/{quant}");
            }
        }
    }
    public string[] AcceptablePvPAmulets = { "Mithril PvP Amulet +15000", "Diamond PvP Amulet +5500", "Platinum PvP Amulet +5000" };
    public void DeathPitBrawlREP(int rank = 10)
    {
        if (FactionRank("Death Pit Brawl") >= rank)
            return;

        Core.AddDrop("Death Pit Token");
        Core.EquipClass(ClassType.Solo);
        ToggleBoost(BoostType.Reputation);
        Core.ToggleAggro(false);

        Core.Logger($"Farming rank {rank}");
        Core.Logger("Checking if farm quests are unlocked--");
        if (Core.isCompletedBefore(5157))
        {
            Core.Logger("Unlocking farm quets");
            if (!Core.isCompletedBefore(5155))
            {
                Core.EnsureAccept(5155);
                DeathPitToken();
                Core.EnsureComplete(5155);
            }

            if (!Core.isCompletedBefore(5156))
                Core.ChainComplete(5156);

            if (!Core.isCompletedBefore(5157))
            {
                Core.EnsureAccept(5157);
                RunDeathPitBrawl("Death Pit Token", 1, 1);
                Core.EnsureComplete(5157);
            }
        }

        Core.Logger("Rep Time");
        RunDeathPitBrawl();

        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.ToggleAggro(true);
    }

    void RunDeathPitBrawl(string? item = null, int quant = 1, int rank = 10, bool canSoloBoss = true)
    {
        foreach (int QID in new[] { 5153, 5156, 5157, 5165 })
        {
            if (Bot.Quests.IsUnlocked(QID))
                Core.RegisterQuests(QID);
        }

        if (Bot.Map.Name == "deathpitbrawl")
        {
            Core.Logger("Started in PvP map, which doesnt allow us to equip things if needed and can cause issues. Joining whitemap first.");
            Core.Join("whitemap");
        }

        canSoloBoss = Core.CBOBool("PvP_SoloPvPBoss", out bool KillAds);

        // Find the first matching amulet in inventory or bank
        string? amulet = AcceptablePvPAmulets
            .FirstOrDefault(name => Bot.Inventory.Items.Concat(Bot.Bank.Items).Any(i => i?.Name == name));

        // Equip the amulet if found in inventory or bank
        if (amulet != null)
        {
            Core.Unbank(amulet);
            Core.Equip(amulet);
        }

        Core.Logger($"Kill Additional mobs (more trophies - slower depending on gear): {KillAds}");
        Core.FarmingLogger(item, quant, "RunDeathPitBrawl");

        KillAds = new[] { "Brawler Token", "Restorer Token" }.Contains(item!);

        int ExitAttempt = 0;
        int Death = 0;

    Start:
        while (!Bot.ShouldExit && ((item != null && !Core.CheckInventory(item, quant)) || (item == null && FactionRank("Death Pit Brawl") < rank)))
        {
            while (!Bot.ShouldExit && Bot.Map.Name != "deathpitbrawl")
            {
                Core.Logger("Joining Brawl");
                Core.Join("deathpitbrawl-999999", "Enter0", "Spawn");
                Core.Sleep();
            }

            int Move = 1;
            Core.PvPMove(5, "Morale0C", 228, 291);
            Core.Logger($"Move: {Move++}");
            if (!Bot.Player.Alive)
                goto RestartOnDeath;
            Core.PvPMove(4, "Morale0B", 936, 397);
            Core.PvPMove(7, "Morale0A", 946, 394);
            Core.PvPMove(9, "Crosslower", 948, 400);
            Core.PvPMove(14, "Crossupper", 903, 324);
            Core.PvPMove(18, "Resource1A", 482, 295);

            if (KillAds)
            {
                Core.PVPKilling();
                if (!Bot.Player.Alive)
                    goto RestartOnDeath;
            }

            Core.PvPMove(20, "Resource1B", 938, 400);

            if (KillAds)
            {
                Core.PVPKilling();
                if (!Bot.Player.Alive)
                    goto RestartOnDeath;
            }

            Core.PvPMove(21, "Resource1A", 9, 435);
            Core.PvPMove(19, "Crossupper", 461, 315);
            Core.PvPMove(17, "Crosslower", 54, 339);
            Core.PvPMove(15, "Morale1A", 522, 286);

            Bot.Kill.Monster(13);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(23, "Morale1B", 948, 403);

            Bot.Kill.Monster(14);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(25, "Morale1C", 945, 397);

            Bot.Kill.Monster(15);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;

            Core.PvPMove(28, "Captain1", 943, 404);

            Bot.Kill.Monster(16);
            if (!Bot.Player.Alive)
                goto RestartOnDeath;


            if (!string.IsNullOrEmpty(item))
            {
                Bot.Wait.ForDrop(item, 40);
                Core.Sleep(1500);
                Bot.Wait.ForPickup(item, 40);
                Core.FarmingLogger(item, quant);
            }
            Core.Sleep(1500);
            goto Exit;

        Exit:
            while (!Bot.ShouldExit && Bot.Map.Name != "battleon")
            {
                Core.Logger($"Attempting Exit {ExitAttempt++}.");
                Bot.Combat.CancelTarget();
                Bot.Wait.ForCombatExit();
                Bot.Map.Join("battleon-999999");
                Core.Sleep(1500);
                if (Bot.Map.Name != "battleon")
                    Core.Logger("Failed!? HOW.. try agian");
                else
                {
                    Core.Logger("Successful!");
                    ExitAttempt = 0;
                    goto Start;
                }
            }

        RestartOnDeath:
            Core.Logger($"Death: {Death++}, resetting");
            while (!Bot.ShouldExit)
            {
                Bot.Wait.ForTrue(() => Bot.Player.Alive, 100);
                Core.Logger($"Attempting Death Exit {ExitAttempt++}.");
                Bot.Map.Join("battleon-999999");
                Bot.Wait.ForMapLoad("battleon");
                Core.Sleep(1500);
                if (Bot.Map.Name != "battleon")
                    Core.Logger("Failed!? HOW.. try agian");
                else
                {
                    Core.Logger("Successful!");
                    ExitAttempt = 0;
                    goto Start;
                }
            }
        }

        foreach (string reward in new[] { "Yoshino's Citrine", "The Secret 4" })
        {
            if (item != reward && Bot.Inventory.Contains(reward))
                Core.ToBank(reward);
        }
    }

    public void DeathPitToken(string item = "Death Pit Token", int quant = 30, bool isTemp = false)
    {
        // Do not call this with registered quests, or it technically never exits.
        if (Core.CheckInventory(item, quant))
            return;

        RunDeathPitBrawl(item, quant, 1);
    }

    public void FaerieCourtREP(int rank = 10) // Seasonal
    {
        if (FactionRank("Faerie Court") >= rank)
            return;

        Core.JumpWait();
        Bot.Map.Join("rainbow");
        if (Bot.Map.Name != "rainbow")
        {
            Core.Logger("Can't level FaerieCourt, as it's seasonal");
            return;
        }

        Core.Logger($"Farming rank {rank}");
        ToggleBoost(BoostType.Reputation);
        Core.SavedState();

        Core.RegisterQuests(6775, 6779);
        while (!Bot.ShouldExit && FactionRank("Faerie Court") < rank)
        {
            if (FactionRank("Faerie Court") < 8)
            {
                Core.EquipClass(ClassType.Solo);
                Core.HuntMonster("rainbow", "Lucky Harms", "Four Leaf Clover", 3, log: false);
            }
            if (FactionRank("Faerie Court") >= 8)
            {
                Core.EquipClass(ClassType.Farm);
                Core.HuntMonster("faegrove", "Dark Sylphdrake", "Silver Sylph Feather", log: false);
            }
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void GlaceraREP(int rank = 10)
    {
        if (FactionRank("Glacera") >= rank)
            return;

        if (!Core.isCompletedBefore(5601))
        {
            Core.Logger("Farming Quests are not unlocked, Please run: \"Story/Glacera.cs\"");
            return;
        }

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        if (Core.FarmClass == "Generic")
            Core.Logger("FarmClass not set in CBO (options > corebot > tab 2),\n" +
            "so you'll be getting *very* low Rep Rates without a multi-target class.");

        Core.RegisterQuests(5597, 5598, 5599, 5600);
        while (!Bot.ShouldExit && FactionRank("Glacera") < rank)
            Core.KillMonster("icewindwar", "r5", "Left", "*", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void GoodREP(int rank = 10)
    {
        if (FactionRank("Good") >= rank)
            return;

        Core.ChangeAlignment(Alignment.Good);
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(369); //That Hero Who Chases Slimes 369
        while (!Bot.ShouldExit && FactionRank("Good") < 4)
            Core.KillMonster("swordhavenbridge", "Bridge", "Left", "*");
        Core.CancelRegisteredQuests();

        Core.RegisterQuests(Core.IsMember ? 371 : 372); //Rumble with Grumble 371, Tomb with a View 372
        while (!Bot.ShouldExit && FactionRank("Good") < rank)
        {
            if (!Core.IsMember)
                Core.KillMonster("castleundead", "Enter", "Spawn", "*");
            else
                Core.KillMonster("sewer", "End", "Left", "Grumble");
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);

    }

    public void HollowbornREP(int rank = 10)
    {
        if (FactionRank("Hollowborn") >= rank)
            return;

        Core.AddDrop("Hollow Soul");
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Get the Seeds 7553 && Flex it! 7555
        Core.RegisterQuests(7553, 7555);

        while (!Bot.ShouldExit && FactionRank("Hollowborn") < rank)
        {
            Core.KillMonster("shadowrealm", "r2", "Left", "Gargrowl", "Darkseed", 8, log: false);
            Core.KillMonster("shadowrealm", "r2", "Left", "Shadow Guardian", "Shadow Medallion", 5, log: false);
        }
        ToggleBoost(BoostType.Reputation, false);
        Core.CancelRegisteredQuests();
        Core.SavedState(false);
    }

    public void HorcREP(int rank = 10)
    {
        if (FactionRank("Horc") >= rank)
            return;


        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(1265);
        while (!Bot.ShouldExit && FactionRank("Horc") < rank)
        {
            Core.EnsureAccept(1265);
            Core.HuntMonster("bloodtuskwar", "Chaotic Lemurphant", "Chaorrupted Eye", 3, log: false);
            Core.HuntMonster("bloodtuskwar", "Chaotic Horcboar", "Chaorrupted Tentacle", 5, log: false);
            Core.HuntMonster("bloodtuskwar", "Chaotic Chinchilizard", "Chaorrupted Tusk", 5, log: false);
            Core.EnsureComplete(1265);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void LoremasterREP(int rank = 10)
    {
        if (FactionRank("Loremaster") >= rank)
            return;

        Experience(15);
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.EquipClass(ClassType.Farm);
        if (Core.IsMember)
        {
            if (FactionRank("Loremaster") < 3)
            {
                Core.Logger("Geting r3 Loremaster rep for the member quests");
                Core.RegisterQuests(7505);
                while (!Bot.ShouldExit && FactionRank("Loremaster") < 3)
                {
                    Core.HuntMonster("wardwarf", "Drow Assassin", "Poisoned Dagger", 4, log: false);
                    Core.HuntMonster("wardwarf", "D'wain Jonsen", "Scroll: Opportunity's Strike", log: false);
                    Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
                    Bot.Wait.ForActionCooldown(GameActions.AcceptQuest);
                    Bot.Wait.ForQuestAccept(7505);
                }
            }

            if (!Core.isCompletedBefore(3032))
            {
                Core.Logger("Unlocking farming quest.");

                Core.EnsureAccept(3029); //Rosetta Stones 3029
                Core.KillMonster("druids", "r2", "Left", "Void Bear", "Voidstone", 6);
                Core.EnsureComplete(3029);

                Core.EnsureAccept(3030); // Cull the Foot Soldiers 3030
                Core.KillMonster("druids", "r6", "Left", "Void Larva", "Void Larvae Death Cry", 4);
                Core.EnsureComplete(3030);

                Core.EnsureAccept(3031); // Bad Vibes 3031
                Core.KillMonster("druids", "r6", "Left", "Void Ghast", "Ghast's Death Cry", 4);
                Core.EnsureComplete(3031);

                Core.EnsureAccept(3032); // Quite the Problem 3032
                Core.KillMonster("druids", "r5", "Left", "Young Void Giant", log: false);
                Core.EnsureComplete(3032);

            }
            Core.Logger("Member perquisite quests finished.");

            Core.EquipClass(ClassType.Solo);
            Core.RegisterQuests(3032);
            while (!Bot.ShouldExit && FactionRank("Loremaster") < rank)
            {
                Core.KillMonster("druids", "r5", "Left", "Young Void Giant", log: false);
                Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
                Bot.Wait.ForActionCooldown(GameActions.AcceptQuest);
                Bot.Wait.ForQuestAccept(3032);
            }
        }
        else
        {
            Core.RegisterQuests(7505); //Studying the Rogue 7505
            while (!Bot.ShouldExit && FactionRank("Loremaster") < rank)
            {
                Core.HuntMonster("wardwarf", "Drow Assassin", "Poisoned Dagger", 4, log: false);
                Core.HuntMonster("wardwarf", "D'wain Jonsen", "Scroll: Opportunity's Strike", log: false);
                Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
                Bot.Wait.ForActionCooldown(GameActions.AcceptQuest);
                Bot.Wait.ForQuestAccept(7505);
            }
        }

        Bot.Quests.UnregisterQuests(3032, 7505);
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void LycanREP(int rank = 10)
    {
        if (FactionRank("Lycan") >= rank)
            return;


        if (!Core.isCompletedBefore(537))
        {
            Core.Logger("Can't do farming quest [Sanguine] (/lycan)", messageBox: true);
            return;
        }

        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(537); //Sanguine 537
        while (!Bot.ShouldExit && FactionRank("Lycan") < rank)
            Core.HuntMonster("lycan", "Sanguine", "Sanguine Mask", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void InfernalArmyREP(int rank = 10)
    {
        if (FactionRank("Infernal Army") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(5707); // Practice Time 5707
        while (!Bot.ShouldExit && FactionRank("Infernal Army") < rank)
            Core.KillMonster("dreadfire", "r10", "Left", "Living Brimstone", "Living Brimstone Defeated", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void MonsterHunterREP(int rank = 10)
    {
        if (FactionRank("Monster Hunter") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(5849, 5850); //Capture the Misshapen 5849, Defeat the Parasites 5850
        if (!Core.isCompletedBefore(5850))
        {
            Core.Logger("Unlocking farming quest.");
            Core.KillMonster("pilgrimage", "r5", "Left", "SpiderWing", "Spiderwing Captured", 4, log: false);
            Core.KillMonster("pilgrimage", "r5", "Left", "Urstrix", "Urstrix Captured", 4, log: false);
        }

        while (!Bot.ShouldExit && FactionRank("Monster Hunter") < rank)
        {
            Core.KillMonster("pilgrimage", "r5", "Left", "SpiderWing", "Spiderwing Captured", 4, log: false);
            Core.KillMonster("pilgrimage", "r5", "Left", "Urstrix", "Urstrix Captured", 4, log: false);
            Core.KillMonster("pilgrimage", "r5", "Left", "Ravenous Parasite", "Ravenous Parasites Slain", 7, log: false);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void MysteriousDungeonREP(int rank = 10)
    {
        if (FactionRank("Mysterious Dungeon") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        if (!Core.isCompletedBefore(5429))
        {
            Core.EnsureAccept(5428);
            Core.GetMapItem(4803, 1, "cursedshop");
            Core.EnsureComplete(5428);
        }

        Core.RegisterQuests(5429); //Lamps, Paintings and Chairs, oh my! 5429
        while (!Bot.ShouldExit && FactionRank("Mysterious Dungeon") < rank)
            Core.HuntMonster("cursedshop", "Antique Chair", "Antique Chair Defeated", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void MythsongREP(int rank = 10)
    {
        if (FactionRank("Mythsong") >= rank)
            return;

        if (!Bot.Quests.IsUnlocked(4829))
        {
            Core.Logger("Can't do farming quest (Do Lord of Chaos Kimberly)", messageBox: true);
            return;
        }

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(4829); //Sugar, Sugar 4829
        while (!Bot.ShouldExit && FactionRank("Mythsong") < rank)
            Core.HuntMonster("beehive", "Stinger", "Honey Gathered", 10, log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void NecroCryptREP(int rank = 10)
    {
        if (FactionRank("Necro Crypt") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(3048); //Help Professor Mueran 3048
        while (!Bot.ShouldExit && FactionRank("Necro Crypt") < rank)
            Core.HuntMonster("castleundead", "Skeletal Viking", "Old Bone", 25, log: false);
        Bot.Wait.ForQuestComplete(3048);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void NorthpointeREP(int rank = 10)
    {
        if (FactionRank("Northpointe") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        ToggleBoost(BoostType.Reputation);
        Core.SavedState();
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(4027); //Sage Advice 4027
        while (!Bot.ShouldExit && FactionRank("Northpointe") < rank)
            Core.HuntMonster("northpointe", "Grim Stalker", "Bunch of Sage", 10, log: false);
        Bot.Wait.ForQuestComplete(4027);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void PetTamerREP(int rank = 10)
    {
        if (FactionRank("Pet Tamer") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(5261);
        while (!Bot.ShouldExit && FactionRank("Pet Tamer") < rank)
            Core.KillMonster("greenguardwest", "West7", "Down", "Mogzard", "Mogzard Captured", log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void RavenlossREP(int rank = 10)
    {
        if (FactionRank("Ravenloss") >= rank)
            return;

        if (!Bot.Quests.IsAvailable(3445))
        {
            Core.Logger("Quest Locked Run: \"Story/RavenlossSaga.cs\"", messageBox: true);
            return;
        }
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(3445); //Slay the Spiderkin 3445
        while (!Bot.ShouldExit && FactionRank("Ravenloss") < rank)
            Core.HuntMonster("twilightedge", "ChaosWeaver Mage", "ChaosWeaver Slain", 10, log: false);
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void SandseaREP(int rank = 10)
    {
        if (FactionRank("Sandsea") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(916, 917, 919, 921, 922); //Dissertations Bupers Camel 916, Crafty Creepers: A Favorite of Mine 917, Parched Pets 919, Oasis Ornaments 921, The Power of Pomade 922
        while (!Bot.ShouldExit && FactionRank("Sandsea") < rank)
        {
            Core.EnsureAcceptmultiple(new[] { 916, 917, 919, 921, 922 });
            Core.HuntMonster("sandsea", "Bupers Camel", "Bupers Camel Document", 10, log: false);
            Core.HuntMonster("sandsea", "Bupers Camel", "Barrel of Desert Water", 10, log: false);
            Core.HuntMonster("sandsea", "Bupers Camel", "Flexible Camel Spit", 7, log: false);
            Core.HuntMonster("sandsea", "Bupers Camel", "Oasis Jewelry Piece", 4, log: false);
            Core.HuntMonster("sandsea", "Bupers Camel", "Camel Skull", 2, log: false);
            Core.HuntMonster("sandsea", "Cactus Creeper", "Sandsea Cotton", 8, log: false);
            Core.HuntMonster("sandsea", "Cactus Creeper", "Cactus Creeper Head", 8, log: false);
            Core.EnsureComplete(916, 917, 919, 921, 922);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
        // To ensure combat exit before buying master ranger if doing so
        Core.JumpWait();

    }

    public void SkyguardREP(int rank = 10)
    {
        if (FactionRank("Skyguard") >= rank)
            return;

        if (!Core.IsMember)
        {
            Core.Logger("Skyguard REP is Member-Only", messageBox: true);
            return;
        }

        MembershipDues(MemberShipsIDS.Skyguard, rank);
    }

    public void SomniaREP(int rank = 10)
    {
        if (FactionRank("Somnia") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(7665, 7666, 7669);
        while (!Bot.ShouldExit && FactionRank("Somnia") < rank)
        {
            Core.EnsureAcceptmultiple(new[] { 7665, 7666, 7669 });
            Core.HuntMonster("somnia", "Nightspore", "Dream Truffle", 8, log: false);
            Core.HuntMonster("somnia", "Orpheum Elemental", "Orphium Ore", 8, log: false);
            Core.HuntMonster("somnia", "Dream Larva", "Dreamsilk", 5, log: false);
            Core.EnsureComplete(7665, 7666, 7669);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void SpellCraftingREP(int rank = 10)
    {
        if (FactionRank("SpellCrafting") >= rank)
            return;

        Core.AddDrop("Mystic Quills", "Mystic Parchment");
        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        if (FactionRank("SpellCrafting") == 0)
        {
            Core.EnsureAccept(2260);
            Core.GetMapItem(1920, 1, "dragonrune");
            Core.HuntMonster("castleundead", "Skeletal Warrior", "Arcane Parchment", 13, log: false);
            Core.EnsureComplete(2260);
        }

        if (FactionRank("SpellCrafting") < 4)
        {
            Core.JoinSWF("mobius", "ChiralValley/town-Mobius-21Feb14.swf", "Slugfit", "Bottom");
            Core.HuntMonster("mobius", "Slugfit", "Mystic Quills", 10, false);
            Core.BuyItem("dragonrune", 549, "Ember Ink", 50);
            while (!Bot.ShouldExit && Core.CheckInventory("Ember Ink") && FactionRank("SpellCrafting") < 4)
                Core.ChainComplete(2299);
        }
        while (!Bot.ShouldExit && FactionRank("SpellCrafting") < rank)
        {
            Core.HuntMonster("underworld", "Skull Warrior", "Mystic Parchment", 10, false);
            Core.BuyItem("dragonrune", 549, "Hallow Ink", 50);
            while (!Bot.ShouldExit && Core.CheckInventory("Hallow Ink") && FactionRank("SpellCrafting") < rank)
                Core.ChainComplete(2322);
        }
        Core.SellItem("Ember Ink", all: true);
        Core.SellItem("Hallow Ink", all: true);

        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void SwordhavenREP(int rank = 10)
    {
        if (FactionRank("Swordhaven") >= rank)
            return;


        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(3065, 3066, 3067, 3070, 3085, 3086, 3087);
        while (!Bot.ShouldExit && FactionRank("Swordhaven") < rank)
        {
            Core.EnsureAcceptmultiple(new[] { 3065, 3066, 3067, 3070, 3085, 3086, 3087 });
            Core.HuntMonster("castle", "Castle Spider", "Eradicated Arachnid", 10, log: false);
            Core.HuntMonster("castle", "Castle Spider", "Castle Spider Silk", 8, log: false);
            Core.HuntMonster("castle", "Castle Spider", "Castle Spider Silk Yarn", 2, log: false);
            Core.HuntMonster("castle", "Castle Wraith", "Castle Wraith Defeated", 10, log: false);
            Core.HuntMonster("castle", "Castle Wraith", "Jarred Wraith", 5, log: false);
            Core.HuntMonster("castle", "Castle Wraith", "Castle Wraith Wool", 2, log: false);
            Core.HuntMonster("castle", "Gargoyle", "Stony Plating", 6, log: false);
            Core.HuntMonster("castle", "Gargoyle", "Gargoyle Gems", 2, log: false);
            Core.HuntMonster("castle", "Dungeon Fiend", "Dungeon Fiend Hair Bow", 5, log: false);
            Core.HuntMonster("castle", "Dungeon Fiend", "Dungeon Fiend Bow Tie", 5, log: false);
            Core.HuntMonster("castle", "Dungeon Fiend", "Dungeon Fiend Textiles", 2, log: false);
            Core.EnsureComplete(new[] { 3065, 3066, 3067, 3070, 3085, 3086, 3087 });
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void ThunderForgeREP(int rank = 10)
    {
        if (FactionRank("ThunderForge") >= rank)
            return;

        if (!Bot.Quests.IsAvailable(2733))
        {
            Core.Logger("Quest not avaible for farm, do ThunderForge saga till Deathpits [The Chaos Eye of Vestis]");
            return;
        }
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");
        if (!Core.IsMember)
        {
            Core.EquipClass(ClassType.Solo);
            Core.RegisterQuests(2733, 2734);
            while (!Bot.ShouldExit && FactionRank("ThunderForge") < rank)
                Core.HuntMonster("deathpits", "Wrathful Vestis", "Vestis's Chaos Eye", log: false);
        }
        else
        {
            Core.EquipClass(ClassType.Farm);
            Core.RegisterQuests(2734, 2735, 2736, 2737);
            while (!Bot.ShouldExit && FactionRank("ThunderForge") < rank)
                Core.HuntMonster("deathpits", "Rotting Darkblood", log: false);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void TreasureHunterREP(int rank = 10)
    {
        if (FactionRank("TreasureHunter") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(6593);
        while (!Bot.ShouldExit && FactionRank("TreasureHunter") < rank)
        {
            Core.HuntMonster("stalagbite", "Balboa", "Super Specific Rock", log: false);
            Bot.Wait.ForQuestComplete(6593);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void TrollREP(int rank = 10)
    {
        if (FactionRank("Troll") >= rank)
            return;


        Core.EquipClass(ClassType.Farm);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        // Core.RegisterQuests(1263);
        while (!Bot.ShouldExit && FactionRank("Troll") < rank)
        {
            Core.EnsureAccept(1263);
            Core.HuntMonster("bloodtuskwar", "Chaotic Lemurphant", "Chaorrupted Eye", 3, log: false);
            Core.HuntMonster("bloodtuskwar", "Chaotic Horcboar", "Chaorrupted Tentacle", 5, log: false);
            Core.HuntMonster("bloodtuskwar", "Chaotic Chinchilizard", "Chaorrupted Tusk", 5, log: false);
            Core.EnsureComplete(1263);
        }
        // Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void VampireREP(int rank = 10)
    {
        if (FactionRank("Vampire") >= rank)
            return;


        if (!Bot.Quests.IsUnlocked(522))
        {
            Core.Logger("Can't do farming quest [Twisted Paw] (/safiria)", messageBox: true);
            return;
        }
        Core.EquipClass(ClassType.Solo);
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(522);
        Core.RemoveDrop("Old Moon");
        while (!Bot.ShouldExit && FactionRank("Vampire") < rank)
        {
            Core.HuntMonster("safiria", "Twisted Paw", "Twisted Paw's Head", log: false);
            Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void YewMountainsREP(int rank = 10)
    {
        if (FactionRank("Yew Mountains") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        ToggleBoost(BoostType.Reputation);
        Core.Logger($"Farming rank {rank} for Yew Mountains");

        Core.RegisterQuests(10341, 10346);
        Core.AddDrop(
            Core.EnsureLoad(10342).Rewards.Select(r => r.Name)
            .Concat(Core.EnsureLoad(10346).Rewards.Select(r => r.Name))
            .ToArray()
        );
        bool didDaily = Bot.Quests.IsDailyComplete(10342);
        while (!Bot.ShouldExit && FactionRank("Yew Mountains") < rank)
        {
            if (!didDaily && Bot.Quests.IsAvailable(10342))
            {
                Core.EnsureAccept(10342);
                Core.KillMonster("thelimacity", "r6", "Left", "*", log: false);
                if (Bot.Quests.CanCompleteFullCheck(10342))
                {
                    Core.EnsureComplete(10342);
                    Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
                    didDaily = true;
                }
            }
            Core.KillMonster("thelimacity", "r6", "Left", "*", log: false);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void YokaiREP(int rank = 10)
    {
        if (FactionRank("Yokai") >= rank)
            return;

        Core.EquipClass(ClassType.Farm);
        ToggleBoost(BoostType.Reputation);
        Core.SavedState();
        Core.Logger($"Farming rank {rank}");

        Core.RegisterQuests(383);
        while (!Bot.ShouldExit && FactionRank("Yokai") < rank)
        {
            Core.HuntMonster("dragonkoiz", "Pockey Chew", "Piece of Pockey", 3, log: false);
            Bot.Wait.ForActionCooldown(GameActions.TryQuestComplete);
        }
        Core.CancelRegisteredQuests();
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
    }

    public void SwagTokenA(int quant = 100)
    {
        // Check if we already have the required amount of Token A or not
        if (Core.CheckInventory("Super-Fan Swag Token A", quant))
        {
            return;
        }

        Core.FarmingLogger("Swag Token A", quant);
        Core.AddDrop("Super-Fan Swag Token A", "Super-Fan Swag Token B", "Super-Fan Swag Token C");
        if (!Core.IsMember)
            Core.AddDrop("Super-Fan Swag Token D");
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(!Core.IsMember ? new[] { 1304, 1307 } : new[] { 1310, 1312, 1313, 1314 });

        #region Token farm and check for Token A only
        while (!Bot.ShouldExit && !Core.CheckInventory("Super-Fan Swag Token A", quant))
        {

            // Refresh token quantities
            int dQuantity = Bot.Inventory.GetQuantity("Super-Fan Swag Token D");
            int cQuantity = Bot.Inventory.GetQuantity("Super-Fan Swag Token C");
            int bQuantity = Bot.Inventory.GetQuantity("Super-Fan Swag Token B");
            int aQuantity = Bot.Inventory.GetQuantity("Super-Fan Swag Token A");

            if (Core.IsMember)
            {
                Core.KillMonster("collectorlab", "r2", "Left", "*", "Super-Fan Swag Token C", 200, isTemp: false);
                Bot.Wait.ForPickup("Super-Fan Swag Token C");
            }
            else
            {
                // Farm Token D from Terrarium
                Core.KillMonster("terrarium", "Enter", "Spawn", "*", "Super-Fan Swag Token D", 500, isTemp: false);
                Bot.Wait.ForPickup("Super-Fan Swag Token D");
            }

            HandleShopPurchases(
      Bot.Inventory.GetQuantity("Super-Fan Swag Token D"),
      Bot.Inventory.GetQuantity("Super-Fan Swag Token C"),
      Bot.Inventory.GetQuantity("Super-Fan Swag Token B"),
      Bot.Inventory.GetQuantity("Super-Fan Swag Token A"));

        }
        #endregion Token farm and check

        Core.CancelRegisteredQuests();
    }

    // Helper method to determine if we should buy a token
    private bool ShouldBuy(string tokenType, int currentQuantity, int targetQuantity, int maxQuantity, int divisor)
    {
        if (ShopCheck())
        {
            int quantityToBuy = currentQuantity / divisor;
            if (currentQuantity < targetQuantity && quantityToBuy + currentQuantity < maxQuantity)
            {
                return true;
            }
        }
        return false;
    }

    // Helper method to check if the shop is loaded and ready
    private bool ShopCheck()
    {
        Core.JumpWait();
        if (Bot.Map.Name != "collection")
        {
            Core.Join("Collection");
            Bot.Wait.ForMapLoad("Collection");
        }
        if (Bot.Player.Cell != "Begin")
        {
            Core.Jump("Begin");
            Bot.Wait.ForCellChange("Begin");
            Bot.Wait.ForCellChange("Enter");
        }

        // Load shop data
        int retry = 0;
        while (!Bot.ShouldExit && Bot.Shops.ID != 325)
        {
            Bot.Shops.Load(325);
            Bot.Wait.ForActionCooldown(GameActions.LoadShop);
            Bot.Wait.ForTrue(() => Bot.Shops.IsLoaded && Bot.Shops.ID == 325, 20);
            Core.Sleep(1000);
            if (Bot.Shops.ID == 325 || retry == 20)
                break;
            else retry++;
        }
        retry = 0;

        return Bot.Map.Name == "collection" && Bot.Shops.IsLoaded && Bot.Shops.Name == "Super Fan Token Shop";
    }

    // Shop handler for SwagTokens
    private void HandleShopPurchases(int dQuantity, int cQuantity, int bQuantity, int aQuantity)
    {

        // Join "Collection" map and wait for it to load
        Core.Join("Collection");
        Bot.Wait.ForMapLoad("Collection");
        Bot.Wait.ForCellChange("Begin");
        Core.Sleep();

        // Token D > Token C (purchase if needed)
        if (dQuantity / 10 > 1 && cQuantity < 500 && dQuantity / 10 + cQuantity < 500)
        {
            int buyC = dQuantity / 10;
            Core.BuyItem("collection", 325, "Super-Fan Swag Token C", buyC);
            Bot.Wait.ForActionCooldown(GameActions.BuyItem);
            Bot.Wait.ForItemBuy();
        }

        Core.Sleep();

        // Token C > Token B (buy from shop if needed)
        if (cQuantity / 10 > 1 && bQuantity < 200 && cQuantity / 10 + bQuantity < 200)
        {
            int buyB = cQuantity / 10;
            Core.BuyItem("collection", 325, "Super-Fan Swag Token B", buyB);
            Bot.Wait.ForActionCooldown(GameActions.BuyItem);
            Bot.Wait.ForItemBuy();
        }

        Core.Sleep();

        // Token B > Token A (buy from shop if needed)
        if (bQuantity / 20 > 1 && aQuantity < 100 && bQuantity / 20 + aQuantity < 100)
        {
            int buyA = bQuantity / 20;
            Core.BuyItem("collection", 325, "Super-Fan Swag Token A", buyA);
            Bot.Wait.ForActionCooldown(GameActions.BuyItem);
            Bot.Wait.ForItemBuy();
        }
        Core.Sleep();
    }

    public void MembershipDues(MemberShipsIDS faction, int rank = 10)
    {
        if (FactionRank(faction.ToString()) >= rank)
            return;

        Bot.Options.SkipCutscenes = false;
        Core.Logger($"Membership Dues - Rep: {faction} - Rank: {rank}");
        Core.SavedState();
        ToggleBoost(BoostType.Reputation);
        Core.BankingBlackList.AddRange(new[] { "Super-Fan Swag Token A", "Super-Fan Swag Token B", "Super-Fan Swag Token C", "Super-Fan Swag Token D" });
        while (FactionRank(faction.ToString()) < rank)
        {
            SwagTokenA((RemainingFactionXp(faction.ToString()) / 5000) + 1);
            Core.EnsureCompleteMulti((int)faction);
        }
        ToggleBoost(BoostType.Reputation, false);
        Core.SavedState(false);
        Bot.Options.SkipCutscenes = true;
    }

    public int FactionRank(string faction) => Bot.Reputation.GetRank(faction);
    public int FactionRep(string faction) =>
    Bot.Reputation.FactionList
        .FirstOrDefault(f => string.Equals(f.Name, faction, StringComparison.OrdinalIgnoreCase))
        ?.Rep ?? 0;
    public int RemainingFactionXp(string faction)
    {
        var factionData = Bot.Reputation.FactionList
            .FirstOrDefault(f => string.Equals(f.Name, faction, StringComparison.OrdinalIgnoreCase));

        return factionData?.RemainingRep ?? 302500; // Return 302500 (Max rep) if factionData is null
    }

    #endregion Reputation

    public void UndeadGiantUnlock()
    {
        if (!Core.isCompletedBefore(178))
        {
            Core.Logger("Unlocking farm quest.");
            Core.EnsureAccept(183);
            Core.KillMonster("portalundead", "Enter", "Left", "Skeletal Fire Mage", "Defeated Fire Mage", 4, log: false);
            Core.EnsureComplete(183);

            Core.EnsureAccept(176);
            Core.HuntMonster("swordhavenundead", "Skeletal Soldier", "Slain Skeletal Soldier", 5, log: false);
            Core.EnsureComplete(176);

            Core.EnsureAccept(177);
            Core.HuntMonster("swordhavenundead", "Skeletal Ice Mage", "Frozen Bonehead", 6, log: false);
            Core.EnsureComplete(177);
        }
    }

    public void GetBoost(int itemID, string boostName, int BoostQuant, int quest, bool doOnce = false)
    {
        //Ensure Rank 2 > fishing rep
        FishingREP(2, false, false, false);

        ItemBase? boostItem = Core.EnsureLoad(quest)?.Rewards.Find(x => x.Name == boostName);
        if (boostItem != null && Core.CheckInventory(boostItem?.Name, BoostQuant) && !doOnce) return;

        Core.FarmingLogger(boostName, BoostQuant); // Use boostName directly
        Core.AddDrop("Fishing Dynamite", boostItem?.Name ?? "DefaultItemName");
        Core.EquipClass(ClassType.Farm);

        string itemName = boostItem?.Name ?? Core.EnsureLoad(quest)?.Rewards.Find(x => x.ID == itemID)?.Name ?? "DefaultItemName";
        while (!Bot.ShouldExit && (boostItem == null || (boostItem != null && !Core.CheckInventory(boostItem?.Name, BoostQuant)) || doOnce))
        {
            // Unlock the quest if not completed before (only for quest 1615)
            if (!Core.isCompletedBefore(1615))
            {
                Core.EnsureAccept(1614);
                GetFish(10850, 30, 1614);
                Core.HuntMonster("Greenguardwest", "Slime", "Slime Sauce", log: false);
                Core.EnsureComplete(1614);
            }

            Core.EnsureAccept(quest);

            GetFish(itemID, quest == 1614 ? 30 : 5, quest);

            if (quest == 1614)
                Core.KillMonster("greenguardwest", "West4", "Right", "Slime", "Slime Sauce");
            else if (quest == 1615)
                Core.HuntMonster("Greenguardwest", "Frogzard", "Greenguard Seal", log: false);
            Bot.Wait.ForPickup(quest == 1614 ? "Slime Sauce" : "Greenguard Seal");

            Core.EnsureComplete(quest);
        }

        if (!doOnce) Core.TrashCan(new[] { "Fishing Bait", "Fishing Dynamite" });
        Core.CancelRegisteredQuests();
    }


}

public enum BoostIDs
{
    DailyXP60 = 19189,
    XP20 = 22448,
    XP60 = 27552,
    DoomClass60 = 19761,
    Class20 = 22447,
    Class60 = 27555,
    DoomREP60 = 19762,
    REP20 = 22449,
    REP60 = 27553,
    DoomGold60 = 19763,
    Gold20 = 22450,
    Gold60 = 27554
}

public enum AlchemyRunes
{
    Dragon,
    Jera,
    Uruz,
    Fehu,
    Gebo
}

public enum MemberShipsIDS
{
    Dwarfhold = 1317,
    Good = 1318,
    Evil = 1319,
    Yokai = 1320,
    Vampire = 1321,
    Lycan = 1322,
    Mythsong = 1323,
    Arcangrove = 1324,
    Sandsea = 1325,
    Skyguard = 1326,
    DoomWood = 1327,
    Troll = 1328,
    Horc = 1329,
    Etherstorm = 4340,
    ChronoSpan = 4341,
    Thunderforge = 4342,
    Swordhaven = 4343,
    Chaos = 4344,
    Northpointe = 4345,
    Embersea = 4346,
    Ravenloss = 4347
}
