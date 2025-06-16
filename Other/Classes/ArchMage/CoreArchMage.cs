/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Farm/BuyScrolls.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
//cs_include Scripts/ShadowsOfWar/CoreSoWMats.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Skills;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class CoreArchMage
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private BuyScrolls Scroll = new();
    private CoreBLOD BLOD = new();
    private CoreQOM QOM = new();
    private CoreSoW SoW = new();
    private CoreSoWMats SOWM = new();

    public bool DontPreconfigure = true;
    public string OptionsStorage = "ArchMage";
    public List<IOption> Options = new()
    {
        new Option<bool>("lumina_elementi", "Lumina Elementi", "Todo the last quest or not, for the 51% wep(takes awhileand will require aditional boss items.) [On by default]", true),
        new Option<bool>("cosmetics", "Get Cosmetics", "Gets the cosmetic rewards (redoes quests if you don't have them, disable to just get ArchMage and the weapon) [On by default]", false),
        new Option<bool>("army", "Armying?", "use when running on 4 accounts at once only, will probably get out of sync.) [Off by default]", false),
        CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(RequiredItems.Concat(BossDrops).ToArray());
        Core.SetOptions();

        GetAM();

        Core.SetOptions(false);
    }

    public void GetAM(bool rankUpClass = true)
    {
        bool cosmetics = Bot.Config!.Get<bool>("cosmetics");
        bool lumina = Bot.Config!.Get<bool>("lumina_elementi");
        army = Bot.Config!.Get<bool>("army");

        if (Core.CheckInventory("ArchMage", toInv: false))
        {
            if (!lumina)
            {
                if (!cosmetics)
                {
                    Core.Logger("You own \"ArchMage\", farm complete.");
                    return;
                }
                else if (Core.CheckInventory(Cosmetics, toInv: false))
                {
                    Core.Logger("You own \"ArchMage\" and the extra cometics, farm complete.");
                    return;
                }
            }
            else if (Core.CheckInventory("Providence", toInv: false))
            {
                if (!cosmetics)
                {
                    Core.Logger("You own \"ArchMage\" and \"Providence\", farm complete.");
                    return;
                }
                else if (Core.CheckInventory(Cosmetics, toInv: false))
                {
                    Core.Logger("You own \"ArchMage\", \"Providence\", and the extra cometics, farm complete.");
                    return;
                }
            }
        }

        if (army)
            Core.Logger("Armying Set to True, Please have all accounts logged in and Following this Acc using the Tools > Butler.cs");
        Bot.Drops.Add(RequiredItems.Concat(BossDrops).Concat(Cosmetics).ToArray());

        Core.Logger("The bot will now farm all requierments for ArchMage");
        SoW.CompleteCoreSoW();
        if (!Core.isCompletedBefore(9126))
            Core.Logger("Quests must be completed upto 9126 (9123 > 9126) manualy as they require a dodge class.", stopBot: true);
        QOM.TheReshaper();

        Farm.SpellCraftingREP();
        Farm.EmberseaREP();
        Farm.ChaosREP();
        Farm.GoodREP();
        Farm.EvilREP();
        Farm.EtherStormREP();
        Farm.LoremasterREP();

        Farm.Experience(100);

        Core.Logger("Requirements complete");

        if (!Core.CheckInventory("ArchMage"))
        {
            Core.EnsureAccept(8918);
            Core.Logger($"ArchMage: Cosmetics = {cosmetics}");

            BookOfMagus();
            BookOfFire(cosmetics);
            BookOfIce(cosmetics);
            BookOfAether(cosmetics);
            BookOfArcana(cosmetics);

            Core.ToBank(Cosmetics);
            BossItemCheck(250, "Elemental Binding");

            Core.Unbank("Book of Magus", "Book of Fire", "Book of Ice", "Book of Aether", "Book of Arcana", "Elemental Binding");
            Core.EnsureComplete(8918);

            Bot.Wait.ForPickup("ArchMage");
            Core.ToBank(Cosmetics);

            if (rankUpClass)
                Adv.RankUpClass("ArchMage");
        }

        if (lumina)
            LuminaElementi();
    }

    public void LuminaElementi(bool standalone = false, bool Extras = false)
    {
        bool GetCosmetics = Bot.Config!.Get<bool>("cosmetics") || Extras == true;
        if (standalone || GetCosmetics ?
                Core.CheckInventory(Core.EnsureLoad(8919).Rewards.Select(x => x.ID).ToArray(), toInv: false) :
                Core.CheckInventory("Providence"))
            return;

        if (!Bot.Quests.IsUnlocked(8919))
            GetAM(false);

        Core.AddDrop("Providence");
        Core.EnsureAccept(8919);
        Core.Logger("Doing the extra quest for the 51% weapon \"Providence\"");

        UnboundTome(Core.CheckInventory("Book of Arcana") ? 30 : 31);
        BookOfArcana();

        BossItemCheck(2500, "Elemental Binding");

        SOWM.PrismaticSeams(2000);

        UnboundThread(100);

        foreach ((int ItemID, int ShopItemID) Enh in new[] { (71629, 43050), (70752, 42601) })
        {
            if (Core.CheckInventory(Enh.ItemID))
                continue;

            Adv.BuyItem("forge", 2142, Enh.ItemID, shopItemID: Enh.ShopItemID);
        }

        Core.EnsureComplete(8919);
        Bot.Wait.ForPickup("Providence");
        Core.Logger("Weapon obtained: \"Providence\" [51% damage to all]");
    }

    #region Books
    public void BookOfMagus()
    {
        //Book of Magus: Incantation
        if (Core.CheckInventory("Book of Magus"))
            return;

        Core.FarmingLogger("Book of Magus", 1);
        UnboundTome(1);
        Core.EnsureAccept(8913);
        BLOD.GetBlindingWeapon(WeaponOfDestiny.Mace);
        BLOD.BrilliantAura(200);

        Scroll.BuyScroll(Scrolls.Mystify, 50);
        SOWM.PrismaticSeams(250);

        Core.HuntMonster("noxustower", "Lightguard Caster", "Mortal Essence", 100, false);
        Core.HuntMonster("portalmazec", "Pactagonal Knight", "Orthogonal Energy", 150, false);

        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("timeinn", "Ezrajal", "Celestial Magia", 50, false);

        Core.EnsureComplete(8913);
        Bot.Wait.ForPickup("Book of Magus");
        Core.ToBank(BLOD.BLoDItems);

    }

    public void BookOfFire(bool Extras = false)
    {
        //Book of Fire: Immolation
        bool GetCosmetics = Bot.Config!.Get<bool>("cosmetics") || Extras == true;
        if (GetCosmetics ?
                Core.CheckInventory(Core.EnsureLoad(8914).Rewards.Select(x => x.ID).ToArray(), toInv: false) :
                Core.CheckInventory("Book of Fire"))
            return;

        Core.FarmingLogger("Book of Fire", 1);

        UnboundTome(1);
        Core.EnsureAccept(8914);

        Scroll.BuyScroll(Scrolls.FireStorm, 50);

        Core.EquipClass(ClassType.Farm);
        Core.HuntMonster("fireavatar", "Shadefire Cavalry", "ShadowFire Wisps", 200, false);
        Core.HuntMonster("fotia", "Femme Cult Worshiper", "Spark of Life", 200, false);
        Core.HuntMonster("mafic", "Living Fire", "Emblazoned Basalt", 200, false);

        Core.EquipClass(ClassType.Solo);
        Core.KillMonster("underlair", "r6", "Left", "Void Draconian", "Dense Dragon Crystal", 200, false);

        Core.EnsureComplete(8914);
        Bot.Wait.ForPickup("Book of Fire");
        Core.ToBank(Cosmetics);
    }

    public void BookOfIce(bool Extras = false)
    {
        bool GetCosmetics = Bot.Config!.Get<bool>("cosmetics") || Extras == true;
        if (GetCosmetics ?
                Core.CheckInventory(Core.EnsureLoad(8915).Rewards.Select(x => x.ID).ToArray(), toInv: false) :
                Core.CheckInventory("Book of Ice"))
            return;

        Core.FarmingLogger("Book of Ice", 1);

        UnboundTome(1);
        Core.EnsureAccept(8915);

        Scroll.BuyScroll(Scrolls.Frostbite, 50);

        Core.AddDrop("Ice Diamond");
        Core.EquipClass(ClassType.Farm);
        Core.FarmingLogger("Ice Diamond", 100);
        while (!Bot.ShouldExit && !Core.CheckInventory("Ice Diamond", 100))
        {
            Core.EnsureAccept(7279);
            Core.KillMonster("kingcoal", "r1", "Left", "*", "Frozen Coal", 10, log: false);
            Core.EnsureComplete(7279);
            Bot.Wait.ForPickup("Ice Diamond");
        }
        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("icepike", "Chained Kezeroth", "Rimeblossom", 100, false);
        Core.HuntMonster("icepike", "Karok The Fallen", "Starlit Frost", 100, false);
        Core.HuntMonster("icedungeon", "Shade of Kyanos", "Temporal Floe", 100, false);

        Core.EnsureComplete(8915);
        Bot.Wait.ForPickup("Book of Ice");
        Core.ToBank(Cosmetics);

    }

    public void BookOfAether(bool Extras = false)
    {
        bool GetCosmetics = Bot.Config!.Get<bool>("cosmetics") || Extras == true;
        if (GetCosmetics ?
                Core.CheckInventory(Core.EnsureLoad(8916).Rewards.Select(x => x.ID).ToArray(), toInv: false) :
                Core.CheckInventory("Book of Aether"))
            return;

        Core.FarmingLogger("Book of Aether", 1);

        BossItemCheck(1, "Void Essentia", "Vital Exanima", "Everlight Flame");

        UnboundTome(1);
        Core.EnsureAccept(8916);

        Scroll.BuyScroll(Scrolls.Eclipse, 50);

        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("streamwar", "Second Speaker", "A Fragment of the Beginning", isTemp: false);
        // Core.HuntMonster("fireavatar", "Avatar Tyndarius", "Everlight Flame", isTemp: false); //1% Drop Rate
        Core.EnsureComplete(8916);
        Bot.Wait.ForPickup("Book of Aether");
        Core.ToBank(Cosmetics);

    }

    public void BookOfArcana(bool Extras = false)
    {
        bool GetCosmetics = Bot.Config!.Get<bool>("cosmetics") || Extras == true;
        if (GetCosmetics ?
                Core.CheckInventory(Core.EnsureLoad(8917).Rewards.Select(x => x.ID).ToArray(), toInv: false) :
                Core.CheckInventory("Book of Arcana"))
            return;

        Core.FarmingLogger("Book of Arcana", 1);

        BossItemCheck(1, "The Mortal Coil", "The Divine Will", "Insatiable Hunger", "Undying Resolve", "Calamitous Ruin");

        UnboundTome(1);
        Core.EnsureAccept(8917);

        Scroll.BuyScroll(Scrolls.EtherealCurse, 50);

        Core.EnsureComplete(8917);
        Bot.Wait.ForPickup("Book of Arcana");
        Core.ToBank(Cosmetics);
    }

    #endregion

    #region Materials
    public void MysticScribingKit(int quant = 99)
    {
        if (Core.CheckInventory(73327, quant))
        {
            return;
        }

        Core.FarmingLogger("Mystic Scribing Kit", quant);
        Core.AddDrop("Mystic Scribing Kit");

        while (!Bot.ShouldExit && !Core.CheckInventory("Mystic Scribing Kit", quant))
        {
            Core.EnsureAccept(8909);

            Core.EquipClass(ClassType.Farm);
            Core.FarmingLogger("Mystic Quills", 49);
            Core.FarmingLogger("Mystic Shards", 49);


            if (!Core.isCompletedBefore(3052))
            {
                Core.EnsureAccept(3052);
                Core.GetMapItem(1921, 1, "dragonrune");
                Core.GetMapItem(1922, 1, "dragonrune");
                Core.GetMapItem(1923, 1, "dragonrune");
                Core.GetMapItem(1924, 1, "dragonrune");
                Core.EnsureComplete(3052);
            }
            Core.RegisterQuests(3050);
            while (!Bot.ShouldExit && !Core.CheckInventory(new[] { "Mystic Shards", "Mystic Quills" }, 49))
            {
                Core.HuntMonster("gilead", "Water Elemental", "Water Core", log: false);
                Core.HuntMonster("gilead", "Fire Elemental", "Fire Core", log: false);
                Core.HuntMonster("gilead", "Wind Elemental", "Air Core", log: false);
                Core.HuntMonster("gilead", "Earth Elemental", "Earth Core", log: false);
                Core.HuntMonster("gilead", "Mana Elemental", "Mana Core", log: false);
            }

            Core.CancelRegisteredQuests();

            Core.EquipClass(ClassType.Solo);
            if (!Core.CheckInventory("Semiramis Feather"))
            {
                Core.AddDrop("Semiramis Feather");
                Core.EnsureAccept(6286);
                Core.HuntMonster("guardiantree", "Terrane", "Terrane Defeated");
                Core.EnsureComplete(6286);
                Bot.Wait.ForPickup("Semiramis Feather");
            }
            Core.HuntMonster("deepchaos", "Kathool", "Mystic Ink", isTemp: false);

            Core.EnsureComplete(8909);
            Bot.Wait.ForPickup("Mystic Scribing Kit");
        }
    }

    public void PrismaticEther(int quant = 99)
    {
        if (Core.CheckInventory(73333, quant))
        {
            return;
        }

        if (!Bot.Quests.IsUnlocked(8910))
            MysticScribingKit(1);

        Core.FarmingLogger("Prismatic Ether", quant);
        Core.AddDrop("Prismatic Ether");
        Core.EquipClass(ClassType.Solo);
        while (!Bot.ShouldExit && !Core.CheckInventory("Prismatic Ether", quant))
        {
            Core.EnsureAccept(8910);
            Core.KillNulgathFiendShard("Infernal Ether");
            Core.HuntMonster("celestialarenad", "Aranx", "Celestial Ether", isTemp: false);
            Core.HuntMonster("eternalchaos", "Eternal Drakath", "Chaotic Ether", isTemp: false);
            Core.KillMonster("shadowattack", "Boss", "Left", "Death", "Mortal Ether", isTemp: false);
            Core.HuntMonster("gaiazor", "Gaiazor", "Vital Ether", isTemp: false);
            Core.EnsureComplete(8910);
            Bot.Wait.ForPickup("Prismatic Ether");
        }
    }

    public void ArcaneLocus(int quant = 99)
    {
        if (Core.CheckInventory(73339, quant))
        {
            return;
        }

        if (!Bot.Quests.IsUnlocked(8911))
            PrismaticEther(1);

        Core.FarmingLogger("Arcane Locus", quant);
        Core.AddDrop(73339);

        while (!Bot.ShouldExit && !Core.CheckInventory(73339, quant))
        {
            Core.EnsureAccept(8911);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("natatorium", "Anglerfish", "Sea Locus", isTemp: false);
            Core.EquipClass(ClassType.Solo);
            Core.Sleep(2500);
            Core.Logger("cutscene happens when joining some maps, give the bot a sec to realise its not broke :P");
            Core.Sleep(2500);
            Core.KillMonster("skytower", "r13", "Bottom", "*", "Sky Locus", isTemp: false);
            Core.HuntMonster("elemental", "Mana Golem", "Prime Locus Attunement", 30, isTemp: false);
            Core.HuntMonster("ectocave", "Ektorax", "Earth Locus", isTemp: false);
            Core.HuntMonster("drakonnan", "Drakonnan", "Fire Locus", isTemp: false);

            Core.EnsureComplete(8911);
            Bot.Wait.ForPickup(73339);
        }
    }

    //you'll need 35 for everything if ive done maths correctly
    // 5 for the books, and 31 for lumina(30 + 1 for book)
    public void UnboundTome(int quant = 36)
    {
        if (Core.CheckInventory("Unbound Tome", quant))
        {
            return;
        }

        if (!Bot.Quests.IsUnlocked(8912))
        {
            ArcaneLocus(1);
        }

        Core.FarmingLogger("Unbound Tome", quant);

        MysticScribingKit(quant);
        PrismaticEther(quant);
        ArcaneLocus(quant);

        Core.AddDrop("Unbound Tome");

        while (!Bot.ShouldExit
        && Core.CheckInventory(new[] { "Mystic Scribing Kit", "Prismatic Ether", "Arcane Locus" })
        && !Core.CheckInventory("Unbound Tome", quant))
        {
            Core.EnsureAccept(8912);

            Farm.DragonRunestone(30);
            Adv.BuyItem("darkthronehub", 1308, "Exalted Paladin Seal");
            Adv.BuyItem("shadowfall", 89, "Forsaken Doom Seal");

            Core.EnsureComplete(8912);
            Bot.Wait.ForPickup("Unbound Tome");

            if (Core.CheckInventory("Unbound Tome", quant))
            {
                break;
            }
        }
    }

    public void UnboundThread(int quant = 100)
    {
        if (Core.CheckInventory("Unbound Thread", quant))
        {
            return;
        }

        Core.AddDrop("Unbound Thread");
        while (!Bot.ShouldExit && !Core.CheckInventory("Unbound Thread", 100))
        {
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("DeadLines", "Frenzied Mana", "Captured Mana", 8);
            Core.HuntMonster("DeadLines", "Shadowfall Warrior", "Armor Scrap", 8);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("DeadLines", "Eternal Dragon", "Eternal Dragon Scale");
            Bot.Wait.ForPickup("Unbound Thread");
        }
        Core.CancelRegisteredQuests();
    }
    #endregion

    private void BossItemCheck(int quant = 1, params string[] Items)
    {
        foreach (string item in Items)
        {
            if (Core.CheckInventory(item))
                continue;

            switch (item)
            {
                case "Void Essentia":
                    Item("voidflibbi", "Flibbitiestgibbet", item, quant);
                    break;

                case "Vital Exanima":
                    Adv.GearStore();
                    Core.BossClass();
                    Core.KillMonster("dage", "Boss", "Right", "Dage the Evil", item, isTemp: false);
                    Adv.GearStore(true);
                    break;

                case "Everlight Flame":
                    Adv.GearStore();
                    Core.BossClass();
                    Core.KillMonster("fireavatar", "r9", "Left", "Avatar Tyndarius", item, isTemp: false);
                    Adv.GearStore(true);
                    break;

                case "Calamitous Ruin":
                    if (Core.CheckInventory("Calamitous Ruin"))
                        return;
                    FarmDarkCarnax(!army);
                    break;

                case "The Mortal Coil":
                    Adv.GearStore();
                    Core.DodgeClass();
                    Core.KillMonster("tercessuinotlim", "Boss2", "Right", "Nulgath", item, isTemp: false);
                    Adv.GearStore(true);
                    break;

                case "The Divine Will":
                    Item("celestialpast", "Azalith", item, quant);
                    break;

                case "Insatiable Hunger":
                    Item("voidnightbane", "Nightbane", item, quant);
                    break;

                case "Undying Resolve":
                    Bot.Quests.UpdateQuest(8732);
                    Item("theworld", "Encore Darkon", item, quant);
                    break;

                case "Elemental Binding":
                    Item("archmage", "Prismata", item, quant);
                    break;
            }
        }

        void Item(string map, string monster, string item, int quant)
        {
            if (army)
                Core.HuntMonster(map, monster, item, quant, isTemp: false);
            else Core.Logger($"{item} x{quant} not found, it can be farmed (with an army) from \"{monster}\" in /{map.ToLower()}", stopBot: true);
        }
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
    private void FarmDarkCarnax(bool attemptSolo = true)
    {
        if (Core.CheckInventory("Calamitous Ruin"))
        {
            return;
        }

        Core.FarmingLogger("Calamitous Ruin");
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

        while (!Bot.ShouldExit && !Core.CheckInventory("Calamitous Ruin"))
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




    // Shared fields for movement throttling and async task tracking
    private DateTime lastMove = DateTime.MinValue;
    private readonly TimeSpan moveCooldown = TimeSpan.FromSeconds(2);
    private string currentZone = "";
    private Task? moveTask;

    private readonly string[] RequiredItems = {
        "ArchMage",
        "Providence",
        "Mystic Scribing Kit",
        "Prismatic Ether",
        "Arcane Locus",
        "Unbound Tome",
        "Book of Magus",
        "Book of Fire",
        "Book of Ice",
        "Book of Aether",
        "Book of Arcana",
        "Arcane Sigil",
        "Archmage"
    };
    private readonly string[] BossDrops = {
        "Void Essentia",
        "Vital Exanima",
        "Everlight Flame",
        "Calamitous Ruin",
        "The Mortal Coil",
        "The Divine Will",
        "Insatiable Hunger",
        "Undying Resolve",
        "Elemental Binding"
    };
    private readonly string[] Cosmetics = {
        "Arcane Sigil",
        "Arcane Floating Sigil",
        "Sheathed Archmage's Staff",
        "Archmage's Cowl",
        "Archmage's Cowl and Locks",
        "Archmage's Staff",
        "Archmage's Robes",
        "Divine Mantle",
        "Divine Veil",
        "Divine Veil and Locks",
        "Prismatic Floating Sigil",
        "Sheathed Providence",
        "Prismatic Sigil",
        "Astral Mantle"
    };
    private bool army = false;


}
