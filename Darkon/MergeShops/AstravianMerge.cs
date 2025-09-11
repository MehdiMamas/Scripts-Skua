/*
name: Astravian Merge
description: This bot will farm the items belonging to the selected mode for the Astravian Merge [1987] in /astravia
tags: astravian, merge, astravia, gold, voucher, k, moons, amalgamation, hallowed, cloak, officer, officers, , carltons, taliss, kaspers, rosas, mercenarys, boomstick, karmic, battlegear, urban, duelist, morph, rebel, katana, katanas, reversed, sheath, sheathe
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Darkon/CoreDarkon.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class AstravianMerge
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;
public static CoreAdvanced sAdv
{
    get => _sAdv ??= new CoreAdvanced();
    set => _sAdv = value;
}
public static CoreAdvanced _sAdv;

    private static CoreDarkon Darkon { get => _Darkon ??= new CoreDarkon(); set => _Darkon = value; }    private static CoreDarkon _Darkon;
    private static CoreAstravia Astravia { get => _Astravia ??= new CoreAstravia(); set => _Astravia = value; }
    private static CoreAstravia _Astravia;

    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(new[] { "The Moon's Head", "La's Gratitude", "The Moon's Cloak", "Astravian Sickle", "Astravian Urban Duelist Locks", "Astravian Urban Duelist Hair", "Sheathed Urban Duelist Katana", "Urban Duelist Katana and Sheath", "Condensed Aversion" });
        Core.SetOptions();

        BuyAllMerge();

        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        Astravia.Astravia();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("astravia", 1987, findIngredients, buyOnlyThis, buyMode: buyMode);

        #region Dont edit this part
        void findIngredients()
        {
            ItemBase req = Adv.externalItem;
            int quant = Adv.externalQuant;
            int currentQuant = req.Temp ? Bot.TempInv.GetQuantity(req.Name) : Bot.Inventory.GetQuantity(req.Name);
            if (req == null)
            {
                Core.Logger("req is NULL");
                return;
            }

            switch (req.Name)
            {
                default:
                    bool shouldStop = !Adv.matsOnly || !dontStopMissingIng;
                    Core.Logger($"The bot hasn't been taught how to get {req.Name}." + (shouldStop ? " Please report the issue." : " Skipping"), messageBox: shouldStop, stopBot: shouldStop);
                    break;
                #endregion

                case "La's Gratitude":
                    Darkon.LasGratitude(quant);
                    break;

                case "The Moon's Head":
                case "The Moon's Cloak":
                    Core.HuntMonster("astravia", "The Moon", req.Name, isTemp: false);
                    break;

                case "Astravian Sickle":
                case "Sheathed Urban Duelist Katana":
                case "Urban Duelist Katana and Sheath":
                case "Condensed Aversion":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.HuntMonster("astravia", "Creature 28", req.Name, quant, false, false);
                    break;

                case "Astravian Urban Duelist Locks":
                case "Astravian Urban Duelist Hair":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.HuntMonster("astravia", "Creature 27", req.Name, quant, false, false);
                    break;
            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("60172", "The Moon's Amalgamation", "Mode: [select] only\nShould the bot buy \"The Moon's Amalgamation\" ?", false),
        new Option<bool>("60175", "The Moon's Hallowed Cloak", "Mode: [select] only\nShould the bot buy \"The Moon's Hallowed Cloak\" ?", false),
        new Option<bool>("60156", "Astravian Officer", "Mode: [select] only\nShould the bot buy \"Astravian Officer\" ?", false),
        new Option<bool>("60166", "Astravian Officer's Hat + Locks", "Mode: [select] only\nShould the bot buy \"Astravian Officer's Hat + Locks\" ?", false),
        new Option<bool>("60165", "Astravian Officer's Hat", "Mode: [select] only\nShould the bot buy \"Astravian Officer's Hat\" ?", false),
        new Option<bool>("60161", "Carlton's Hair", "Mode: [select] only\nShould the bot buy \"Carlton's Hair\" ?", false),
        new Option<bool>("60164", "Talis's Hair", "Mode: [select] only\nShould the bot buy \"Talis's Hair\" ?", false),
        new Option<bool>("60162", "Kasper's Hair", "Mode: [select] only\nShould the bot buy \"Kasper's Hair\" ?", false),
        new Option<bool>("60163", "Rosa's Hair", "Mode: [select] only\nShould the bot buy \"Rosa's Hair\" ?", false),
        new Option<bool>("58078", "Astravian Mercenary's Dagger", "Mode: [select] only\nShould the bot buy \"Astravian Mercenary's Dagger\" ?", false),
        new Option<bool>("58082", "Astravia Mercenary's Boomstick", "Mode: [select] only\nShould the bot buy \"Astravia Mercenary's Boomstick\" ?", false),
        new Option<bool>("58079", "Karmic Battlegear", "Mode: [select] only\nShould the bot buy \"Karmic Battlegear\" ?", false),
        new Option<bool>("84267", "Astravian Urban Duelist", "Mode: [select] only\nShould the bot buy \"Astravian Urban Duelist\" ?", false),
        new Option<bool>("84271", "Astravian Urban Duelist Visage", "Mode: [select] only\nShould the bot buy \"Astravian Urban Duelist Visage\" ?", false),
        new Option<bool>("84270", "Astravian Urban Duelist Morph", "Mode: [select] only\nShould the bot buy \"Astravian Urban Duelist Morph\" ?", false),
        new Option<bool>("84275", "Urban Duelist Rebel Katana", "Mode: [select] only\nShould the bot buy \"Urban Duelist Rebel Katana\" ?", false),
        new Option<bool>("84276", "Urban Duelist Rebel Katanas", "Mode: [select] only\nShould the bot buy \"Urban Duelist Rebel Katanas\" ?", false),
        new Option<bool>("84277", "Reversed Urban Duelist Rebel Katana", "Mode: [select] only\nShould the bot buy \"Reversed Urban Duelist Rebel Katana\" ?", false),
        new Option<bool>("84278", "Reversed Urban Duelist Rebel Katanas", "Mode: [select] only\nShould the bot buy \"Reversed Urban Duelist Rebel Katanas\" ?", false),
        new Option<bool>("84279", "Urban Duelist Rebel Katana and Sheath", "Mode: [select] only\nShould the bot buy \"Urban Duelist Rebel Katana and Sheath\" ?", false),
        new Option<bool>("84280", "Urban Duelist Rebel Sheathe and Katana", "Mode: [select] only\nShould the bot buy \"Urban Duelist Rebel Sheathe and Katana\" ?", false),
    };
}

