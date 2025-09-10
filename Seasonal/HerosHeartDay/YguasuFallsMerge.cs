/*
name: Yguasu Falls Merge
description: This bot will farm the items belonging to the selected mode for the Yguasu Falls Merge [2413] in /yguasu
tags: yguasu, falls, merge, yguasu, vestes, da, rainha, das, ondas, morph, turbante, espírito, mãe, dágua, leque, leques, encantadas, ecantado, bolsa, espelho
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/HerosHeartDay/YguasuFalls.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class YguasuFallsMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
private CoreFarms _Farm;

private CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
private CoreAdvanced _Adv;

private YguasuFalls YguasuFalls
{
    get => _YguasuFalls ??= new YguasuFalls();
    set => _YguasuFalls = value;
}
private YguasuFalls _YguasuFalls;

private static CoreAdvanced sAdv
{
    get => _sAdv ??= new CoreAdvanced();
    set => _sAdv = value;
}
private static CoreAdvanced _sAdv;


    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Lovely Silk", "Bolsa da Mãe D'água", "Espelho da Mãe D'água" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        if (!Core.isSeasonalMapActive("yguasu"))
        {
            Core.Logger("Seasonal map, unavaible.");
            return;
        }
        YguasuFalls.DoStory();

        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("yguasu", 2413, findIngredients, buyOnlyThis, buyMode: buyMode);

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

                case "Lovely Silk":
                    Core.FarmingLogger(req.Name, quant);
                    Core.RegisterQuests(9588);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.EquipClass(ClassType.Farm);
                        Core.KillMonster("yguasu", "r3", "Left", "*", "Giggling Mask", 10, log: false);
                        Core.KillMonster("yguasu", "r4", "Left", "*", "Wolfman Talisman", 10, log: false);

                        Core.EquipClass(ClassType.Solo);
                        Core.KillMonster("yguasu", "r5", "Left", "*", "M'Boi's Throat", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Bolsa da Mãe D'água":
                    Core.EquipClass(ClassType.Solo);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.ID, quant))
                        Core.KillMonster("yguasu", "r5", "Left", "M'Boi", log: false);
                    Bot.Wait.ForPickup(req.ID);
                    break;

                case "Espelho da Mãe D'água":
                    Core.FarmingLogger(req.Name, quant);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.HuntMonsterQuestChoose(9610, 83981,
                        ("canalshore", "Trapped Snack", ClassType.Farm),
                        ("cursedshop", "Ghost Vase", ClassType.Farm),
                        ("terradefesta", "Baron Sunday", ClassType.Solo));
                        Bot.Wait.ForPickup(req.Name);
                    }
                    break;
            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("83970", "Vestes da Rainha das Ondas", "Mode: [select] only\nShould the bot buy \"Vestes da Rainha das Ondas\" ?", false),
        new Option<bool>("83971", "Rainha das Ondas Morph", "Mode: [select] only\nShould the bot buy \"Rainha das Ondas Morph\" ?", false),
        new Option<bool>("83972", "Turbante das Ondas Visage", "Mode: [select] only\nShould the bot buy \"Turbante das Ondas Visage\" ?", false),
        new Option<bool>("83973", "Rainha das Ondas Hair", "Mode: [select] only\nShould the bot buy \"Rainha das Ondas Hair\" ?", false),
        new Option<bool>("83974", "Turbante das Ondas", "Mode: [select] only\nShould the bot buy \"Turbante das Ondas\" ?", false),
        new Option<bool>("83976", "Espírito da Mãe d'água", "Mode: [select] only\nShould the bot buy \"Espírito da Mãe d'água\" ?", false),
        new Option<bool>("83979", "Leque da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Leque da Mãe D'água\" ?", false),
        new Option<bool>("83980", "Leques da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Leques da Mãe D'água\" ?", false),
        new Option<bool>("83984", "Vestes Encantadas da Rainha das Ondas", "Mode: [select] only\nShould the bot buy \"Vestes Encantadas da Rainha das Ondas\" ?", false),
        new Option<bool>("83985", "Turbante Ecantado das Ondas Visage", "Mode: [select] only\nShould the bot buy \"Turbante Ecantado das Ondas Visage\" ?", false),
        new Option<bool>("83986", "Turbante Ecantado das Ondas", "Mode: [select] only\nShould the bot buy \"Turbante Ecantado das Ondas\" ?", false),
        new Option<bool>("83987", "Bolsa Ecantado da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Bolsa Ecantado da Mãe D'água\" ?", false),
        new Option<bool>("83988", "Bolsa Ecantado da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Bolsa Ecantado da Mãe D'água\" ?", false),
        new Option<bool>("83989", "Leque Ecantado da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Leque Ecantado da Mãe D'água\" ?", false),
        new Option<bool>("83990", "Leques Ecantado da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Leques Ecantado da Mãe D'água\" ?", false),
        new Option<bool>("83991", "Espelho Ecantado da Mãe D'água", "Mode: [select] only\nShould the bot buy \"Espelho Ecantado da Mãe D'água\" ?", false),
    };
}
