/*
name: Harleys Merge
description: This bot will farm the items belonging to the selected mode for the Harleys Merge [2572] in /trainers
tags: harleys, merge, trainers, battleon, warlord, grizzled, eyepatch, scarred, banner, cloak, warbeast, armaments
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/TrainersStory.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class HarleysMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private static CoreAdvanced sAdv = new();

    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Harley's Reinforced Steel" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("trainers", 2572, findIngredients, buyOnlyThis, buyMode: buyMode);

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

                case "Harley's Reinforced Steel":


                    if (!Core.CheckInventory(new[] { "ArchPaladin", "Chaos Avenger" }, any: true))
                    {
                        Core.Logger("You need to have the ArchPaladin or Chaos Avenger class to farm this item... good luck killing it", "**WARNING**");
                        Core.EquipClass(ClassType.Solo);
                    }
                    else
                    {
                        foreach (string ClassName in new[] { "Chaos Avenger", "ArchPaladin" })
                        {
                            if (Core.CheckInventory(ClassName))
                            {
                                Core.Unbank(ClassName);
                                Core.Equip(ClassName);
                                Core.Logger($"Using {ClassName} for farming Harley's Reinforced Steel");
                                break;
                            }
                            continue;
                        }
                    }
                    Core.FarmingLogger(req.Name, quant);
                    Core.RegisterQuests(10177);
                    Core.KillMonster("trainers", "r3", "Left", "Warlord Harley", req.Name, req.Quantity);
                    Bot.Wait.ForPickup(req.Name);
                    Core.CancelRegisteredQuests();
                    break;

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("91591", "Battleon Warlord", "Mode: [select] only\nShould the bot buy \"Battleon Warlord\" ?", false),
        new Option<bool>("91592", "Grizzled Warlord Eyepatch", "Mode: [select] only\nShould the bot buy \"Grizzled Warlord Eyepatch\" ?", false),
        new Option<bool>("91593", "Grizzled Warlord Eyepatch Locks", "Mode: [select] only\nShould the bot buy \"Grizzled Warlord Eyepatch Locks\" ?", false),
        new Option<bool>("91594", "Battleon Warlord Eyepatch", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Eyepatch\" ?", false),
        new Option<bool>("91595", "Battleon Warlord Eyepatch Locks", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Eyepatch Locks\" ?", false),
        new Option<bool>("91596", "Battleon Warlord Hair", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Hair\" ?", false),
        new Option<bool>("91597", "Battleon Warlord Locks", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Locks\" ?", false),
        new Option<bool>("91598", "Grizzled Battleon Warlord Hair", "Mode: [select] only\nShould the bot buy \"Grizzled Battleon Warlord Hair\" ?", false),
        new Option<bool>("91599", "Battleon Warlord Scarred Locks", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Scarred Locks\" ?", false),
        new Option<bool>("91600", "Battleon Warlord Banner", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Banner\" ?", false),
        new Option<bool>("91601", "Battleon Warlord Cape", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Cape\" ?", false),
        new Option<bool>("91602", "Battleon Warlord Banner Cloak", "Mode: [select] only\nShould the bot buy \"Battleon Warlord Banner Cloak\" ?", false),
        new Option<bool>("91603", "Battleon Warbeast Blade", "Mode: [select] only\nShould the bot buy \"Battleon Warbeast Blade\" ?", false),
        new Option<bool>("91604", "Battleon Warbeast Blades", "Mode: [select] only\nShould the bot buy \"Battleon Warbeast Blades\" ?", false),
        new Option<bool>("91605", "Battleon Warbeast Axe", "Mode: [select] only\nShould the bot buy \"Battleon Warbeast Axe\" ?", false),
        new Option<bool>("91606", "Battleon Warbeast Axes", "Mode: [select] only\nShould the bot buy \"Battleon Warbeast Axes\" ?", false),
        new Option<bool>("92773", "Battleon Warbeast Armaments", "Mode: [select] only\nShould the bot buy \"Battleon Warbeast Armaments\" ?", false),
    };
}
