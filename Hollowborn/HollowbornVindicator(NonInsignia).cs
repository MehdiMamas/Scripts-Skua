/*
name: Hollowborn Vindicator Class (Non Insignia)
description: Farms Hollowborn Vindicator Class.
tags: hollowborn, class, hv,hollowborn vindicator, vindicator, gramiel, non insignia,ultragramielhub
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Hollowborn/Materials/HollowSoul.cs

using Skua.Core.Interfaces;

public class HBVNonInsig
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();
    private HollowSoul HS = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        GetClass();
        Core.SetOptions(false);
    }

    public void GetClass(bool rankUpClass = true)
    {
        if (Core.CheckInventory(94357))
        {
            if (rankUpClass)
                Adv.RankUpClass("Hollowborn Vindicator");
            return;
        }

        string reqName = Core.QuestRewards(10299)[0];
        Core.AddDrop(reqName);

        if (!Core.CheckInventory(reqName, 4))
        {
            // Death's Power
            if (!Core.CheckInventory("Death's Power"))
            {
                Core.AddDrop("Death's Power");
                Core.EquipClass(ClassType.Solo);
                Core.KillMonster("shadowattack", "Boss", "Left", "Death", "Death's Power", 1, false);
            }

            // Hollow Soul
            HS.GetYaSoulsHeeeere(1500);

            // Vindicator Badge
            GetVindicatorBadge(200);

            // Grace Orb
            GetGraceOrb(400);

            // Gramiel's Emblem
            GetGramielsEmblem(300);

            // Vindicator Crest
            GetVindicatorCrest(100);

            Core.ChainComplete(10299);
            Bot.Wait.ForPickup(reqName);
        }

        if (!Core.CheckInventory(reqName, 4))
        {
            Core.Logger($"You need 4x {reqName} to get the class. Run the script next week.");
            return;
        }
        else
            Adv.BuyItem("ultragramielhub", 2593, "Hollowborn Vindicator");

        if (rankUpClass)
            Adv.RankUpClass("Hollowborn Vindicator");

    }

    public void GetVindicatorBadge(int quant = 300)
    {
        const string item = "Vindicator Badge";
        if (Core.CheckInventory(item, quant))
            return;

        Core.FarmingLogger(item, quant);
        Core.AddDrop(item, "Eagle Heart", "Boar Heart", "Vindicator Seal");
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(8299);

        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.KillMonster("trygve", "r3", "Left", "Blood Eagle", "Eagle Heart", 8);
            Core.KillMonster("trygve", "r4", "Left", "Rune Boar", "Boar Heart", 8);
            Core.HuntMonster("trygve", "Gramiel", "Vindicator Seal");
            Bot.Wait.ForPickup(item);
        }

        Core.CancelRegisteredQuests();
    }

    public void GetGraceOrb(int quant = 510)
    {
        const string item = "Grace Orb";
        if (Core.CheckInventory(item, quant))
            return;

        Core.FarmingLogger(item, quant);
        Core.AddDrop(item, "Grace Extracted");
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(9291);

        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.HuntMonster("neofortress", "Vindicator Recruit", "Grace Extracted", 20);
            Bot.Wait.ForPickup(item);
        }

        Core.CancelRegisteredQuests();
    }

    public void GetVindicatorCrest(int quant = 300)
    {
        const string item = "Vindicator Crest";
        if (Core.CheckInventory(item, quant))
            return;

        Core.FarmingLogger(item, quant);
        Core.AddDrop(item, "Vindicated Blades", "Vindicated Chain", "Vindicated Scripture");
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(9865);

        while (!Bot.ShouldExit && !Core.CheckInventory(item, quant))
        {
            Core.HuntMonsterMapID("neotower", 12, "Vindicated Blades");
            Core.HuntMonsterMapID("neotower", 17, "Vindicated Chain");
            Core.HuntMonsterMapID("neotower", 28, "Vindicated Scripture");
            Bot.Wait.ForPickup(item);
        }

        Core.CancelRegisteredQuests();
    }

    public void GetGramielsEmblem(int quant = 1000)
    {
        const string item = "Gramiel's Emblem";
        if (Core.CheckInventory(item, quant))
            return;

        Core.FarmingLogger(item, quant);
        Core.AddDrop(item);
        Core.EquipClass(ClassType.Solo);

        Core.HuntMonster("dawnsanctum", "Celestial Gramiel", item, quant);
    }
}