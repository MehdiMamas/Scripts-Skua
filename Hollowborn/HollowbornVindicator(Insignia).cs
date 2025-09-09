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
//cs_include Scripts/Hollowborn/Materials/VindicatorBadge.cs
//cs_include Scripts/Hollowborn/Materials/DeathsPower.cs
//cs_include Scripts/Hollowborn/Materials/GraceOrb.cs
//cs_include Scripts/Hollowborn/Materials/GramielsEmblem.cs
//cs_include Scripts/Hollowborn/Materials/VindicatorCrest.cs
//cs_include Scripts/Story/Hollowborn/CoreHollowbornStory.cs
//cs_include Scripts/Hollowborn/HollowbornVindicator(NonInsignia).cs

using Skua.Core.Interfaces;

public class HBVInsig
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();
    private CoreFarms Farm = new();
    private HollowSoul HS = new();
    private HBVNonInsig HBV = new();
    private CoreHollowbornStory HBS = new();
    private VindicatorBadge VB = new();
    private DeathsPower DP = new();
    private GraceOrb GO = new();
    private GramielsEmblem GE = new();
    private VindicatorCrest VC = new();

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

        Farm.Experience(80);
        Farm.HollowbornREP();

        HBS.DawnSanctum();
        string reqName = Core.QuestRewards(10300)[0];
        Core.AddDrop(reqName);

        if (!Core.CheckInventory(reqName, 4))
        {
            Core.EnsureAccept(10300);

            // Vindicator Crest
            VC.GetVindicatorCrest(5);

            // Gramiel's Emblem
            GE.GetGramielsEmblem(15);

            // Grace Orb
            GO.GetGraceOrb(20);

            // Vindicator Badge
            VB.GetVindicatorBadge(10);

            // Hollow Soul
            HS.GetYaSoulsHeeeere(75);

            // Death's Power
            DP.GetDP(1);

            if (!Core.CheckInventory("Gramiel the Graceful's Insignia", 5))
            {
                Core.Logger($"You need 5x Gramiel the Graceful's Insignia to complete the quest.");
                return;
            }
            if (!Bot.Quests.IsAvailable(10300))
            {
                Core.Logger("This is a weekly quest, you need to wait until next week to get the class.");
                return;
            }
            Core.EnsureComplete(10300);
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