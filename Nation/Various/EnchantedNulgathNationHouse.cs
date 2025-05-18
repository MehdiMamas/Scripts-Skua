/*
name: Enchanted Nulgath Nation House
description: gets the enchanted nulgath nation house
tags: enchanted nulgath nation house, ennh, nulgath
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Good/BLOD/CoreBLOD.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class EnhancedNulgathNationHouse
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreDailies Daily = new();
    public CoreNation Nation = new();
    public CoreBLOD BLOD = new();
    public CoreStory Story = new();
    private CoreAdvanced Adv = new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        GetENNH();

        Core.SetOptions(false);
    }

    public void GetENNH()
    {
        if (Core.CheckInventory("Enchanted Nulgath Nation House"))
        {
            Core.Logger("ENNH Owned");
            return;
        }

        Core.AddDrop(Nation.bagDrops.Concat(new[] { "Cemaros' Amethyst", "Aluminum", "NUE Necronomicon", "Nulgath Nation House", "Enchanted Nulgath Nation House" }).ToArray());

        if (!Core.CheckInventory("Nulgath Nation House"))
        {
            Nation.FarmUni10(400);
            Nation.FarmUni13(1);
            Nation.FarmVoucher(false, true);
            Nation.FarmDiamondofNulgath(300);
            Nation.FarmDarkCrystalShard(250);
            Nation.FarmTotemofNulgath(30);
            Nation.FarmGemofNulgath(150);
            Nation.SwindleBulk(200);
            Nation.FarmBloodGem(100);
            Nation.ApprovalAndFavor(1000, 0);

            Adv.BuyItem("mountdoomskull", 776, "Cemaros' Amethyst");

            BLOD.UnlockMineCrafting();
            Daily.MineCrafting(new[] { "Aluminum" });

            Adv.BuyItem("lightguard", 277, "NUE Necronomicon");

            // Core.EnsureAccept(4779);
            if (!Core.EnsureComplete(4779))
            {
                Core.Logger("Could not complete the quest, stopping bot", messageBox: true);
                return;
            }
            Bot.Wait.ForQuestComplete(4779);
            Bot.Wait.ForPickup("Nulgath Nation House");
        }
        
        Adv.BuyItem("tercessuinotlim", 1951, "Pink Star Diamond of Nulgath");
        Core.HuntMonster("timelibrary", "Ancient Chest", "Musgravite of Nulgath", 2, false);
        Adv.BuyItem("archportal", 1211, "Enchanted Nulgath Nation House");
    }
}
