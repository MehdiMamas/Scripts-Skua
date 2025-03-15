/*
name: null
description: null
tags: null
*/
//cs_include Scripts/Chaos/ChaosAvengerPreReqs.cs
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Chaos/AscendedDrakathGear.cs
//cs_include Scripts/Chaos/EternalDrakathSet.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
//cs_include Scripts/Story/StarSinc.cs
//cs_include Scripts/Story/TitanAttack.cs
//cs_include Scripts/Story/TowerOfDoom.cs
//cs_include Scripts/Other/MergeShops/TitanStrikeGearMerge.cs
//cs_include Scripts/Other/Badges/ChaosPuppetMaster.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;
using System.Runtime.Serialization;
using Skua.Core.Models.Items;
using Skua.Core.Models.Quests;

public class CoreHollowbornChaosEnvoy
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private CoreHollowborn HB = new();
    private CoreQOM QOM = new();
    private ChaosAvengerClass CAV = new();
    private EternalDrakath ED = new();
    private AscendedDrakathGear ADG = new();
    private TitanStrikeGearMerge TGM = new();
    private ChaosPuppetMaster CPM = new();
    public CoreStory Story = new();

    public string OptionsStorage = "HollowbornChaosEnvoy";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
            new Option<StirringDiscordRewards>("Stirring Discord", "Stirring Discord Reward", "Reward Selection for Stirring Discord", StirringDiscordRewards.None),
            new Option<InTheBeastsShadowRewards>("In The Beasts Shadow", "In The Beasts Shadow Reward", "Reward Selection for Stirring Discord", InTheBeastsShadowRewards.None),
            new Option<UniqueQuarryRewards>("Unique Quarry", "Unique Quarry Reward", "Reward Selection for Stirring Discord", UniqueQuarryRewards.None),
            new Option<WaveringIllusionsRewards>("Wavering Illusions", "Wavering Illusions Reward", "Reward Selection for Stirring Discord", WaveringIllusionsRewards.None),
            new Option<ShadowsOfDisdainRewards>("Shadows Of Disdain", "Shadows Of Disdain Reward", "Reward Selection for Stirring Discord", ShadowsOfDisdainRewards.None),
            new Option<PersistingMayhemRewards>("Persisting Mayhem", "Persisting Mayhem Reward", "Reward Selection for Stirring Discord", PersistingMayhemRewards.None),
            new Option<bool>("getAll", "Get all items", "Some quests need to be done multiple times in order to get everything, if true the bot will continue until it has everything from that quest before moving on. Recommended setting: True", true),
            new Option<bool>("BankAfter", "Bank Rewards", "bank Rewards after", true),
            CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.RunCore();
    }

    public void GetAll()
    {
        bool getAllDrops = Bot.Config!.Get<bool>("getAll");
        bool BankAfter = Bot.Config!.Get<bool>("BankAfter");
        bool optionsLogged = false;

        var questDictionary = new Dictionary<string, (int Order, Action Action)>
        {
            {"Stirring Discord", (8998, () => StirringDiscord(getAllDrops ? StirringDiscordRewards.All : Bot.Config!.Get<StirringDiscordRewards>("Stirring Discord")))},
            {"In The Beasts Shadow", (8999, () => InTheBeastsShadow(getAllDrops ? InTheBeastsShadowRewards.All : Bot.Config!.Get<InTheBeastsShadowRewards>("In The Beasts Shadow")))},
            {"Unique Quarry", (9000, () => UniqueQuarry(getAllDrops ? UniqueQuarryRewards.All : Bot.Config!.Get<UniqueQuarryRewards>("Unique Quarry")))},
            {"Wavering Illusions", (9001, () => WaveringIllusions(getAllDrops ? WaveringIllusionsRewards.All : Bot.Config!.Get<WaveringIllusionsRewards>("Wavering Illusions")))},
            {"Shadows Of Disdain", (9002, () => ShadowsOfDisdain(getAllDrops ? ShadowsOfDisdainRewards.All : Bot.Config!.Get<ShadowsOfDisdainRewards>("Shadows Of Disdain")))},
            {"Persisting Mayhem", (9003, () => PersistingMayhem(getAllDrops ? PersistingMayhemRewards.All : Bot.Config!.Get<PersistingMayhemRewards>("Persisting Mayhem")))}
        };


        string[] questOrder = { "Stirring Discord", "In The Beasts Shadow", "Unique Quarry", "Wavering Illusions", "Shadows Of Disdain", "Persisting Mayhem" };

        foreach (var quest in questOrder)
        {
            string questConfig = Bot.Config?.Get<string>(quest) ?? string.Empty;
            if (!string.IsNullOrEmpty(questConfig))
            {
                if (!optionsLogged)
                {
                    Core.Logger($"Options Selected:\n{string.Join("\n", questOrder.Select(q => $"\t{q.Replace("_", " ")}: [{Bot.Config?.Get<string>(q)?.Replace("_", " ") ?? string.Empty}]"))}");
                    optionsLogged = true;
                }

                var (order, action) = questDictionary[quest];
                action();

                if (BankAfter)
                {
                    Core.ToBank(Core.QuestRewards(order));
                }
            }
            Core.CancelRegisteredQuests();
        }
    }



    public void StirringDiscord(StirringDiscordRewards rewardSelection = StirringDiscordRewards.None, bool completeOnce = false)
    {
        string[] rewards = Core.QuestRewards(8998);
        StirringDiscordRewards discordReward = Bot.Config!.Get<StirringDiscordRewards>("Stirring Discord");

        bool shouldReturnEarly =
            (discordReward == StirringDiscordRewards.None && !completeOnce) || // reward = none, completeOnce is false
            (discordReward == StirringDiscordRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(8998)) ||
            (discordReward != StirringDiscordRewards.None && Core.CheckInventory((int)discordReward, toInv: false) && Story.QuestProgression(8998));

        if (shouldReturnEarly)
        {
            if (discordReward == StirringDiscordRewards.None && !completeOnce)
            {
                Core.Logger("Conditions met: Reward is None and completeOnce is false. Exiting Stirring Discord quest.");
            }
            else if (discordReward != StirringDiscordRewards.None && Core.CheckInventory((int)discordReward, toInv: false) && Story.QuestProgression(8998))
            {
                Core.Logger("Conditions met: Reward is present and quest progression is complete. Exiting Stirring Discord quest.");
            }

            return; // Signal to exit
        }

        Core.AddDrop(rewards);
        HB.HardcoreContract();
        Farm.Experience(75);

        Core.Logger($"Reward Chosen: {discordReward.ToString().Replace("_", " ")}");
        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            Core.EnsureAcceptmultiple(new[] { 7158, 8998 });
            Core.HuntMonster("lagunabeach", "Heart of Chaos", "Chaos Pirate Crew", isTemp: false);
            Core.HuntMonster("backroom", "Book Wyrm", "Maledictus Magum", isTemp: false);
            Core.HuntMonster("wardwarf", "Chaotic Draconian", "Chaotic Draconian Wings", isTemp: false);
            Core.KillMonster("blindingsnow", "r5", "Spawn", "*", "Shard of Chaos", 100, isTemp: false);
            Core.HuntMonster("chaosboss", "Ultra Chaos Warlord", "Chaotic War Essence", 15, false);
            Adv.BuyItem("crownsreach", 1383, "Chaotic Knight Helm");

            // Handle quest completion
            if (completeOnce)
            {
                Core.EnsureComplete(8998);
                Core.Logger("Stirring Discord quest completed.");
                return;
            }

            // Handle reward selection
            if (rewardSelection == StirringDiscordRewards.All)
            {
                Core.EnsureCompleteChoose(8998, Core.QuestRewards(8998));
                if (Core.CheckInventory(Core.QuestRewards(8998), toInv: false))
                {
                    Core.Logger("All rewards present, exiting Stirring Discord quest.");
                    return;
                }
            }
            else
            {
                // Complete for the specific reward if not owned
                if (!Core.CheckInventory((int)discordReward))
                {
                    Core.EnsureComplete(8998, (int)discordReward);
                    Core.Logger($"Stirring Discord quest completed for reward: {discordReward}");
                }
                break;
            }
        }
    }

    public void InTheBeastsShadow(InTheBeastsShadowRewards rewardSelection = InTheBeastsShadowRewards.None, bool completeOnce = false)
    {
        if (!Story.QuestProgression(8998))
        {
            Core.Logger("Quest not unlocked [8999], doing \"Stirring Discord\"");
            StirringDiscord(completeOnce: true);
        }

        string[] rewards = Core.QuestRewards(8999);
        InTheBeastsShadowRewards beastsShadowReward = Bot.Config!.Get<InTheBeastsShadowRewards>("In The Beasts Shadow");

        // Check if we should return early based on inventory conditions and 'completeOnce' flag
        bool shouldReturnEarly =
            (beastsShadowReward == InTheBeastsShadowRewards.None && !completeOnce) || // Reward is None and completeOnce is false
            (beastsShadowReward == InTheBeastsShadowRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(8999)) || // All rewards present and quest progression is complete
            (beastsShadowReward != InTheBeastsShadowRewards.None && Core.CheckInventory((int)beastsShadowReward, toInv: false) && Story.QuestProgression(8999)); // Specific reward present and quest progression is complete

        if (shouldReturnEarly)
        {
            if (beastsShadowReward == InTheBeastsShadowRewards.None && !completeOnce)
            {
                Core.Logger("Conditions met: Reward is None and completeOnce is false. Exiting In The Beasts Shadow quest.");
            }
            else if (beastsShadowReward == InTheBeastsShadowRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(8999))
            {
                Core.Logger("Conditions met: All rewards present and quest progression is complete. Exiting In The Beasts Shadow quest.");
            }
            else if (beastsShadowReward != InTheBeastsShadowRewards.None && Core.CheckInventory((int)beastsShadowReward, toInv: false) && Story.QuestProgression(8999))
            {
                Core.Logger("Conditions met: Specific reward present and quest progression is complete. Exiting In The Beasts Shadow quest.");
            }

            return; // Signal to exit
        }

        Core.AddDrop(rewards);
        Farm.Experience(75);

        Core.Logger($"Reward Chosen: {beastsShadowReward.ToString().Replace("_", " ")}");

        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            Core.EnsureAccept(8999);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("hydra", "Hydra Head", "Hydra Armor", isTemp: false);
            Core.HuntMonster("roc", "Rock Roc", "Mini Rock Roc", isTemp: false);
            Core.KillMonster("odokuro", "Boss", "Right", "O-dokuro", "O-dokuro on Your Back", isTemp: false);
            Core.HuntMonster("chaoscave", "DracoWerePyre", "Burning Dragon Mace", isTemp: false);
            Core.HuntMonster("palooza", "Pony Gary Yellow", "Mini Pony Gary Yellow", isTemp: false);
            Core.HuntMonster("elemental", "Mana Golem", "Mana Golem", isTemp: false);
            Core.KillEscherion("Relic of Chaos", 13);

            Core.EquipClass(ClassType.Farm);
            Core.KillMonster("mountdoomskull", "b1", "Left", "*", "Fragment of Mount Doomskull", 1000, isTemp: false);

            // Handle quest completion
            if (completeOnce)
            {
                Core.EnsureComplete(8999);
                Core.Logger("In The Beasts Shadow quest completed.");
                return;
            }

            if (rewardSelection == InTheBeastsShadowRewards.All)
            {
                Core.EnsureCompleteChoose(8999, Core.QuestRewards(8999));
                if (Core.CheckInventory(Core.QuestRewards(8999), toInv: false))
                {
                    Core.Logger("All rewards present, exiting In The Beasts Shadow quest.");
                    return;
                }
            }
            else
            {
                // Complete for the specific reward if not owned
                if (!Core.CheckInventory((int)beastsShadowReward))
                {
                    Core.EnsureComplete(8999, (int)beastsShadowReward);
                    Core.Logger($"In The Beasts Shadow quest completed for reward: {beastsShadowReward}");
                }
                break;
            }
        }
    }

    public void UniqueQuarry(UniqueQuarryRewards rewardSelection = UniqueQuarryRewards.None, bool completeOnce = false)
    {
        if (!Core.isCompletedBefore(8999))
        {
            Core.Logger("Quest not unlocked [9000], doing \"In The Beasts Shadow\"");
            InTheBeastsShadow(completeOnce: true);
        }

        string[] rewards = Core.QuestRewards(9000);
        UniqueQuarryRewards quarryReward = Bot.Config!.Get<UniqueQuarryRewards>("Unique Quarry");

        // Check if we should return early based on inventory conditions and 'completeOnce' flag
        bool shouldReturnEarly =
            (quarryReward == UniqueQuarryRewards.None && !completeOnce) || // Reward is None and completeOnce is false
            (quarryReward == UniqueQuarryRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9000)) || // All rewards present and quest progression is complete
            (quarryReward != UniqueQuarryRewards.None && Core.CheckInventory((int)quarryReward, toInv: false) && Story.QuestProgression(9000)); // Specific reward present and quest progression is complete

        if (shouldReturnEarly)
        {
            if (quarryReward == UniqueQuarryRewards.None && !completeOnce)
            {
                Core.Logger("Conditions met: Reward is None and completeOnce is false. Exiting Unique Quarry quest.");
            }
            else if (quarryReward == UniqueQuarryRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9000))
            {
                Core.Logger("Conditions met: All rewards present and quest progression is complete. Exiting Unique Quarry quest.");
            }
            else if (quarryReward != UniqueQuarryRewards.None && Core.CheckInventory((int)quarryReward, toInv: false) && Story.QuestProgression(9000))
            {
                Core.Logger("Conditions met: Specific reward present and quest progression is complete. Exiting Unique Quarry quest.");
            }

            return; // Signal to exit
        }

        Core.AddDrop(rewards);
        Farm.Experience(75);
        ADG.AscendedGear("Ascended Face of Chaos");

        Core.Logger($"Reward Chosen: {quarryReward.ToString().Replace("_", " ")}");
        Bot.Quests.UpdateQuest(2804);
        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            Core.EnsureAccept(9000);
            Core.EquipClass(ClassType.Farm);
            Core.KillMonster("chaoswar", "r2", "Spawn", "*", "Chaos Tentacle", 300, isTemp: false);

            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("sandcastle", "Chaos Sphinx", "Chaos Sphinx", isTemp: false);
            Core.HuntMonster("deepchaos", "Kathool", "Kathool Annihilator", isTemp: false);
            Core.HuntMonster("castleroof", "Chaos Dragon", "Chaos Dragon Slayer", isTemp: false);
            Core.HuntMonster("mirrorportal", "Chaos Harpy", "HarpyHunter", isTemp: false);
            Core.HuntMonster("orecavern", "Naga Baas", "Naga Baas Pet", isTemp: false);
            Core.HuntMonster("venomvaults", "Manticore", "Treasure Vault Key", isTemp: false);

            Adv.BuyItem("venomvaults", 585, "Chaotic Manticore Head");

            if (!Core.CheckInventory("Chaoroot", 30))
            {
                Farm.Gold(900000);
                Core.BuyItem("tercessuinotlim", 1951, "Receipt of Swindle", 3);
                Core.BuyItem("tercessuinotlim", 1951, "Chaoroot", 30);
            }

            // Handle quest completion
            if (completeOnce)
            {
                Core.EnsureComplete(9000);
                Core.Logger("Unique Quarry quest completed.");
                return;
            }

            if (rewardSelection == UniqueQuarryRewards.All)
            {
                Core.EnsureCompleteChoose(9000, Core.QuestRewards(9000));
                if (Core.CheckInventory(Core.QuestRewards(9000), toInv: false))
                {
                    Core.Logger("All rewards present, exiting Unique Quarry quest.");
                    return;
                }
            }
            else
            {
                // Complete for the specific reward if not owned
                if (!Core.CheckInventory((int)quarryReward))
                {
                    Core.EnsureComplete(9000, (int)quarryReward);
                    Core.Logger($"Unique Quarry quest completed for reward: {quarryReward}");
                }
                break;
            }
        }
    }

    public void WaveringIllusions(WaveringIllusionsRewards rewardSelection = WaveringIllusionsRewards.None, bool completeOnce = false)
    {
        if (!Core.isCompletedBefore(9000))
        {
            Core.Logger("Quest not unlocked [9001], doing \"Unique Quarry\"");
            UniqueQuarry(completeOnce: true);
        }

        string[] rewards = Core.QuestRewards(9001);
        WaveringIllusionsRewards illusionsReward = Bot.Config!.Get<WaveringIllusionsRewards>("Wavering Illusions");

        // Check if we should return early based on inventory conditions and 'completeOnce' flag
        bool shouldReturnEarly =
            (illusionsReward == WaveringIllusionsRewards.None && !completeOnce) || // Reward is None and completeOnce is false
            (illusionsReward == WaveringIllusionsRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9001)) || // All rewards present and quest progression is complete
            (illusionsReward != WaveringIllusionsRewards.None && Core.CheckInventory((int)illusionsReward, toInv: false) && Story.QuestProgression(9001)); // Specific reward present and quest progression is complete

        if (shouldReturnEarly)
        {
            if (illusionsReward == WaveringIllusionsRewards.None && !completeOnce)
            {
                Core.Logger("Conditions met: Reward is None and completeOnce is false. Exiting Wavering Illusions quest.");
            }
            else if (illusionsReward == WaveringIllusionsRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9001))
            {
                Core.Logger("Conditions met: All rewards present and quest progression is complete. Exiting Wavering Illusions quest.");
            }
            else if (illusionsReward != WaveringIllusionsRewards.None && Core.CheckInventory((int)illusionsReward, toInv: false) && Story.QuestProgression(9001))
            {
                Core.Logger("Conditions met: Specific reward present and quest progression is complete. Exiting Wavering Illusions quest.");
            }

            return; // Signal to exit
        }

        Core.AddDrop(rewards);
        Farm.Experience(80);
        QOM.TheQueensSecrets();
        Core.HuntMonster("finalbattle", "Drakath", "Drakath Wings", isTemp: false);

        Core.Logger($"Reward Chosen: {illusionsReward}");
        if (!Core.CheckInventory("Supreme Arcane Staff of Chaos"))
        {
            Core.Logger("Hunting for Supreme Arcane Staff of Chaos.");
            Core.HuntMonster("ledgermayne", "Ledgermayne", "The Supreme Arcane Staff", isTemp: false); // Can buyback
            Adv.BuyItem("deepforest", 1999, "Supreme Arcane Staff of Chaos");
        }

        CPM.Badge();

        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            Core.EnsureAccept(9001);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("chaoscrypt", "Chaorrupted Knight", "Chaos Gem", 200, isTemp: false);

            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("chaoslab", "Chaos Artix", "Chaorrupted Light of Destiny", isTemp: false);
            Core.HuntMonster("mqlesson", "Dragonoid", "Dragonoid of Hours", isTemp: false);
            Core.HuntMonster("timespace", "Chaos Lord Iadoa", "Chaorrupted Hourglass", 30, isTemp: false, publicRoom: true);
            Core.HuntMonster("chaoskraken", "Chaos Kraken", "Chaotic Invertebrae", 20, isTemp: false, publicRoom: true);

            Core.BuyItem("downbelow", 2004, "Chaos PuppetMaster");

            // Handle quest completion
            if (completeOnce)
            {
                Core.EnsureComplete(9001);
                Core.Logger("Wavering Illusions quest completed.");
                return;
            }

            if (rewardSelection == WaveringIllusionsRewards.All)
            {
                Core.EnsureCompleteChoose(9001, Core.QuestRewards(9001));
                if (Core.CheckInventory(Core.QuestRewards(9001), toInv: false))
                {
                    Core.Logger("All rewards present, exiting Wavering Illusions quest.");
                    return;
                }
            }
            else
            {
                // Complete for the specific reward if not owned
                if (!Core.CheckInventory((int)illusionsReward))
                {
                    Core.EnsureComplete(9001, (int)illusionsReward);
                    Core.Logger($"Wavering Illusions quest completed for reward: {illusionsReward}");
                }
                break;
            }
        }
    }

    public void ShadowsOfDisdain(ShadowsOfDisdainRewards rewardSelection = ShadowsOfDisdainRewards.None, bool completeOnce = false)
    {
        if (!Core.isCompletedBefore(9001))
        {
            Core.Logger("Quest not unlocked [9002], doing \"Wavering Illusions\"");
            WaveringIllusions(completeOnce: true);
        }

        string[] rewards = Core.QuestRewards(9002);
        ShadowsOfDisdainRewards disdainReward = Bot.Config!.Get<ShadowsOfDisdainRewards>("Shadows Of Disdain");

        // Check if quest can be skipped
        bool shouldReturnEarly =
            (disdainReward == ShadowsOfDisdainRewards.None && !completeOnce) ||
            (disdainReward == ShadowsOfDisdainRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9002)) ||
            (disdainReward != ShadowsOfDisdainRewards.None && Core.CheckInventory((int)disdainReward, toInv: false) && Story.QuestProgression(9002));

        if (shouldReturnEarly)
        {
            Core.Logger("Skipping Shadows Of Disdain quest due to conditions met.");
            return;
        }

        Core.AddDrop(rewards);
        Farm.Experience(95);
        ED.getSet();

        // Obtain Titan Drakath if not already owned
        if (!Core.CheckInventory("Titan Drakath"))
        {
            Core.Logger("Hunting for Titan Drakath.");
            TGM.BuyAllMerge("Titan Drakath");
        }

        Core.Logger($"Reward Chosen: {disdainReward.ToString().Replace("_", " ")}");

        // Main farming loop
        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            Core.EnsureAccept(9002);

            // Collect Chaos War Medals
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("mountdoomskull", "Chaos Spider", "Chaos War Medal", 1000, isTemp: false);

            // Defeat Prince Drakath
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("finalshowdown", "Prince Drakath", "Drakath Pet", isTemp: false);

            // Complete additional quest requirements
            CAV.FragmentsoftheLordsA();
            CAV.FragmentsoftheLordsB();
            Core.HuntMonster("ultradrakath", "Champion of Chaos", "Trace of Chaos", 13, isTemp: false, publicRoom: true);

            // Purchase Chaorrupted Usurper
            Adv.BuyItem("transformation", 2002, "Chaorrupted Usurper");

            // Handle quest completion
            if (completeOnce)
            {
                Core.EnsureComplete(9002);
                Core.Logger("Shadows Of Disdain quest completed.");
                return;
            }

            if (rewardSelection == ShadowsOfDisdainRewards.All)
            {
                Core.EnsureCompleteChoose(9002, Core.QuestRewards(9002));
                if (Core.CheckInventory(Core.QuestRewards(9002), toInv: false))
                {
                    Core.Logger("All rewards present, exiting Shadows Of Disdain quest.");
                    return;
                }
            }
            else
            {
                // Complete for the specific reward if not owned
                if (!Core.CheckInventory((int)disdainReward))
                {
                    Core.EnsureComplete(9002, (int)disdainReward);
                    Core.Logger($"Shadows Of Disdain quest completed for reward: {disdainReward}");
                }
                break;
            }
        }
    }

    public void PersistingMayhem(PersistingMayhemRewards rewardSelection = PersistingMayhemRewards.None, bool completeOnce = false)
    {
        if (!Core.isCompletedBefore(9002))
        {
            Core.Logger("Quest not unlocked [9003], doing \"Shadows of Disdain\"");
            ShadowsOfDisdain(completeOnce: true);
        }

        string[] rewards = Core.QuestRewards(9003);
        PersistingMayhemRewards mayhemReward = Bot.Config!.Get<PersistingMayhemRewards>("Persisting Mayhem");

        Core.Logger($"Reward Chosen: {mayhemReward.ToString().Replace("_", " ")}");

        // Check if we should return early based on inventory conditions and 'completeOnce' flag
        bool shouldReturnEarly =
            (mayhemReward == PersistingMayhemRewards.None && !completeOnce) || // Reward is None and completeOnce is false
            (mayhemReward == PersistingMayhemRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9003)) || // All rewards present and quest progression is complete
            (mayhemReward != PersistingMayhemRewards.None && Core.CheckInventory((int)mayhemReward, toInv: false) && Story.QuestProgression(9003)); // Specific reward present and quest progression is complete

        if (shouldReturnEarly)
        {
            if (mayhemReward == PersistingMayhemRewards.None && !completeOnce)
            {
                Core.Logger("Conditions met: Reward is None and completeOnce is false. Exiting Persisting Mayhem quest.");
            }
            else if (mayhemReward == PersistingMayhemRewards.All && Core.CheckInventory(rewards, toInv: false) && Story.QuestProgression(9003))
            {
                Core.Logger("Conditions met: All rewards present and quest progression is complete. Exiting Persisting Mayhem quest.");
            }
            else if (mayhemReward != PersistingMayhemRewards.None && Core.CheckInventory((int)mayhemReward, toInv: false) && Story.QuestProgression(9003))
            {
                Core.Logger("Conditions met: Specific reward present and quest progression is complete. Exiting Persisting Mayhem quest.");
            }

            return; // Signal to exit
        }

        Core.AddDrop(rewards);
        Farm.Experience(95);

        while (!Bot.ShouldExit && !shouldReturnEarly)
        {
            // Accept the quest
            Core.EnsureAccept(9003);

            // Farm for the required item
            Core.HuntMonster("ultradrakath", "Champion of Chaos", "Trace of Chaos", 13, isTemp: false, publicRoom: true);

            if (completeOnce)
            {
                // Complete the quest and exit if only completing once
                Core.EnsureComplete(9003);
                Core.Logger("Persisting Mayhem quest completed.");
                return;
            }
            else
            {
                if (rewardSelection == PersistingMayhemRewards.All)
                {
                    Core.EnsureCompleteChoose(9003, Core.QuestRewards(9003));
                    if (Core.CheckInventory(Core.QuestRewards(9003), toInv: false))
                    {
                        Core.Logger("All rewards present, exiting Persisting Mayhem quest.");
                        return;
                    }
                }
                else
                {
                    // Complete the quest for the specific reward if not owned
                    if (!Core.CheckInventory((int)rewardSelection))
                    {
                        Core.EnsureComplete(9003, (int)rewardSelection);
                        Core.Logger($"Persisting Mayhem quest completed for reward: {rewardSelection}");
                    }
                }
            }
        }

    }

    public enum StirringDiscordRewards
    {
        Hollowborn_Chaos_Warrior = 74476,
        Hollowborn_Chaos_Morph = 74477,
        Hollowborn_Chaotic_Wings = 74478,
        All,
        None
    }
    public enum InTheBeastsShadowRewards
    {
        Hollowborn_Omega_Blades = 74480,
        Hollowborn_Omega_Sword = 74481,
        Hollowborn_Chaos_Unlocker = 74482,
        All,
        None
    }
    public enum UniqueQuarryRewards
    {
        Hollowborn_Benevolent_Locks = 74485,
        Hollowborn_Malignant_Locks = 74488,
        Hollowborn_Face_of_Chaos = 74491,
        Hollowborn_Gaze_of_Chaos = 74492,
        All,
        None
    }
    public enum WaveringIllusionsRewards
    {
        Hollowborn_Eye_of_Chaos = 74479,
        Hollowborn_Wings_of_Chaos = 74493,
        Hollowborn_Chaotic_Portal = 74499,
        All,
        None
    }
    public enum ShadowsOfDisdainRewards
    {
        Hollowborn_Envoy_of_Chaos = 74489,
        Hollowborn_Alignment_Aspects = 74494,
        Hollowborn_Blade_of_Chaos_Cape = 74495,
        Hollowborn_Chaotic_Portal = 74496,
        Hollowborn_Blade_of_Chaos = 74497,
        Hollowborn_Claw_of_Chaos = 74498,
        All,
        None
    }
    public enum PersistingMayhemRewards
    {
        Hollowborn_Benevolent = 74483,
        Hollowborn_Benevolent_Morph = 74484,
        Hollowborn_Malignant = 74486,
        Hollowborn_Malignant_Morph = 74487,
        Idle_Hollowborn_Envoy_of_Chaos = 74490,

        [EnumMember(Value = "Hollowborn_Blade_of_Chaos_(Floor)")]
        Hollowborn_Blade_of_Chaos_Floor = 74500,

        Hollowborn_Blades_of_Chaos = 74501,
        Hollowborn_Omega_Swords = 74502,
        Hollowborn_Chaos_Unlockers = 74503,
        All,
        None
    }

}
