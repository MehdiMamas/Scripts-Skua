/*
name: Duplication Error Badge Merge
description: This bot will farm the items belonging to the selected mode for the Duplication Error Badge Merge [2426] in /ebilart
tags: duplication, error, badge, merge, ebilart, ai, oh, no, miko, guest, , ultimate
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/AprilFools/EbilArt.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class DuplicationErrorBadgeMerge
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

private static CoreAdvanced sAdv
{
    get => _sAdv ??= new CoreAdvanced();
    set => _sAdv = value;
}
private static CoreAdvanced _sAdv;

private EbilArt EA
{
    get => _EA ??= new EbilArt();
    set => _EA = value;
}
private EbilArt _EA;


    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Duplication Error" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        if (!Core.isSeasonalMapActive("ebilart"))
            return;

        EA.StoryLine();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("ebilart", 2426, findIngredients, buyOnlyThis, buyMode: buyMode);

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

                case "Duplication Error":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Solo);
                    Core.HuntMonster("ebilart", "Ebil AI Blender", req.Name, quant, false, false);
                    break;

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("85094", "AI (Oh No!) Miko Guest 0.0", "Mode: [select] only\nShould the bot buy \"AI (Oh No!) Miko Guest 0.0\" ?", false),
        new Option<bool>("85095", "AI (Oh No!) Miko Guest 1.0", "Mode: [select] only\nShould the bot buy \"AI (Oh No!) Miko Guest 1.0\" ?", false),
        new Option<bool>("85096", "AI (Oh No!) Miko Guest 2.0", "Mode: [select] only\nShould the bot buy \"AI (Oh No!) Miko Guest 2.0\" ?", false),
        new Option<bool>("85097", "AI (Oh No!) Miko Guest 3.0", "Mode: [select] only\nShould the bot buy \"AI (Oh No!) Miko Guest 3.0\" ?", false),
        new Option<bool>("85098", "AI (Oh No!) Miko Guest 4.0", "Mode: [select] only\nShould the bot buy \"AI (Oh No!) Miko Guest 4.0\" ?", false),
        new Option<bool>("85099", "ULTIMATE AI (Oh No!) Miko Guest", "Mode: [select] only\nShould the bot buy \"ULTIMATE AI (Oh No!) Miko Guest\" ?", false),
    };
}
