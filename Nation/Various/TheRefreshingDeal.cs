/*
name: The Refreshing Deal
description: This script farms Gems and Totems of Nulgath using "The Refreshing Deal" Quest.
tags: refreshing, deal, gem, totem, nulgath, nation, crag, bamboozle, quest
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/Various/PurifiedClaymoreOfDestiny.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class TheRefreshingDeal
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreNation Nation = new();
    public PurifiedClaymoreOfDestiny PCoD = new();

    public string OptionsStorage = "RefreshingDeal";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<int>("GemQuantity", "How many Gems of Nulgath?","Max Stack is 1000", 1000),
        new Option<int>("TotemQuantity", "How many Totems of Nulgath?","Max Stack is 100", 100),
        new Option<bool>("BankItems", "Bank nation items at the end", "true/false", false),
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        Nation.Deal(Bot.Config!.Get<int>("GemQuantity"), Bot.Config.Get<int>("TotemQuantity"));

        Core.SetOptions(false);
    }
}

