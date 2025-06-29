/*
name: Hollowborn Vindicator Class (Non Insignia)
description: Farms Hollowborn Vindicator Class.
tags: hollowborn, class, hbv,hollowborn vindicator, vindicator, gramiel, non insignia,ultragramielhub
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


using Skua.Core.Interfaces;

public class HBVNonInsig
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();
    private CoreFarms Farm = new();
    private HollowSoul HS = new();
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
        string reqName = Core.QuestRewards(10299)[0];
        Core.AddDrop(reqName);

        if (!Core.CheckInventory(reqName, 4))
        {
            Core.EnsureAccept(10299);

            // Vindicator Crest
            VC.GetVindicatorCrest(100);

            // Gramiel's Emblem
            GE.GetGramielsEmblem(300);

            // Grace Orb
            GO.GetGraceOrb(400);

            // Vindicator Badge
            VB.GetVindicatorBadge(200);

            // Hollow Soul
            HS.GetYaSoulsHeeeere(1500);

            // Death's Power
            DP.GetDP(1);

            if (!Bot.Quests.IsAvailable(10299))
            {
                Core.Logger("This is a weekly quest, you need to wait until next week to get the class.");
                return;
            }
            else
                Core.EnsureComplete(10299);
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