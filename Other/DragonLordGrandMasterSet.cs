/*
name: DragonLord Grand Master
description: farms the "DragonLord Grand Master" set from Quest: "The Flame Dragon".
tags: dragonlord grand master, set
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/VasalkarLairWar.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class DragonLordGrandMasterSet
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public LairWar War
{
    get => _War ??= new LairWar();
    set => _War = value;
}
public LairWar _War;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetSet();

        Core.SetOptions(false);
    }

    public void GetSet()
    {
        string[] rewards = Core.EnsureLoad(6689).Rewards.Select(i => i.Name).ToArray();
        if (Core.CheckInventory(rewards))
            return;

        int count = 0;
        Core.CheckSpaces(ref count, rewards);
        Core.AddDrop(rewards);
        War.Defend();

        Core.RegisterQuests(6689);
        Bot.Events.ItemDropped += ItemDropped;
        Core.Logger($"Farm for the DragonLord GrandMaster set started. Farming to get {rewards.Length - count} more item" + ((rewards.Length - count) > 1 ? "s" : ""));

        while (!Core.CheckInventory(rewards))
        {
            Core.KillMonster("lairdefend", "Eggs", "Left", "Flame Dragon General", log: false);
            Bot.Wait.ForPickup("*");
        }

        Bot.Events.ItemDropped -= ItemDropped;
        Core.CancelRegisteredQuests();

        void ItemDropped(ItemBase item, bool addedToInv, int quantityNow)
        {
            if (rewards.Contains(item.Name))
            {
                count++;
                Core.Logger($"Got {item.Name}, {rewards.Length - count} items to go");
            }
        }
    }
}
