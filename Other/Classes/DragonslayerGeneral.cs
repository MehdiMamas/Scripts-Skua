/*
name: DragonslayerGeneral
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class DragonslayerGeneral
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetDSGeneral();

        Core.SetOptions(false);
    }

    public void GetDSGeneral(bool rankUpClass = true)
    {
        Adv.GearStore();
        if (Core.CheckInventory(35996))
        {
            if (rankUpClass)
                Adv.RankUpClass("Dragonslayer General");
            return;
        }

        Farm.Gold(30000);
        EnchantedScaleandClaw(75, 100);
        Core.BuyItem("dragontown", 1286, 35996, shopItemID: 4644);

        if (rankUpClass)
            Adv.RankUpClass("Dragonslayer General");
    }

    public void EnchantedScaleandClaw(int ScaleQuant, int ClawQuant)
    {
        if (!Core.CheckInventory(582))
            Core.BuyItem("lair", 38, "Dragonslayer");
        Adv.RankUpClass("Dragonslayer");

        Core.EquipClass(ClassType.Farm);

        if (ScaleQuant > 0)
        {
            Core.AddDrop("Enchanted Scale");
            Core.Logger($"Farming {ScaleQuant} Enchanted Scale, {Bot.Inventory.GetQuantity("Enchanted Scale")} / {ScaleQuant}");
            Core.RegisterQuests(5294);
        }

        Core.KillMonster("dragontown", "r4", "Right", "Tempest Dracolich", "Dragon Claw", ClawQuant, isTemp: false);

        while (!Bot.ShouldExit && !Core.CheckInventory("Enchanted Scale", ScaleQuant))
            Core.KillMonster("dragontown", "r4", "Right", "Tempest Dracolich", "Dracolich Slain", 12, log: false);
        Core.CancelRegisteredQuests();
    }
}
