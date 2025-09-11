/*
name: BloodWarLycanMerge
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/BloodMoon.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class BloodWarLycanMerge
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;
public static CoreAdvanced sAdv
{
    get => _sAdv ??= new CoreAdvanced();
    set => _sAdv = value;
}
public static CoreAdvanced _sAdv;


    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    private static BloodMoon BloodMoonQuests { get => _BloodMoonQuests ??= new BloodMoon(); set => _BloodMoonQuests = value; }    private static BloodMoon _BloodMoonQuests;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        BuyAllMerge();

        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        BloodMoonQuests.BloodMoonSaga();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("bloodwarlycan", 1488, findIngredients, buyOnlyThis, buyMode: buyMode);
        #region Dont edit this part
        void findIngredients()
        {
            ItemBase req = Adv.externalItem;
            int quant = Adv.externalQuant;
            int currentQuant = req.Temp ? Bot.TempInv.GetQuantity(req.ID) : Bot.Inventory.GetQuantity(req.ID);
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

                case "Sapphires":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(6070, 6071, 6073);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.ID, quant))
                    {
                        Core.HuntMonster("bloodwarlycan", "Blood Guardian", "Vampire Medal", 5, log: false);
                        Core.HuntMonster("bloodwarlycan", "Blood Guardian", "Mega Vampire Medal", 3, log: false);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Rubies":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(6068, 6069, 6072);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.ID, quant))
                    {
                        Core.HuntMonster("bloodwarvamp", "Lunar Blazebinder", "Lycan Medal", 5, log: false);
                        Core.HuntMonster("bloodwarvamp", "Lunar Blazebinder", "Mega Lycan Medal", 3, log: false);
                    }
                    Core.CancelRegisteredQuests();
                    break;

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("41788", "Alpha Lycan Surfboard", "Mode: [select] only\nShould the bot buy \"Alpha Lycan Surfboard\" ?", false),
        new Option<bool>("41789", "Lunar Blaze Surfboard", "Mode: [select] only\nShould the bot buy \"Lunar Blaze Surfboard\" ?", false),
        new Option<bool>("41711", "Werepyre Warrior", "Mode: [select] only\nShould the bot buy \"Werepyre Warrior\" ?", false),
        new Option<bool>("41712", "Werepyre Morph", "Mode: [select] only\nShould the bot buy \"Werepyre Morph\" ?", false),
        new Option<bool>("41713", "Werepyre Wings", "Mode: [select] only\nShould the bot buy \"Werepyre Wings\" ?", false),
        new Option<bool>("41714", "Werepyre Warrior Blade", "Mode: [select] only\nShould the bot buy \"Werepyre Warrior Blade\" ?", false),
        new Option<bool>("41787", "Weretato Pet", "Mode: [select] only\nShould the bot buy \"Weretato Pet\" ?", false),
    };
}
