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


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();
        ClassPrep();
        Core.SetOptions(false);
    }

    public void ClassPrep()
    {
        Core.Logger("These are just some preparations for the Hollowborn Class, not a full guide nor probably *everything* required, but it should be enough to get you started on the grind.");

        Core.Logger("Getting Bone Dust out of the way");
        // Farm.BoneSomeDust();

        Core.Logger("Maxing Hollowborn Materials");
        HB.HardcoreContract();
        Core.ToBank(55157); // Lae's Hardcore Contract
        HB.HumanSoul();
        Core.ToBank("Human Soul"); 
        HB.FreshSouls();
        Core.ToBank("Unidentified 36", "Fresh Soul");
        HollowSoul.GetYaSoulsHeeeere();
        Core.ToBank("Hollow Soul");
        SoulEssence.SoulEssence();
        Core.ToBank("Soul Essence");
        SoulSand.SoulSand();
        Core.ToBank("Soul Sand");
        HB.HBLycanClaw();
        Core.ToBank("Hollowborn Lycan Claw");
        HB.HBVampireFang();
        Core.ToBank("Hollowborn Vampire Fang");
        HB.HBHollowbornResidue();
        Core.ToBank("Hollowborn Residue");
        HB.HBWrit();
        Core.ToBank("Hollowborn Writ");

        // HBLK.Draftless(CoreHollowbornLichKing.DraftlessRewards.Soul_Fragment, false, 18);
        // HBLK.FlowStress(CoreHollowbornLichKing.FlowStressRewards.Lich_King_Fragment, false, 18);

        // Core.Logger("Maxing \"Most\" Legion materials");

        // // Make sure they're part of the legion
        // CL.JoinLegion();

        // Materials
        // CL.ApprovalAndFavor();
        // CL.FarmLegionToken();
        // CL.EmblemofDage();
        // CL.DarkToken();
        // CL.BoneSigil();
        // CL.DarkToken();
        // CL.DiamondTokenofDage();
        // CL.ObsidianRock();
        // CoreYnR.YokaiSwordScroll();

        // // Keep pvp as the last, as it takes **FUCKING FOREVER**
        // CL.DagePvP();

        // Core.Logger("Maxing Legion Reventant Materials");
        // CoreLegionRev.ConquestWreath();
        // CoreLegionRev.RevenantSpellscroll();
        // CoreLegionRev.ExaltedCrown();
    }
}