/*
name: Thelima Jewelers Merge
description: This bot will farm the items belonging to the selected mode for the Thelima Jewelers Merge [2616] in /thelimacity
tags: thelima, jewelers, merge, thelimacity, custom, gem, vert, vitriol, emerald, emile, melano, amethyst, catalyst
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/AgeOfRuin/CoreAOR.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class ThelimaJewelersMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private static CoreAdvanced sAdv = new();
    private CoreAOR AOR = new();

    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Mystic Topaz", "Dwarven Gold", "Maleno Obsidian", "Drow Silver", "Dwarven Emerald", "Drow Amethyst" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        AOR.ThelimaCity();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("thelimacity", 2616, findIngredients, buyOnlyThis, buyMode: buyMode);

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

                #region Items not setup

                case "Mystic Topaz":
                    if (req.Upgrade && !Core.IsMember)
                    {
                        Core.Logger($"{req.Name} requires membership to farm, skipping.");
                        return;
                    }

                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.AddDrop(req.ID);
                    Core.HuntMonster("thelimacity", "Noelle Knight", req.Name, quant, false, false);
                    break;


                case "Dwarven Gold":
                case "Dwarven Emerald":
                    if (req.Upgrade && !Core.IsMember)
                    {
                        Core.Logger($"{req.Name} requires membership to farm, skipping.");
                        return;
                    }

                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.AddDrop(req.ID);
                    Core.HuntMonster("thelimacity", "Dwarven Aegis", req.Name, quant, false, false);
                    break;


                case "Maleno Obsidian":
                    if (req.Upgrade && !Core.IsMember)
                    {
                        Core.Logger($"{req.Name} requires membership to farm, skipping.");
                        return;
                    }

                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Solo);
                    Core.AddDrop(req.ID);
                    Core.HuntMonster("thelimacity", "Maleno Elemental", req.Name, quant, false, false);
                    break;


                case "Drow Silver":
                case "Drow Amethyst":
                    if (req.Upgrade && !Core.IsMember)
                    {
                        Core.Logger($"{req.Name} requires membership to farm, skipping.");
                        return;
                    }

                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.AddDrop(req.ID);
                    Core.HuntMonster("thelimacity", "Drow Soldier", req.Name, quant, false, false);
                    break;
                    #endregion

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("93124", "Custom Gem Dagger", "Mode: [select] only\nShould the bot buy \"Custom Gem Dagger\" ?", false),
        new Option<bool>("93125", "Custom Gem Daggers", "Mode: [select] only\nShould the bot buy \"Custom Gem Daggers\" ?", false),
        new Option<bool>("93380", "Vert Vitriol Dagger", "Mode: [select] only\nShould the bot buy \"Vert Vitriol Dagger\" ?", false),
        new Option<bool>("93381", "Vert Vitriol Daggers", "Mode: [select] only\nShould the bot buy \"Vert Vitriol Daggers\" ?", false),
        new Option<bool>("93385", "Emerald Emile", "Mode: [select] only\nShould the bot buy \"Emerald Emile\" ?", false),
        new Option<bool>("93386", "Melano Amethyst Catalyst", "Mode: [select] only\nShould the bot buy \"Melano Amethyst Catalyst\" ?", false),
   };
}
