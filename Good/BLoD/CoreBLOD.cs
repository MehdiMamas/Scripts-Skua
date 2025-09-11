/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/BattleUnder.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Shops;
using Skua.Core.Models.Items;
using Skua.Core.Utils;

public class CoreBLOD
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }
    private static CoreFarms _Farm;
    private static CoreDailies Daily { get => _Daily ??= new CoreDailies(); set => _Daily = value; }
    private static CoreDailies _Daily;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }
    private static CoreStory _Story;
    private static BattleUnder BattleUnder { get => _BattleUnder ??= new BattleUnder(); set => _BattleUnder = value; }
    private static BattleUnder _BattleUnder;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.RunCore();
    }

    public string[] BLoDItems =
    {
        "Blinding Light of Destiny",
        "Get Your Blinding Light of Destiny",
        // Coppers
        "Copper",
        "Celestial Copper",
        "Celestial Copper of Destiny",
        // Maces
        "Mace of Destiny",
        "Bright Mace of Destiny",
        "Blinding Mace of Destiny",
        // Silvers
        "Silver",
        "Sanctified Silver",
        "Sanctified Silver of Destiny",
        // Bows
        "Bow of Destiny",
        "Bright Bow of Destiny",
        "Blinding Bow of Destiny",
        // Bariums
        "Barium",
        "Blessed Barium",
        "Blessed Barium of Destiny",
        // Blades
        "Blade of Destiny",
        "Bright Blade of Destiny",
        "Blinding Blade of Destiny",
        // Weapon Kits
        "Basic Weapon Kit",
        "Advanced Weapon Kit",
        "Ultimate Weapon Kit",
        // Merge misc.
        "Bone Dust",
        "Undead Essence",
        "Undead Energy",
        "Blinding Light Fragments",
        "Spirit Orb",
        "Loyal Spirit Orb",
        "Bright Aura",
        "Brilliant Aura",
        "Blinding Aura",
    };

    public void BlindingLightOfDestiny(BLODMethod method = BLODMethod.Optimized)
    {
        if (Core.CheckInventory("Blinding Light of Destiny"))
            return;

        Core.AddDrop(40187);
        if (!Core.CheckInventory(40187)) // Get your Blinding Light of Destiny
        {
            if (Core.isCompletedBefore(7673))
                Core.ChainComplete(7673);
            else
            {
                Bot.Drops.Add(BLoDItems);

                UnlockMineCrafting();
                switch ((int)method)
                {
                    case 0: // Fewest Dailies
                        GetBlindingWeapon(WeaponOfDestiny.Blade);
                        break;
                    case 1: // Optimized
                        GetBlindingWeapon(WeaponOfDestiny.Daggers);
                        GetBlindingWeapon(WeaponOfDestiny.Mace);
                        break;
                    case 2: // Fewest Hours
                        GetBlindingWeapon(WeaponOfDestiny.Mace);
                        GetBlindingWeapon(WeaponOfDestiny.Bow);
                        GetBlindingWeapon(WeaponOfDestiny.Blade);
                        break;
                }

                BrilliantAura(75);
                BrightAura(125);
                LoyalSpiritOrb(250);
                SpiritOrb(500);
                BlindingAura(1);

                UltimateWK();

                Core.ChainComplete(2180);
            }
        }
        Core.BuyItem(Bot.Map.Name, 1415, "Blinding Light of Destiny");
        Core.ToBank(40187);
    }

    public void UnlockMineCrafting()
    {
        if (Core.isCompletedBefore(2084))
            return;

        Story.PreLoad(this);

        // 2066 - Reforging the Blinding Light
        Story.BuyQuest(2066, "doomwood", 276, "Blinding Light of Destiny Handle");

        // 2067 - Secret Order of Undead Slayers
        Story.BuyQuest(2067, "doomwood", 276, "Bonegrinder Medal");

        // 2082 - Essential Essences
        if (!Story.QuestProgression(2082))
        {
            Core.EnsureAccept(2082);
            Core.HuntMonster("battleunderb", "Skeleton Warrior", "Undead Essence", 25, isTemp: false);
            Core.EnsureComplete(2082);
        }

        // 2083 - Bust some Dust
        if (!Story.QuestProgression(2083))
        {
            Core.EnsureAccept(2083);
            Core.HuntMonster("battleunderb", "Skeleton Warrior", "Bone Dust", 40, isTemp: false);
            Core.EnsureComplete(2083);
        }

        // 2084 - A Loyal Follower
        if (!Story.QuestProgression(2084))
        {
            Core.Logger("Doing Quest: [2084] \"A Loyal Follower\"");
            Core.EnsureAccept(2084);
            SpiritOrb(100);
            Core.HuntMonster("timevoid", "Ephemerite", "Celestial Compass");
            Core.EnsureComplete(2084);
        }
    }

    #region Materials

    public void SpiritOrb(int quant = 65000)
    {
        if (Core.CheckInventory("Spirit Orb", quant))
            return;

        FarmFindingFrag(WeaponOfDestiny.Blade, "Spirit Orb", quant >= 65000 ? 65000 : quant);
        FarmFindingFrag(WeaponOfDestiny.Broadsword, "Spirit Orb", quant >= 65000 ? 65000 : quant);

        // Default
        SoulSearching("Spirit Orb", quant >= 65000 ? 65000 : quant);
    }

    public void LoyalSpiritOrb(int quant)
    {
        if (Core.CheckInventory("Loyal Spirit Orb", quant))
            return;

        FarmFindingFrag(WeaponOfDestiny.Blade, "Loyal Spirit Orb", quant);
        FarmFindingFrag(WeaponOfDestiny.Daggers, "Loyal Spirit Orb", quant);
        FarmFindingFrag(WeaponOfDestiny.Scythe, "Loyal Spirit Orb", quant);
        FarmUltimateWK("Loyal Spirit Orb", quant);

        // Default
        while (!Bot.ShouldExit && !Core.CheckInventory("Loyal Spirit Orb", quant))
        {
            Core.FarmingLogger("Loyal Spirit Orb", quant);
            SpiritOrb(100 * quant);
            LightMerge("Loyal Spirit Orb", quant);
        }
    }

    public void BrightAura(int quant)
    {
        if (Core.CheckInventory("Bright Aura", quant))
            return;

        FarmFindingFrag(WeaponOfDestiny.Bow, "Bright Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Broadsword, "Bright Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Scythe, "Bright Aura", quant);
        FarmUltimateWK("Bright Aura", quant);

        // Default
        while (!Bot.ShouldExit && !Core.CheckInventory("Bright Aura", quant))
        {
            Core.FarmingLogger("Bright Aura", quant);
            LoyalSpiritOrb(50 * quant);

            LightMerge("Bright Aura", quant);
        }
    }

    public void BrilliantAura(int quant)
    {
        if (Core.CheckInventory("Brilliant Aura", quant))
            return;

        FarmFindingFrag(WeaponOfDestiny.Mace, "Brilliant Aura", quant);

        // Default
        while (!Bot.ShouldExit && !Core.CheckInventory("Brilliant Aura", quant))
        {
            Core.FarmingLogger("Brilliant Aura", quant);
            BrightAura(25 * quant);
            LightMerge("Brilliant Aura", quant);
        }
    }

    public void BlindingAura(int quant)
    {
        if (Core.CheckInventory("Blinding Aura", quant))
            return;

        FarmFindingFrag(WeaponOfDestiny.Scythe, "Blinding Aura", quant);

        // Default (any of these)
        FarmFindingFrag(WeaponOfDestiny.Blade, "Blinding Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Broadsword, "Blinding Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Bow, "Blinding Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Mace, "Blinding Aura", quant);
        FarmFindingFrag(WeaponOfDestiny.Daggers, "Blinding Aura", quant);
    }

    public void SoulSearching(string item = "Spirit Orb", int quant = 1, bool farmSpiritOrbs = true)
    {
        if (Core.CheckInventory(item, quant))
            return;

        if (!Bot.Quests.IsUnlocked(939))
            BattleUnder.BattleUnderC();

        Core.EquipClass(ClassType.Solo);

        Core.AddDrop(farmSpiritOrbs
            ? new[] { "Bone Dust", "Undead Energy", "Cavern Celestite", "Undead Essence", "Spirit Orb" }
            : new[] { "Cavern Celestite", "Undead Essence", item });

        Core.RegisterQuests(farmSpiritOrbs ? new[] { 2082, 2083, 939 } : new[] { 939 });

        Core.FarmingLogger(item, quant);

        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.KillMonster("battleunderc", "r5", "Left", "Crystalized Jellyfish", "Jellyfish Soul", log: false);
            Core.KillMonster("battleundera", "r7", "Left", "Bone Terror", "Bone Terror Soul", log: false);
            Core.KillMonster("battleunderb", "r3", "Right", "Undead Champion", "Undead Champion Soul", log: false);
            Bot.Wait.ForPickup(item);
        }

        Core.CancelRegisteredQuests();


        /* 
        using register quest + accept and complete seems to break
        things.. not sure how to solve this besides just picking
        
             Core.EnsureAccept(939);
             Core.EnsureComplete(939);
        */
    }

    //Unused, here for archiving purposes I guess... ~Exe
    public void BoneSomeDust(int quant = 10500)
    {
        if (Core.CheckInventory("Spirit Orb", quant))
            return;

        Core.AddDrop("Bone Dust", "Undead Essence", "Undead Energy", "Spirit Orb");
        Core.EquipClass(ClassType.Farm);
        Core.FarmingLogger("Spirit Orb", quant);

        Core.RegisterQuests(2082, 2083);
        while (!Bot.ShouldExit && !Core.CheckInventory("Spirit Orb", quant))
            Core.KillMonster("battleunderb", "Enter", "Spawn", "Skeleton Warrior", log: false);
        Core.CancelRegisteredQuests();
    }

    public void FindingFragments(WeaponOfDestiny weapon, string item, int quant = 1)
    {
        if (Core.CheckInventory(item, quant))
            return;

        GetBlindingWeapon(weapon);

        int quest = (weapon) switch
        {
            WeaponOfDestiny.Bow => 2174,
            WeaponOfDestiny.Daggers => 2175,
            WeaponOfDestiny.Mace => 2176,
            WeaponOfDestiny.Scythe => 2177,
            WeaponOfDestiny.Broadsword => 2178,
            WeaponOfDestiny.Blade => 2179,
            _ => 0,
        };

        Core.AddDrop(Core.QuestRewards(quest).Append("Blinding Light Fragments").ToArray());
        Core.EquipClass(ClassType.Farm);
        Core.FarmingLogger(item, quant);

        Core.RegisterQuests(quest);
        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
            Core.KillMonster("battleunderb", "Enter", "Spawn", "Skeleton Warrior", item, quant, log: false, isTemp: false);
        Core.CancelRegisteredQuests();
    }

    private void FarmFindingFrag(WeaponOfDestiny weapon, string item, int quant)
    {
        if (!Core.CheckInventory(item, quant) && Core.isCompletedBefore(2163) &&
            (Core.CheckInventory($"Blinding {weapon} of Destiny") || Core.CheckInventory(40187))) // Basically means you can buy it from the final shop
            FindingFragments(weapon, item, quant);
    }

    private void FarmUltimateWK(string item, int quant)
    {
        if (!Core.CheckInventory(item, quant) && Bot.Quests.IsUnlocked(2163))
            UltimateWK(item, quant);
    }

    #endregion

    #region Weapon Kits

    public void BasicWK(int quant = 1)
    {
        if (Core.CheckInventory("Basic Weapon Kit", quant))
            return;

        Core.EquipClass(ClassType.Farm);
        Core.FarmingLogger("Basic Wepon Kit", quant);
        Core.AddDrop("Basic Weapon Kit");

        while (!Bot.ShouldExit && !Core.CheckInventory("Basic Weapon Kit", quant))
        {
            Core.EnsureAccept(2136);
            Core.KillMonster("forest", "Forest3", "Left", "*", "Zardman's StoneHammer", 1, false);
            Core.KillMonster("noobshire", "North", "Left", "Horc Noob", "Noob Blade Oil");
            Core.KillMonster("farm", "Crop1", "Right", "Scarecrow", "Burlap Cloth", 4);

            Bot.Quests.UpdateQuest(4614);
            Core.HuntMonster("pyramid", "Mummy", "Triple Ply Mummy Wrap", 7);
            Core.HuntMonster("pyramid", "Golden Scarab", "Golden Lacquer Finish");
            Core.HuntMonster("lair", "Bronze Draconian", "Bronze Brush");
            Core.HuntMonster("bloodtusk", "Rock", "Rocky Stone Sharpener");
            Core.EnsureComplete(2136);

            Bot.Wait.ForPickup("Basic Weapon Kit");
        }
    }

    public void AdvancedWK(int quant = 1)
    {
        if (Core.CheckInventory("Advanced Weapon Kit", quant))
            return;

        Core.FarmingLogger("Advanced Weapon Kit", quant);
        Core.AddDrop("Advanced Weapon Kit");

        while (!Bot.ShouldExit && !Core.CheckInventory("Advanced Weapon Kit", quant))
        {
            Core.EnsureAccept(2162);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("hachiko", "Dai Tengu", "Superior Blade Oil");
            Core.HuntMonster("airstorm", "Lightning Ball", "Shining Lacquer Finish");
            Core.HuntMonster("faerie", "Cyclops Warlord", "Brass Awl");
            Core.HuntMonster("darkoviaforest", "Lich of the Stone", "Slate Stone Sharpener");

            Core.EquipClass(ClassType.Farm);
            Core.KillMonster("safiria", "c3", "Left", "Chaos Lycan", "WolfClaw Hammer", 1, false);
            Core.KillMonster("lycan", "r4", "Left", "Chaos Vampire Knight", "Silver Brush");
            Core.KillMonster("sandport", "r3", "Right", "Tomb Robber", "Leather Case");
            Core.KillMonster("pines", "Path1", "Left", "LeatherWing", "Leatherwing Hide", 10);
            Core.EnsureComplete(2162);

            Bot.Wait.ForPickup("Advanced Weapon Kit");
        }
    }

    public void UltimateWK(string item = "Ultimate Weapon Kit", int quant = 1)
    {
        if (Core.CheckInventory(item, quant))
            return;

        Core.AddDrop("Ultimate Weapon Kit", "Blinding Light Fragments", "Bright Aura", "Spirit Orb", "Loyal Spirit Orb");
        Core.FarmingLogger(item, quant);
        Bot.Quests.UpdateQuest(999);
        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.EnsureAccept(2163);
            Core.EquipClass(ClassType.Farm);
            Core.KillMonster("dragonplane", "r2", "Right", "Earth Elemental", "Great Ornate Warhammer", 1, false, false);

            Core.EquipClass(ClassType.Solo);
            Core.KillMonster("greendragon", "Boss", "Left", "Greenguard Dragon", "Greenguard Dragon Hide", 3, log: false);
            Core.KillMonster("sandcastle", "r7", "Left", "Chaos Sphinx", "Gold Brush", log: false);
            Core.KillMonster("crashsite", "Boss", "Left", "ProtoSartorium", "Non-abrasive Power Powder", log: false);
            Core.KillKitsune("No. 1337 Blade Oil", log: false);
            Core.KillMonster("citadel", "m14", "Left", "Grand Inquisitor", "Blinding Lacquer Finish", log: false);
            Core.HuntMonster("djinn", "Harpy", "Suede Travel Case", log: false);
            Core.KillMonster("roc", "Enter", "Spawn", "Rock Roc", "Sharp Stone Sharpener", log: false);
            Core.EnsureComplete(2163);

            Bot.Wait.ForPickup(item);
        }
    }

    #endregion

    #region Weapons

    public void GetBlindingWeapon(WeaponOfDestiny weapon)
    {
        string weaponName = $"Blinding {weapon} of Destiny";
        if (Core.CheckInventory(weaponName))
            return;

        // Bypass any farms if you already farmed BLOD in the past
        if (Core.CheckInventory(40187)) // Get Your Blinding Light of Destiny
        {
            Core.BuyItem(Bot.Map.Name, 1415, weaponName);
            Core.ToBank(40187);
            return;
        }

        GetBrightWeapon(weapon);
        UltimateWK();
        LightMerge(weaponName);
    }

    public void GetBrightWeapon(WeaponOfDestiny weapon)
    {
        string weaponName = $"Bright {weapon} of Destiny";
        if (Core.CheckInventory(weaponName))
            return;

        GetBaseWeapon(weapon);

        List<ItemBase> weaponReqs = (LightMergeShopItems ??= Core.GetShopItems("necropolis", 422)).First(item => item.Name == weaponName).Requirements;

        GetMergeRequirements(weaponReqs, weaponReqs.First(item => item.Name == weapon + " of Destiny").ID);
        LightMerge(weaponName);
    }

    public void GetBaseWeapon(WeaponOfDestiny weapon)
    {
        string weaponName = weapon + " of Destiny";
        if (Core.CheckInventory(weaponName))
            return;

        List<ItemBase> weaponReqs = (LightMergeShopItems ??= Core.GetShopItems("necropolis", 422)).First(item => item.Name == weaponName).Requirements;
        ItemBase metal = weaponReqs.First(req => req.Name.EndsWith("of Destiny"));
        UpgradeMetal((MineCraftingMetalsEnum)Enum.Parse(typeof(MineCraftingMetalsEnum), metal.Name.Split(' ')[1]));

        GetMergeRequirements(weaponReqs, metal.ID);
        LightMerge(weaponName);
    }

    // Dynamic way of getting all the requierments via the shop info, which will work for different quants or combinations
    private void GetMergeRequirements(List<ItemBase> requirements, params int[] exceptions)
    {
        foreach (ItemBase req in requirements.Where(r => !exceptions.Contains(r.ID)))
        {
            switch (req.ID)
            {
                case 12503: // Basic Weapon Kit
                    BasicWK(req.Quantity);
                    break;
                case 12544: // Advanced Weapon Kit
                    AdvancedWK(req.Quantity);
                    break;
                case 12184: // Spirit Orb
                    SpiritOrb(req.Quantity);
                    break;
                case 12311: // Loyal Spirit Orb
                    LoyalSpiritOrb(req.Quantity);
                    break;
                case 6537: // Brilliant Aura (why is the ID so far away from the others)
                    BrilliantAura(req.Quantity);
                    break;
                case 6535: // Bright Aura
                    BrightAura(req.Quantity);
                    break;
                case 11285: // Undead Energy
                    Farm.BattleUnderB("Undead Energy", req.Quantity);
                    break;
            }
        }
    }

    public void UpgradeMetal(MineCraftingMetalsEnum metal)
    {
        string fullMetalName = string.Empty;
        int upgradeMetalQuest = 0;
        int forgeKeyQuest = 0;
        switch (metal)
        {
            case MineCraftingMetalsEnum.Aluminum:
                fullMetalName = "Almighty Aluminum of Destiny";
                upgradeMetalQuest = 2103;
                forgeKeyQuest = 2129;
                break;
            case MineCraftingMetalsEnum.Barium:
                fullMetalName = "Blessed Barium of Destiny";
                upgradeMetalQuest = 2104;
                forgeKeyQuest = 2130;
                break;
            case MineCraftingMetalsEnum.Gold:
                fullMetalName = "Glorious Gold of Destiny";
                upgradeMetalQuest = 2105;
                forgeKeyQuest = 2131;
                break;
            case MineCraftingMetalsEnum.Iron:
                fullMetalName = "Immortal Iron of Destiny";
                upgradeMetalQuest = 2106;
                forgeKeyQuest = 2132;
                break;
            case MineCraftingMetalsEnum.Copper:
                fullMetalName = "Celestial Copper of Destiny";
                upgradeMetalQuest = 2107;
                forgeKeyQuest = 2133;
                break;
            case MineCraftingMetalsEnum.Silver:
                fullMetalName = "Sanctified Silver of Destiny";
                upgradeMetalQuest = 2108;
                forgeKeyQuest = 2134;
                break;
            case MineCraftingMetalsEnum.Platinum:
                fullMetalName = "Pious Platinum of Destiny";
                upgradeMetalQuest = 2109;
                forgeKeyQuest = 2135;
                break;
        }

        // Getting the name of the metal used to upgrade
        string upgradeMetalName = fullMetalName.Split(' ')[..2].Join(' ');
        Core.FarmingLogger(fullMetalName, 1);

        // Getting the partially upgraded metal
        if (!Core.CheckInventory(upgradeMetalName))
        {
            Core.AddDrop(upgradeMetalName);
            Core.FarmingLogger(upgradeMetalName, 1);
            Core.EnsureAccept(upgradeMetalQuest);

            if (!Core.CheckInventory((int)metal))
                Daily.MineCrafting(new[] { metal.ToString() });
            if (!Core.CheckInventory((int)metal))
                Core.Logger($"Can't complete {fullMetalName.Split(' ')[..2].Join(' ')} Enchantment (missing {metal}).\n" +
                            "This requires a daily, please run the bot again after the daily reset has occurred.", messageBox: true, stopBot: true);

            Farm.BattleUnderB("Undead Energy", 25);
            SpiritOrb(5);
            Core.HuntMonster("arcangrove", "Seed Spitter", "Paladaffodil", 25);

            Core.EnsureComplete(upgradeMetalQuest);
            Bot.Wait.ForPickup(upgradeMetalName);
        }

        // Getting the fully upgraded metal
        BrightAura(2);
        LoyalSpiritOrb(5);
        Core.BuyItem("dwarfhold", 434, fullMetalName);

        // Unlocking "Basic Weapon Kit Construction" [Quest ID 2136]
        if (!Core.isCompletedBefore(forgeKeyQuest))
        {
            Core.AddDrop(fullMetalName);
            Core.EnsureAccept(forgeKeyQuest);
            Core.HuntMonster("dwarfhold", "Albino Bat", "Forge Key", isTemp: false);
            Core.EnsureComplete(forgeKeyQuest);
            Bot.Wait.ForPickup(fullMetalName);
        }
    }

    #endregion

    private List<ShopItem>? LightMergeShopItems = null;

    private void LightMerge(string item, int quant = 1)
        => Core.BuyItem("necropolis", 422, item, quant);
}

public enum WeaponOfDestiny
{
    Daggers,
    Bow,
    Mace,
    Scythe,
    Broadsword,
    Blade,
}

public enum BLODMethod
{
    Fewest_Dailies,
    Optimized,
    Fewest_Hours,
}
