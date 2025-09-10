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
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreToD TOD
{
    get => _TOD ??= new CoreToD();
    set => _TOD = value;
}
public CoreToD _TOD;

public BloodSorceress BS
{
    get => _BS ??= new BloodSorceress();
    set => _BS = value;
}
public BloodSorceress _BS;


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

        InventoryItem? BloodSorceress = Bot.Inventory.Items.Concat(Bot.Bank.Items).FirstOrDefault(i => i != null && i.Name == "Blood Sorceress" && i.Category == ItemCategory.Class);

        if (!Core.CheckInventory("Blood Sorceress") || BloodSorceress != null && BloodSorceress.Quantity < 302500)
        {
            TOD.TowerofMirrors();
            BS.GetBSorc();
            Bot.Wait.ForPickup("Blood Sorceress");
        }

        BloodSorceress = Bot.Inventory.Items.Concat(Bot.Bank.Items).FirstOrDefault(i => i != null && i.Name == "Blood Sorceress" && i.Category == ItemCategory.Class);

        // Check if R10, soemtimes the game can get it stuck at r9 with 100% Cxp
        if (BloodSorceress != null && BloodSorceress.Quantity < 302500) //now requires it to be rank 10?
        {
            Core.Relogin("\"Blood Sorceress\" Received from Quest is unenhanced, relogging to properly set its enh. type.");
            Adv.RankUpClass("Blood Sorceress");
        }

        if (!Core.CheckInventory("Scarlet Sorceress"))
        {
            Farm.Experience(50);
            Bot.Options.AggroMonsters = false;

            Core.ChainComplete(6236);
            Bot.Wait.ForPickup("Scarlet Sorceress");

            if (rankUpClass)
            {
                Adv.RankUpClass("Scarlet Sorceress");
            }
        }
    }
}
