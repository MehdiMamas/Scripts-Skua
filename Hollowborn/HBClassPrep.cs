/*
name: Hollowborn Class Preparation
description: Automates the farming of essential materials for the Hollowborn class, including Hollowborn, Legion, and Soul-based items. Not a full guide but enough to prepare for major requirements.
tags: hollowborn, class, preparation, soul essence, hollow soul, legion, farming, lich king, dark caster, lae, writ, residue, fangs, claws
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Legion/Revenant/CoreLR.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/YamiNoRonin/CoreYnR.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Hollowborn/HollowbornLichKing/CoreHollowbornLichKing.cs

//cs_include Scripts/Legion/InfiniteLegionDarkCaster.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Legion/SwordMaster.cs
//cs_include Scripts/Legion/Various/LegionBonfire.cs
//cs_include Scripts/Legion/MergeShops/UndeadLegionMerge.cs
//cs_include Scripts/Legion/LegionExcercise/LegionExercise3.cs
//cs_include Scripts/Legion/LegionExcercise/LegionExercise4.cs
//cs_include Scripts/Nation/Various/DragonBlade[mem].cs

//cs_include Scripts/Hollowborn/Materials/HollowSoul.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Legion/LegionMaterials/LetitBurn(SoulEssence).cs
//cs_include Scripts/Story/Hollowborn/CoreHollowbornStory.cs

using Skua.Core.Interfaces;

public class HBClassPrep
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreLegion CL = new();
    public CoreLR CoreLegionRev = new();
    public CoreYnR CoreYnR = new();
    public CoreHollowborn HB = new();
    public AnotherOneBitesTheDust SoulSand = new();
    public LetItBurn SoulEssence = new();
    public CoreHollowbornLichKing HBLK = new();
    public HollowSoul HollowSoul = new();
    private CoreHollowbornStory HBS = new();


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        ClassPrep();
        Core.SetOptions(false);
    }

    public void ClassPrep()
    {
        HollowSoul.GetYaSoulsHeeeere();
        GetVindicatorBadge();
        GetGraceOrb();
        GetVindicatorCrest();
        GetGramielsEmblem();

        // Optional/conditional:
        // HB.FarmGramielInsignia(5); // If needed later
        // HB.FarmCondensedGrace(1);  // Final combine step
    }

    void GetVindicatorBadge(int quant = 300)
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

    void GetGraceOrb(int quant = 510)
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

    void GetVindicatorCrest(int quant = 300)
    {
        const string item = "Vindicator Crest";
        if (Core.CheckInventory(item, quant))
            return;

        HBS.NeoTower();
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

    void GetGramielsEmblem(int quant = 1000)
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