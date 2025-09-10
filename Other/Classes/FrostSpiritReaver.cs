/*
name: FrostSpiritReaver
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class FrostSpiritReaver
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public GlaceraStory Glacera
{
    get => _Glacera ??= new GlaceraStory();
    set => _Glacera = value;
}
public GlaceraStory _Glacera;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreDailies Dailies
{
    get => _Dailies ??= new CoreDailies();
    set => _Dailies = value;
}
public CoreDailies _Dailies;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetFSR();

        Core.SetOptions(false);
    }

    public void GetFSR(bool rankUpClass = true)
    {
        if (Core.CheckInventory(59178))
            return;

        Glacera.DoAll();
        Farm.GlaceraREP();
        Dailies.Cryomancer();
        if (!Core.CheckInventory("Cryomancer") && !Core.CheckInventory("Frost Sigil"))
        {
            Core.Logger("Cryomancer Required for \"Frost Sigil\" for \"IceNinth\", Comeback tomarrow.");
            return;
        }
        Farm.Experience(60);


        if (!Core.CheckInventory("Envoy of Kyanos"))
        {
            if (!Core.CheckInventory("Envoy of Kyanos"))
                Core.Logger("Getting Quest Item Requirements for \"Ice See You\"");

            if (!Core.CheckInventory("Favored of Kyanos"))
            {
                Core.Logger("Farming the requirements to buy \"Favored of Kyanos\"");
                Core.HuntMonster("icedungeon", "Shade of Kyanos", "Warrior of Kyanos", isTemp: false);
                Tokens(25, 15, 10, 5);

                Adv.BuyItem("icedungeon", 1948, "Favored of Kyanos");
            }
            Core.Logger("Farming the requirements to buy \"Envoy of Kyanos\"");
            Tokens(50, 30, 20, 10);

            Adv.BuyItem("icedungeon", 1948, "Envoy of Kyanos");
        }

        IceNinth(9);
        GlaceranAttunement(15);
        Core.AddDrop("Frost SpiritReaver");
        Core.ChainComplete(7922);
        Bot.Wait.ForPickup("Frost SpiritReaver");

        if (rankUpClass)
            Adv.RankUpClass("Frost SpititReaver");
    }

    //Cold Hearted
    public void IceNinth(int quant)
    {
        if (Core.CheckInventory("Ice-Ninth", quant))
            return;

        Core.AddDrop("Ice-Ninth", "Ice Diamond");
        Core.FarmingLogger("Ice-Ninth", quant);

        //////////////////////////////////////////////
        //////////////////////////////////////////////
        #region "Quest Prerequisites 

        if (!Core.CheckInventory(25464) && Core.CheckInventory(new[] { 27437, 27525 }, any: true))
        {
            //Frost Sigil
            Core.BuyItem("icedungeon", Core.CheckInventory(27437) ? 2294 : 2295, 25464, shopItemID: Core.CheckInventory(27437) ? 48001 : 48002);
            Core.ToBank(27437, 27525);
        }

        Core.RegisterQuests(3955);
        while (!Bot.ShouldExit && !Core.CheckInventory("Flame of Courage", 25))
        {
            Core.AddDrop("Flame of Courage");
            Core.HuntMonster("frozenruins", "Frost Invader", "Spark of Courage", log: false);
            Bot.Wait.ForPickup("Flame of Courage");
        }
        Core.CancelRegisteredQuests();
        Core.ToBank("Frozen Tower Merge Token");

        //cryomancer unbank
        if (!Core.CheckInventory("Fallen Scythe of Vengeance"))
        {
            Core.Logger("Getting the quest item requirements for \"Cold Hearted\"");
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("Northstar", "Karok The Fallen", "Karok's Glaceran Gem", isTemp: false);
            Adv.BuyItem("Glacera", 1055, "Scythe of Vengeance");
            Adv.BuyItem("Glacera", 1055, "Cold Scythe of Vengeance");
            Adv.BuyItem("Glacera", 1055, "Frigid Scythe of Vengeance");
            Adv.BuyItem("Glacera", 1055, "Fallen Scythe of Vengeance");
        }

        #endregion "Quest Prerequisites 
        //////////////////////////////////////////////
        //////////////////////////////////////////////


        while (!Bot.ShouldExit && !Core.CheckInventory("Ice-Ninth", quant))
        {
            Core.EnsureAccept(7920);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("Snowmore", "Jon S'NOOOOOOO", "Northern Crown", isTemp: false);

            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("icestormarena", "Arctic Wolf", "Ice Needle", 30, isTemp: false);
            Core.AddDrop("Ice Diamond");
            Core.FarmingLogger("Ice Diamond", 100);
            while (!Bot.ShouldExit && !Core.CheckInventory("Ice Diamond", 100))
            {
                Core.EnsureAccept(7279);
                Core.KillMonster("kingcoal", "r1", "Left", "*", "Frozen Coal", 10, log: false);
                Core.EnsureComplete(7279);
                Bot.Wait.ForPickup("Ice Diamond");
            }
            Core.EnsureComplete(7920);
            Bot.Wait.ForPickup("Ice-Ninth");
        }
        Core.ToBank(Core.QuestRewards(7920));
        Core.Unbank("Ice-Ninth");
    }

    //Cold Blooded
    public void GlaceranAttunement(int quant)
    {
        if (Core.CheckInventory("Glaceran Attunement", quant))
            return;

        //to unlock the quest
        if (!Core.isCompletedBefore(7921))
        {
            Core.Logger("Doing prerequisets for \"Cold Blooded\" [1x \"Ice Ninth\"]");
            IceNinth(1);
        }

        Farm.GlaceraREP();
        if (!Core.CheckInventory(39011))
        {
            //FrostSlayer
            Core.Logger("Getting the quest item required to start \"Cold Blooded\"");
            Core.AddDrop(39011);
            Core.EquipClass(ClassType.Solo);
            while (!Bot.ShouldExit && !Core.CheckInventory(39011))
            {
                Core.HuntMonster("iceplane", "Enfield", "FrostSlayer", 1, false, false);
            }
        }
        else Core.Logger("Got the Item requirement for \"Cold Blooded\"");

        Core.AddDrop(59216);
        Core.FarmingLogger("Glaceran Attunement", quant);
        Core.RegisterQuests(7921);
        while (!Bot.ShouldExit && !Core.CheckInventory(59216, quant))
        {
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("cryowar", "Super-Charged Karok", "Glacial Crystal", 100, isTemp: false, log: false);
            Core.HuntMonster("frozenlair", "Legion Lich Lord", "Necrotic Orb", 2, isTemp: false, log: false);

            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("frozenlair", "Frozen Legionnaire", "Ice Spike", 20, isTemp: false, log: false);
            Core.HuntMonster("frozenlair", "Frozen Legionnaire", "Ice Splinter", 20, isTemp: false, log: false);
        }
        Bot.Wait.ForPickup("Glaceran Attunement");
        Core.CancelRegisteredQuests();
        Core.ToBank(Core.QuestRewards(7921));
        Core.Unbank(59216);
    }

    public void Tokens(int Token1 = 300, int Token2 = 300, int Token3 = 300, int Token4 = 300)
    {
        if (!Core.CheckInventory("Icy Token I", Token1))
        {
            Core.AddDrop("Icy Token I");
            Core.FarmingLogger("Icy Token I", Token1);
            Core.EquipClass(ClassType.Farm);

            Core.RegisterQuests(7840, 7838);
            while (!Bot.ShouldExit && !Core.CheckInventory("Icy Token I", Token1))
            {
                Core.HuntMonster("icedungeon", "Frosted Banshee", "Frosted Banshee Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Frozen Undead", "Frozen Undead Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Ice Symbiote", "Ice Symbiote Defeated", 10, log: false);
            }
            Core.CancelRegisteredQuests();
        }

        if (!Core.CheckInventory("Icy Token II", Token2))
        {
            Core.AddDrop("Icy Token II");
            Core.FarmingLogger("Icy Token II", Token2);
            Core.EquipClass(ClassType.Farm);

            Core.RegisterQuests(7839);
            while (!Bot.ShouldExit && !Core.CheckInventory("Icy Token II", Token2))
            {
                Core.HuntMonster("icedungeon", "Spirit of Ice", "Spirit of Ice Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Ice Crystal", "Ice Crystal Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Frigid Spirit", "Frigid Spirit Defeated", 10, log: false);

                Bot.Wait.ForPickup("Icy Token II");
            }
            Core.CancelRegisteredQuests();
        }

        if (!Core.CheckInventory("Icy Token III", Token3))
        {
            Core.AddDrop("Icy Token III");
            Core.FarmingLogger("Icy Token III", Token3);
            Core.EquipClass(ClassType.Farm);

            Core.RegisterQuests(7840);
            while (!Bot.ShouldExit && !Core.CheckInventory("Icy Token III", Token3))
            {
                Core.HuntMonster("icedungeon", "Living Ice", "Living Ice Defeated", 5, log: false);
                Core.HuntMonster("icedungeon", "Crystallized Elemental", "Crystallized Elemental Defeated", 5, log: false);
                Core.HuntMonster("icedungeon", "Frozen Demon", "Frozen Demon Defeated", 5, log: false);

                Bot.Wait.ForPickup("Icy Token III");
            }
            Core.CancelRegisteredQuests();
        }

        if (!Core.CheckInventory("Icy Token IV", Token4))
        {
            Core.AddDrop("Icy Token IV");
            Core.FarmingLogger("Icy Token IV", Token4);
            Core.EquipClass(ClassType.Solo);

            Core.RegisterQuests(7841);
            while (!Bot.ShouldExit && !Core.CheckInventory("Icy Token IV", Token4))
            {
                Core.HuntMonster("icedungeon", "Image of Glace", "Glace's Approval", log: false);
                Core.HuntMonster("icedungeon", "Abel", "Abel's Approval", log: false);
                Core.HuntMonster("icedungeon", "Shade of Kyanos", "Kyanos' Approval", log: false);

                Bot.Wait.ForPickup("Icy Token IV");
            }
            Core.CancelRegisteredQuests();
        }
    }
}
