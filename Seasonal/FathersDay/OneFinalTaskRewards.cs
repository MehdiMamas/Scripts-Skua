/*
name: OneFinalTaskRewards.cs
description: this script will farm all rewards from quest OneFinalTask in /nursery
tags: horstio, rewards, one, final, task
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/FathersDay/HoratioQuests.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class OneFinaltTask
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static HoratioQuests HQ { get => _HQ ??= new HoratioQuests(); set => _HQ = value; }
    private static HoratioQuests _HQ;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DoQuest();

        Core.SetOptions(true);
    }

    public void DoQuest()
    {
        QuestsIfNeeded();
        AutoReward();
    }
    public void AutoReward(int questID = 6948)
    {
        List<ItemBase> RewardOptions = Core.EnsureLoad(questID).Rewards;

        Bot.Drops.Add(Core.QuestRewards(questID));

        foreach (ItemBase item in RewardOptions)
        {
            while (!Bot.ShouldExit && !Core.CheckInventory(item.ID))
            {
                Core.EnsureAccept(questID);
                Core.HuntMonster("nursery", "Skeletal Minion", "Treasure Found", 10, false, false);
                Core.EnsureComplete(questID, item.ID);
            }
        }
    }

    public void QuestsIfNeeded()
    {
        HQ.Horatio();
    }
}
