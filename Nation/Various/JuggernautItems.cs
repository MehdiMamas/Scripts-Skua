/*
name: JuggernautItems
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Quests;
using Skua.Core.Options;

public class JuggernautItemsofNulgath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;



    public string OptionsStorage = "Reward Select";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<RewardsSelection>("RewardsSelection", "Select Your Quest Reward", "Select Your Quest Reward for The JuggerNaught items of Nulgath quest.", RewardsSelection.Oblivion_of_Nulgath),
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.BankingBlackList.AddRange(Rewards);
        Core.SetOptions();

        JuggItems(Bot.Config?.Get<RewardsSelection>("RewardsSelection") ?? default);

        Core.SetOptions(false);
    }

    public void JuggItems(RewardsSelection reward = RewardsSelection.All)
    {
        Core.AddDrop(Nation.bagDrops);
        Core.AddDrop(Rewards);

        var Count = 0;
        int x = 1;


        List<ItemBase> RewardOptions = Core.EnsureLoad(837).Rewards;
        List<string> RewardsList = new();
        foreach (Skua.Core.Models.Items.ItemBase Item in RewardOptions)
            RewardsList.Add(Item.Name);
        Count = RewardsList.Count;
        var rewards = Core.EnsureLoad(837).Rewards;
        ItemBase? item = rewards.Find(x => x.ID == (int)reward) ?? null;
        int defaultId = 0;
        int itemId = item?.ID ?? defaultId;
        while (!Bot.ShouldExit &&
                (reward == RewardsSelection.All ?
                    !Core.CheckInventory(rewards.Select(x => x.Name).ToArray(), toInv: false) :
                    !Core.CheckInventory(itemId, toInv: false)
                )
              )
        {
            if (reward == RewardsSelection.All)
                Core.Logger($"Farming All {x++}/{Count}");
            else Core.Logger($"... {reward} ...");

            Nation.FarmUni13(1);
            Core.EnsureAccept(837);
            Nation.FarmDiamondofNulgath(13);
            Nation.FarmDarkCrystalShard(50);
            Nation.FarmTotemofNulgath(3);
            Nation.FarmGemofNulgath(20);
            Nation.FarmVoucher(false);
            Nation.SwindleBulk(50);
            Core.HuntMonster("underworld", "Undead Bruiser", "Undead Bruiser Rune");

            if (Bot.Config?.Get<RewardsSelection>("RewardsSelection") == RewardsSelection.All)
                Core.EnsureCompleteChoose(837);
            else Core.EnsureComplete(837, (int)reward);
        }
    }

    public readonly string[] Rewards =
    {
        "Oblivion of Nulgath",
        "Ungodly Reavers of Nulgath",
        "Warlord of Nulgath",
        "Arcane of Nulgath",
        "Dimensional Champion of Nulgath",
        "Crystal Phoenix Blade of Nulgath",
        "Overfiend Blade of Nulgath",
        "Battlefiend Blade of Nulgath",
        "Dark Makai of Nulgath",
        "Nulgath Armor",
        "Polish Hussar",
        "Polish Hussar Helm",
        "Polish Hussar Spear",
        "Polish Hussar Wings",
        "Void Cowboy",
        "Void Cowboy Hat",
        "Void Cowboy Morph",
        "Void Cowboy's Mask + Locks",
        "Void Cowboy's Pistol",
        "Dual Void Cowboy Pistols"
    };

    public enum RewardsSelection
    {
        Oblivion_of_Nulgath = 2232,
        Ungodly_Reavers_of_Nulgath = 4939,
        Warlord_of_Nulgath = 5527,
        Arcane_of_Nulgath = 5530,
        Dimensional_Championof_Nulgath = 5531,
        Crystal_Phoenix_Blade_of_Nulgath = 6137,
        Overfiend_Blade_of_Nulgath = 6138,
        Battlefiend_Blade_of_Nulgath = 6141,
        Dark_Makaiof_Nulgath = 6142,
        Nulgath_Armor = 6375,
        Polish_Hussar = 42596,
        Polish_Hussar_Helm = 42597,
        Polish_Hussar_Spear = 42598,
        Polish_Hussar_Wings = 42599,
        Void_Cowboy = 52799,
        Void_CowboyHat = 52800,
        Void_CowboyMorph = 52801,
        Void_Cowboys_Mask_Locks = 52802,
        Void_Cowboy_Pistol = 52803,
        Dual_Void_Cowboy_Pistols = 52818,
        All
    };
}
