/*
name: Image of Nulgath
description: This script will farm the "Image of Nulgath" quest rewards.
tags: image of nulgath,nulgath gifts,Fiendish Zweihander Blade, fiendish,zweihandler,Fiendish Zweihander of Bhamud,bhamud
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation\Various\JuggernautItems.cs
//cs_include Scripts/Seasonal/StaffBirthdays/Nulgath/TempleSiege.cs
//cs_include Scripts/Seasonal\StaffBirthdays\Nulgath\TempleDelve.cs
//cs_include Scripts/Story/Nation/VoidRefuge.cs
//cs_include Scripts/Story\Nation\VoidChasm.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class ImageOfNulgath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreNation Nation = new();
    public CoreAdvanced Adv = new();
    private JuggernautItemsofNulgath Jug = new();
    private TempleDelve TD = new();
    private VoidChasm VC = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetRewards();

        Core.SetOptions(false);
    }

    public void GetRewards()
    {
        if (Core.CheckInventory(Core.QuestRewards(10019)))
            return;

        string[] acceptReqs = Core.EnsureLoad(10019).AcceptRequirements.Select(req => req.Name).ToArray();
        string[] reqs = Core.EnsureLoad(10019).Requirements.Select(req => req.Name).ToArray();

        Core.AddDrop((acceptReqs).Concat(reqs).ToArray());

        if (!Core.CheckInventory(acceptReqs))
        {
            Core.Logger("Getting prerequirements for the quest.");

            // Nulgath Armor
            Jug.JuggItems(JuggernautItemsofNulgath.RewardsSelection.Nulgath_Armor);

            // Spoils of War
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonsterQuest(8582, "darkwarnation", "War", true);

            // Doomed Extract
            TD.Storyline();
            Core.HuntMonsterQuest(9090, new[] {
                ("templedelve", "Delirious Elemental", ClassType.Farm),
                ("templedelve", "Infested Nation", ClassType.Farm),
                ("templedelve", "Doomed Fiend", ClassType.Solo),
                 });

            // Void Remnant
            VC.Storyline();
            Core.HuntMonsterQuest(9553, new[] {
                ("voidchasm", "Carcano", ClassType.Solo),
                ("voidchasm", "Carnage", ClassType.Solo),
                ("voidchasm", "The Hushed", ClassType.Farm),
            });
        }

        List<ItemBase> RewardOptions = Core.EnsureLoad(10019).Rewards;

        foreach (ItemBase item in RewardOptions)
            Core.AddDrop(item.Name);

        Core.EquipClass(ClassType.Farm);

        foreach (ItemBase Reward in RewardOptions)
        {
            if (Core.CheckInventory(Reward.Name, toInv: false))
                return;

            Core.FarmingLogger(Reward.Name, 1);

            Core.EnsureAccept(10019);
            Core.HuntMonster("fiendshard", "Dirtlicker", "Dirtlicker's Reward", isTemp: false);
            Core.HuntMonster("shadowblast", "Crag and Bamboozle", "Crag and Bamboozle's Reward", isTemp: false);
            Core.HuntMonster("citadel", "Death's Head", "Death's Head Reward", isTemp: false);
            Core.HuntMonster("underlair", "ArchFiend DragonKnight", "ArchFiend DragonKnight's Reward", isTemp: false);
            Core.HuntMonster("evilwardage", "Klunk", "Klunk's Reward", isTemp: false);
            Core.EnsureComplete(10019, Reward.ID);
            Core.ToBank(Reward.Name);
        }

    }
}


