/*
name: Contract Enforcer of Nulgath
description: This script will farm the "Contract Enforcer of Nulgath" armor.
tags: malakai,pearl of nulgath,contract enforcer,katana,renunciation,the contract enforcer,armor
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Nation/Various/TarosManslayer.cs
//cs_include Scripts/Nation/Various/PurifiedClaymoreOfDestiny.cs
//cs_include Scripts/Nation/Various/DragonBlade[mem].cs
//cs_include Scripts/Nation\MergeShops\NulgathDiamondMerge.cs
//cs_include Scripts/Nation/Various/TheLeeryContract[Member].cs
//cs_include Scripts/Nation/Various/JuggernautItems.cs
//cs_include Scripts/Nation\MergeShops\DirtlickersMerge.cs
using Skua.Core.Interfaces;

public class ContractEnforcer
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreNation Nation = new();
    private NulgathDiamondMerge NDM = new();
    private CoreDailies Daily = new();
    private DirtlickersMerge DLM = new();
    private CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetArmor();

        Core.SetOptions(false);
    }

    public void GetArmor()
    {
        if (Core.CheckInventory("Contract Enforcer of Nulgath"))
            return;

        if (!Core.CheckInventory("Malakai's Katana Pet"))
        {
            Core.Logger("Malakai's Katana Pet required for this armor, getting it now.");
            NDM.BuyAllMerge("Malakai's Katana Pet");
        }
        Core.AddDrop("Contract Enforcer of Nulgath");
        Adornments();
        Armaments();

        Nation.FarmUni13(3);
        Nation.FarmDarkCrystalShard(100);
        Nation.FarmTotemofNulgath(5);
        Nation.FarmBloodGem(25);
        DLM.BuyAllMerge("Shadow Legacy of Nulgath");
        Adv.BuyItem("tercessuinotlim", 1951, "Unmoulded Fiend Essence");
        //PUT THE DAGE'S CONTRACT HERE
        if (!Core.CheckInventory("Pearl of Nulgath", 4))
        {
            Daily.PearlOfNulgath();
            if (!Core.CheckInventory("Pearl of Nulgath", 4))
            {
                Core.Logger($"You need 4 Pearls of Nulgath to complete the quest, you have {Bot.Inventory.GetItem("Pearl of Nulgath")?.Quantity ?? 0}");
                return;
            }
        }

        if (!Core.CheckInventory(Core.QuestRewards(10048).Concat(Core.QuestRewards(10049)).ToArray()))
        {
            Core.Logger("You need to have both rewards from both quests in order to complete the quest. Run the script again tomorrow.");
            return;

        }

        Core.ChainComplete(10050);
        Core.ToBank(Core.QuestRewards(10048).Concat(Core.QuestRewards(10049)).ToArray());
    }

    public void Adornments()
    {
        if (Core.CheckInventory(Core.QuestRewards(10048)))
            return;

        Core.AddDrop(Core.QuestRewards(10048));

        Nation.FarmUni13(1);
        Nation.FarmDiamondofNulgath(250);
        Nation.FarmVoucher(true, true);
        Core.HuntMonster("evilwarnul", "Undead Legend", "Wings of Revontheus", isTemp: false);
        Nation.ApprovalAndFavor(1000, 1000);
        if (!Core.CheckInventory("Pearl of Nulgath", 2))
        {
            Daily.PearlOfNulgath();
            if (!Core.CheckInventory("Pearl of Nulgath", 2))
            {
                Core.Logger($"You need 2 Pearls of Nulgath to complete the quest, you have {Bot.Inventory.GetItem("Pearl of Nulgath")?.Quantity ?? 0}");
                return;
            }
        }
        Core.EnsureAccept(10048);
        Core.EnsureCompleteChoose(10048);
    }

    public void Armaments()
    {
        if (Core.CheckInventory(Core.QuestRewards(10049)))
            return;

        Core.AddDrop(Core.QuestRewards(10049));

        Nation.FarmUni13(1);
        Nation.FarmTaintedGem(150);
        Nation.Supplies("Random Weapon of Nulgath");
        Nation.FarmGemofNulgath(35);
        Core.HuntMonster("voidrefuge", "Carnage", "Bloodletter Katana", isTemp: false);
        if (!Core.CheckInventory("Pearl of Nulgath", 3))
        {
            Daily.PearlOfNulgath();
            if (!Core.CheckInventory("Pearl of Nulgath", 3))
            {
                Core.Logger($"You need 3 Pearls of Nulgath to complete the quest, you have {Bot.Inventory.GetItem("Pearl of Nulgath")?.Quantity ?? 0}");
                return;
            }
        }
        Core.EnsureAccept(10049);
        Core.EnsureCompleteChoose(10049);
    }
}
