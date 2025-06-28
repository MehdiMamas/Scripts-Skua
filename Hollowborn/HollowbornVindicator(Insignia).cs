/*
name: Hollowborn Vindicator Class (Insignia)
description: Farms Hollowborn Vindicator Class prereqs for Insignia quest.
tags: hollowborn, class, hbv,hollowborn vindicator, vindicator, gramiel,insignia,ultragramielhub, ultragramiel
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Hollowborn/Materials/HollowSoul.cs
//cs_include Scripts/Hollowborn/HollowbornVindicator(NonInsignia).cs
//cs_include Scripts/Story/Hollowborn/CoreHollowbornStory.cs

using Skua.Core.Interfaces;

public class HBVInsig
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();
    private HollowSoul HS = new();
    private HBVNonInsig HBV = new();
    private CoreHollowbornStory HBS = new();

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

        HBS.DawnSanctum();
        string reqName = Core.QuestRewards(10300)[0];
        Core.AddDrop(reqName);

        if (!Core.CheckInventory(reqName, 4))
        {
            if (!Bot.Quests.IsAvailable(10300))
            {
                Core.Logger("This is a weekly quest, you need to wait until next week to get the class.");
                return;
            }
            Core.EnsureAccept(10300);
            // Death's Power
            if (!Core.CheckInventory("Death's Power"))
            {
                Core.AddDrop("Death's Power");
                Core.EquipClass(ClassType.Solo);
                Core.KillMonster("shadowattack", "Boss", "Left", "Death", "Death's Power", 1, true);
            }

            // Hollow Soul
            HS.GetYaSoulsHeeeere(75);

            // Vindicator Badge
            HBV.GetVindicatorBadge(10);

            // Grace Orb
            HBV.GetGraceOrb(20);

            // Gramiel's Emblem
            HBV.GetGramielsEmblem(15);

            // Vindicator Crest
            HBV.GetVindicatorCrest(5);

            if (Core.CheckInventory("Gramiel the Graceful's Insignia", 5))
                Core.EnsureComplete(10300);
            else
            {
                Core.Logger($"You need 5x Gramiel the Graceful's Insignia to get the class using this script.");
                return;
            }
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

}