/*
name: Hikaru Quest Rewards
description: farms quest rewards from `Hit List` in /lostvilla
tags: lostvilla, Hikaru, quest rewards, diabolical shadowhunter, diabolical,shadow hunter, hit list, hitlist
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Banished.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
//cs_include Scripts/Story/LostVilla.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class DiabolicalShadowHunterSet
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private LostVilla LV = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetRewards();

        Core.SetOptions(false);
    }

    int QuestID = 10053;

    public void GetRewards()
    {

        LV.Storyline();
        List<ItemBase> RewardOptions = Core.EnsureLoad(QuestID).Rewards;

        foreach (ItemBase item in RewardOptions)
            Core.AddDrop(item.Name);

        Core.EquipClass(ClassType.Farm);

        foreach (ItemBase Reward in RewardOptions)
        {
            if (Core.CheckInventory(Reward.Name, toInv: false))
                return;

            Core.Logger(Core.CheckInventory(Reward.ID, toInv: false) ? $"{Reward.Name}: ✅" : $"{Reward.Name} ❌");

            Core.FarmingLogger(Reward.Name, 1);
            while (!Bot.ShouldExit && !Core.CheckInventory(Reward.ID))
                Core.HuntMonsterQuest(10053, new[] {
    ("brokenwoods", "Eldritch Amalgamation",ClassType.Solo),
    ("backroom", "Book Wyrm",ClassType.Solo),
    ("lostvilla", "Eldritch Parasite",ClassType.Solo),
    ("lostvilla", "Covetous Disgrace",ClassType.Solo),
    ("lostvilla", "Mutilated Atrocity",ClassType.Farm)
});

            Core.JumpWait();
            Core.ToBank(Reward.Name);
        }
    }
}
