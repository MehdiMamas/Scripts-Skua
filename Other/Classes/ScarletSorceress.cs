/*
name: ScarletSorceress
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/Other/Classes/BloodSorceress.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class ScarletSorceress
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm => new();
    public CoreAdvanced Adv = new();
    public CoreToD TOD = new();
    public BloodSorceress BS = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetSSorc();

        Core.SetOptions(false);
    }

    public void GetSSorc(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Scarlet Sorceress"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Scarlet Sorceress");
            return;
        }

        Core.AddDrop("Scarlet Sorceress", "Blood Sorceress");

        if (!Core.CheckInventory("Blood Sorceress"))
        {
            TOD.TowerofMirrors();
            BS.GetBSorc();

            Core.JumpWait();
            InventoryItem? BloodSorceress = Bot.Inventory.Items.Concat(Bot.Bank.Items).FirstOrDefault(i => i != null && i.Name == "Blood Sorceress" && i.Category == ItemCategory.Class);

            if (BloodSorceress == null)
            {
                Core.Logger("Blood Sorceress not found in inventory, returning.");
                return;
            }

            if (BloodSorceress.EnhancementLevel == 0)
                Adv.SmartEnhance("Blood Sorceress");

            // Check if R10, soemtimes the game can get it stuck at r9 with 100% Cxp
            if (BloodSorceress.Quantity < 302500) //now requires it to be rank 10?
            {
                Core.Relogin();
                Adv.RankUpClass("Blood Sorceress");
            }
        }

        Farm.Experience(50);
        Bot.Options.AggroMonsters = false;
        Core.Jump();
        Core.JumpWait();

        Core.ChainComplete(6236);
        Bot.Wait.ForPickup("Scarlet Sorceress");

        InventoryItem? ScarletSorceress = Bot.Inventory.Items.Concat(Bot.Bank.Items).Find(i => i.Name == "Scarlet Sorceress" && i.Category == ItemCategory.Class);

        if (ScarletSorceress == null)
        {
            Core.Logger("Scarlet Sorceress not found in inventory, returning.");
            return;
        }

        if (ScarletSorceress.EnhancementLevel == 0)
            Adv.SmartEnhance("Scarlet Sorceress");

        if (rankUpClass)
            Adv.RankUpClass("Scarlet Sorceress");
    }
}
