/*
name: Grimgoal
description: Goes through teh grimgaol dungeon... Testing Phase
tags: grimgoal, dungeon, why, did, we, make, this, Testing, WIP, beta
*/

#region includes
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/Chaos/EternalDrakathSet.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Dailies/LordOfOrder.cs
//cs_include Scripts/Darkon/CoreDarkon.cs
//cs_include Scripts/Darkon/Various/PrinceDarkonsPoleaxePreReqs.cs
//cs_include Scripts/Enhancement/UnlockForgeEnhancements.cs
//cs_include Scripts/Evil/ADK.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Evil/SepulchuresOriginalHelm.cs
//cs_include Scripts/Good/ArchPaladin.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Good/GearOfAwe/ArmorOfAwe.cs
//cs_include Scripts/Good/GearOfAwe/Awescended.cs
//cs_include Scripts/Good/GearOfAwe/CoreAwe.cs
//cs_include Scripts/Good/GearOfAwe/HelmOfAwe.cs
//cs_include Scripts/Good/Paladin.cs
//cs_include Scripts/Good/SilverExaltedPaladin.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Hollowborn/TradingandStuff(single).cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/HeadOfTheLegionBeast.cs
//cs_include Scripts/Legion/SwordMaster.cs
//cs_include Scripts/Legion/YamiNoRonin/CoreYnR.cs
//cs_include Scripts/Nation/AFDL/NulgathDemandsWork.cs
//cs_include Scripts/Nation/AFDL/WillpowerExtraction.cs
//cs_include Scripts/Nation/AssistingCragAndBamboozle[Mem].cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/EmpoweringItems.cs
//cs_include Scripts/Nation/MergeShops/DilligasMerge.cs
//cs_include Scripts/Nation/MergeShops/DirtlickersMerge.cs
//cs_include Scripts/Nation/MergeShops/NationMerge.cs
//cs_include Scripts/Nation/MergeShops/NulgathDiamondMerge.cs
//cs_include Scripts/Nation/MergeShops/VoidChasmMerge.cs
//cs_include Scripts/Nation/MergeShops/VoidRefugeMerge.cs
//cs_include Scripts/Nation/NationLoyaltyRewarded.cs
//cs_include Scripts/Nation/VHL/CoreVHL.cs
//cs_include Scripts/Nation/Various/ArchfiendDeathLord.cs
//cs_include Scripts/Nation/Various/DragonBlade[mem].cs
//cs_include Scripts/Nation/Various/GoldenHanzoVoid.cs
//cs_include Scripts/Nation/Various/JuggernautItems.cs
//cs_include Scripts/Nation/Various/PrimeFiendShard.cs
//cs_include Scripts/Nation/Various/PurifiedClaymoreOfDestiny.cs
//cs_include Scripts/Nation/Various/SwirlingTheAbyss.cs
//cs_include Scripts/Nation/Various/TarosManslayer.cs
//cs_include Scripts/Nation/Various/TheLeeryContract[Member].cs
//cs_include Scripts/Nation/Various/VoidPaladin.cs
//cs_include Scripts/Nation/Various/VoidSpartan.cs
//cs_include Scripts/Other/Armor/FireChampionsArmor.cs
//cs_include Scripts/Other/Armor/MalgorsArmorSet.cs
//cs_include Scripts/Other/Classes/DragonOfTime.cs
//cs_include Scripts/Other/Classes/DragonslayerGeneral.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Other/MergeShops/InfernalArenaMerge.cs
//cs_include Scripts/Other/MysteriousEgg.cs
//cs_include Scripts/Other/ShadowDragonDefender.cs
//cs_include Scripts/Other/WarFuryEmblem.cs
//cs_include Scripts/Other/Weapons/FortitudeAndHubris.cs
//cs_include Scripts/Other/Weapons/GoldenBladeOfFate.cs
//cs_include Scripts/Other/Weapons/PinkBladeofDestruction.cs
//cs_include Scripts/Other/Weapons/ShadowReaperOfDoom.cs
//cs_include Scripts/Other/Weapons/VoidAvengerScythe.cs
//cs_include Scripts/Other/Weapons/WrathofNulgath.cs
//cs_include Scripts/ShadowsOfWar/CoreSoWMats.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/DeadLinesMerge.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/ManaCradleMerge.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/ShadowflameFinaleMerge.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/StreamwarMerge.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/TimekeepMerge.cs
//cs_include Scripts/ShadowsOfWar/MergeShops/WorldsCoreMerge.cs
//cs_include Scripts/Seasonal/StaffBirthdays/Nulgath/TempleDelve.cs
//cs_include Scripts/Seasonal/StaffBirthdays/Nulgath/TempleDelveMerge.cs
//cs_include Scripts/Seasonal/StaffBirthdays/Nulgath/TempleSiege.cs
//cs_include Scripts/Story/7DeadlyDragons/Core7DD.cs
//cs_include Scripts/Story/7DeadlyDragons/Extra/HatchTheEgg.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/Borgars.cs
//cs_include Scripts/Story/DjinnGate.cs
//cs_include Scripts/Story/DoomVault.cs
//cs_include Scripts/Story/DoomVaultB.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
//cs_include Scripts/Story/DragonFableOrigins.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs
//cs_include Scripts/Story/J6Saga.cs
//cs_include Scripts/Story/Lair.cs
//cs_include Scripts/Story/Legion/DarkWarLegionandNation.cs
//cs_include Scripts/Story/Legion/SevenCircles(War).cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Story/Nation/Bamboozle.cs
//cs_include Scripts/Story/Nation/CitadelRuins.cs
//cs_include Scripts/Story/Nation/Fiendshard.cs
//cs_include Scripts/Story/Nation/Originul.cs
//cs_include Scripts/Story/Nation/VoidChasm.cs
//cs_include Scripts/Story/Nation/VoidRefuge.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQoM.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/CelestialArena.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/InfernalArena.cs
//cs_include Scripts/Story/SepulchureSaga/CoreSepulchure.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/StarSinc.cs
//cs_include Scripts/Story/Summer2015AdventureMap/CoreSummer.cs
//cs_include Scripts/Story/ThirdSpell.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/Story/TowerOfDoom.cs
//cs_include Scripts/Story/XansLair.cs
//cs_include Scripts/Story/Yokai.cs
#endregion includes

using System.Threading.Tasks;
using Skua.Core.Interfaces;
using Skua.Core.Models.Players;
using Skua.Core.Options;
using Newtonsoft.Json.Linq;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Items;
using Skua.Core.Models.Auras;

public class Grimgaol
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public static CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    private CoreStory Story = new();
    public CoreAdvanced Adv = new();
    private DoomVaultB DVB = new();
    private InfernalArenaMerge IAM = new();
    private J6Saga J6 = new();
    private UnlockForgeEnhancements Forge = new();

    public string OptionsStorage = "Grimgaol";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        // VHL : luck
        // VDK : luck
        // Dragon of Time : Healer

        // Skip Options
        CoreBots.Instance.SkipOptions,

        // weapons
        new Option<string>("Valiance", "Weapon: Valiance", "insert name of your Valiance weapon", ""),
        new Option<string>("Dauntless", "Weapon: Dauntless", "insert name of your Dauntless weapon", ""),
        new Option<string>("Elysium", "Weapon: Elysium", "insert name of your Elysium weapon", ""),
      
        // helm
        new Option<string>("WizHelm", "Helm: WizHelm", "insert name of your WizHelm helm", ""),
        new Option<string>("LuckHelm", "Helm: LuckHelm", "insert name of your LuckHelm helm", ""),
        new Option<string>("AnimaHelm", "Helm: AnimaHelm", "insert name of your AnimaHelm helm", ""),
        
        // cape
        new Option<string>("Penitence", "Cape: Penitence", "insert name of your Penitence cape", ""),
        new Option<string>("Vainglory", "Cape: Vainglory", "insert name of your Vainglory cape", ""),
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        SetOptions();

        DoGrimGaol();

        Core.SetOptions(false);
    }

    public void DoGrimGaol(int rank = 10)
    {
        if (Farm.FactionRank("Grimskull Trolling") >= rank)
        {
            Core.Logger($"You already have rank {rank} Grimskull Trolling reputation.");
            return;
        }

        Core.Logger("Checking prerequisites and configurations...");
        CheckConfig();
        Prereqs();
        Core.Logger("Prerequisites and configurations checked successfully.");

        Core.Logger($"Farming rank {rank} Grimskull Trolling reputation.");


        if (!Core.CheckInventory(new[] { "Dragon of Time", "Void Highlord", "Verus DoomKnight" }))
        {
            Core.Logger("You need to have the following classes: Dragon of Time, Void Highlord, Verus DoomKnight", stopBot: true);
        }


        #region Enhancement setup & Equipment 

        // Classes
        if (Core.CheckInventory("Void Highlord"))
            Adv.EnhanceItem("Void Highlord", EnhancementType.Lucky);
        else Core.Logger("Void Highlord not found in inventory.");

        if (Core.CheckInventory("Verus DoomKnight"))
            Adv.EnhanceItem("Verus DoomKnight", EnhancementType.Lucky);
        else Core.Logger("Verus DoomKnight not found in inventory.");

        if (Core.CheckInventory("Dragon of Time"))
            Adv.EnhanceItem("Dragon of Time", EnhancementType.Healer);
        else Core.Logger("Dragon of Time not found in inventory.");

        // Weapons
        string? valiance = Bot.Config!.Get<string>("Valiance");
        if (!string.IsNullOrWhiteSpace(valiance))
        {
            if (Core.CheckInventory(valiance))
                Adv.EnhanceItem(valiance, EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.None, WeaponSpecial.Valiance);
            else Core.Logger($"Valiance weapon set to \"{valiance}\", but it's not in inventory.");
        }

        // Weapons
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            if (Core.CheckInventory(dauntless))
                Adv.EnhanceItem(dauntless, EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.None, WeaponSpecial.Dauntless);
            else Core.Logger($"Dauntless weapon set to \"{dauntless}\", but it's not in inventory.");
        }

        // Helms
        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            if (Core.CheckInventory(wizHelm))
                Adv.EnhanceItem(wizHelm, EnhancementType.Wizard);
            else Core.Logger($"WizHelm set to \"{wizHelm}\", but it's not in inventory.");
        }

        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            if (Core.CheckInventory(luckHelm))
                Adv.EnhanceItem(luckHelm, EnhancementType.Lucky);
            else Core.Logger($"LuckHelm set to \"{luckHelm}\", but it's not in inventory.");
        }

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            if (Core.CheckInventory(animaHelm))
                Adv.EnhanceItem(animaHelm, EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.Anima);
            else Core.Logger($"AnimaHelm set to \"{animaHelm}\", but it's not in inventory.");
        }

        // Capes
        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            if (Core.CheckInventory(penitence))
                Adv.EnhanceItem(penitence, EnhancementType.Lucky, CapeSpecial.Penitence);
            else Core.Logger($"Penitence cape set to \"{penitence}\", but it's not in inventory.");
        }

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            if (Core.CheckInventory(vainglory))
                Adv.EnhanceItem(vainglory, EnhancementType.Lucky, CapeSpecial.Vainglory);
            else Core.Logger($"Vainglory cape set to \"{vainglory}\", but it's not in inventory.");
        }

        Farm.ToggleBoost(BoostType.Reputation);

        // Log summary
        Core.Logger("Gear Enhancements:");
        Core.Logger("- Void Highlord: Lucky");
        Core.Logger("- Verus DoomKnight: Lucky");
        Core.Logger("- Dragon of Time: Healer");

        if (Core.CheckInventory(valiance))
            Core.Logger($"- {valiance}: Lucky (Valiance)");
        if (Core.CheckInventory(dauntless))
            Core.Logger($"- {dauntless}: Lucky (Dauntless)");

        if (Core.CheckInventory(wizHelm))
            Core.Logger($"- {wizHelm}: Wizard");
        if (Core.CheckInventory(luckHelm))
            Core.Logger($"- {luckHelm}: Lucky");
        if (Core.CheckInventory(animaHelm))
            Core.Logger($"- {animaHelm}: Lucky (Anima)");

        if (Core.CheckInventory(penitence))
            Core.Logger($"- {penitence}: Lucky (Penitence)");
        if (Core.CheckInventory(vainglory))
            Core.Logger($"- {vainglory}: Lucky (Vainglory)");

        #endregion

        while (!Bot.ShouldExit && Farm.FactionRank("Grimskull Trolling") < rank)
        {
            if (Bot.Map.Name.ToLower() == "grimgaol")
            {
                Init();
                continue;
            }

            // always a private room as its a solo dungeon
            Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol-100000%");
            Bot.Wait.ForCellChange("Enter");
            Bot.Wait.ForCellChange("Cut1");
            Bot.Map.Jump("Enter", "Left");
            Bot.Wait.ForCellChange("Enter");
            Bot.Wait.ForMapLoad("grimgaol");
            Core.Sleep(1000);
            Init();
        }
        Farm.ToggleBoost(BoostType.Reputation, false);
    }

    private void Init()
    {
        if (Bot.Player.Cell.ToLower().Contains("cut"))
        {
            Core.Logger($"in {Bot.Player?.Cell} cell, jumping to enter");
            Core.Jump("Enter", "Left");
        }

        while (!Bot.ShouldExit && !Bot.TempInv.Contains("Grimskull's Gaol Cleared"))
        {
            jumpToAvailMonster();
            Core.Sleep(500);
            if (Bot.Player != null)
                switch (Bot.Player.Cell)
                {
                    case "Enter":
                        Enter();
                        Core.Jump("r2", "Left");
                        break;
                    case "r2":
                        R2();
                        Core.Jump("r3", "Left");
                        break;
                    case "r4":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r5", "Left");
                        break;
                    case "r5":
                        R5();
                        Core.Jump("r6", "Left");
                        break;
                    case "r6":
                        R6();
                        Core.Jump("r7", "Left");
                        break;
                    case "r9":
                        R9();
                        Core.Jump("r10", "Left");
                        break;
                    case "r10":
                        R10();
                        Core.Jump("r11", "Left");
                        break;
                    case "r3":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r4", "Left");
                        break;
                    case "r7":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r8", "Left");
                        break;
                    case "r8":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r9", "Left");
                        break;
                    case "r11":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r12", "Left");
                        break;
                    case "r12":
                        RVDK(Bot.Player.Cell);
                        Core.Jump("r12a", "Left");
                        break;
                    default:
                        break;
                }
            else
            {
                Core.Logger("Object Bot.Player is null.");
                break;
            }
            Core.Sleep(500);
        }

        Core.ChainComplete(Core.isCompletedBefore(9467) ? (Core.IsMember ? 9468 : 9467) : 9466);
        Bot.Wait.ForQuestComplete(Core.isCompletedBefore(9467) ? (Core.IsMember ? 9468 : 9467) : 9466);
        Core.Sleep(1500);
        Bot.Map.Join("whitemap-999999", "Enter", "Spawn", autoCorrect: false);
        Bot.Wait.ForMapLoad("whitemap");
        Core.Sleep(1500);
        Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol{(Core.PrivateRoomNumber > 0 ? "-" + Core.PrivateRoomNumber : "")}%");
        Core.Sleep(4000);
        Bot.Wait.ForMapLoad("grimgaol");
        Core.Sleep(1500);
    }

    private void Enter()
    {
        if (Bot.ShouldExit) return;

        if (Bot.Player.Cell != "Enter")
        {
            Core.Logger("jump to enter");
            Core.Jump("Enter", "Left");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();

        if (!monsterAvail()) return;
        #region Equipment Setup

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Void Highlord"))
        {
            Bot.Inventory.EquipItem("Void Highlord");
            Core.Sleep(1500);
        }

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
            {
                Bot.Inventory.EquipItem(luckHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }

        string? penitence = Bot.Config.Get<string>("Penitence");
        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }
        #endregion Equipment Setup

        int skillIndex = 0;
        int[] skillList = { 1, 2, 4 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail()) return;

            if (Bot.Player.Cell != "Enter")
            {
                Core.Logger("jump back to enter");
                Bot.Map.Jump("Enter", "Left");
                Bot.Wait.ForCellChange("Enter");
                Core.Sleep(1000);
            }

            while (!Bot.ShouldExit && Bot.Target.HasActiveAura("Talon Twisting")) { Bot.Sleep(100); }

            if (!Bot.Self.HasActiveAura("Shackled") && skillIndex == 0 && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
            }

            if (Bot.Player.HasTarget && skillIndex != 0)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }
            skillIndex = (skillIndex + 1) % skillList.Length;
            Core.Sleep(100);
        }
    }

    private void R2()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r2")
        {
            Core.Logger("jump to r2");
            Core.Jump("r2", "Left");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();

        if (!monsterAvail()) return;

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Void Highlord"))
        {
            Bot.Inventory.EquipItem("Void Highlord");
            Core.Sleep(1500);
        }
        string? valiance = Bot.Config!.Get<string>("Valiance");
        if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }

        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }

        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
            {
                Bot.Inventory.EquipItem(luckHelm);
                Core.Sleep(1500);
            }
        }

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }

        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }


        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail()) return;

            if (Bot.Player.Health >= 2500 && (skillIndex == 0 || skillIndex == 2) && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
            }

            if (Bot.Player.HasTarget && (skillIndex != 0 || skillIndex != 2))
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }
            skillIndex = (skillIndex + 1) % skillList.Length;
            Core.Sleep(100);
        }
    }

    private void R4()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r4")
        {
            Core.Logger("jump to r4");
            Core.Jump("r4", "Left");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();
        if (!monsterAvail())
        {
            return;
        }

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Legion Revenant"))
        {
            Bot.Inventory.EquipItem("Legion Revenant");
            Core.Sleep(1500);
        }

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }


        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
            {
                Bot.Inventory.EquipItem(luckHelm);
                Core.Sleep(1500);
            }
        }

        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }


        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }


        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail())
            {
                return;
            }

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
            }

            if (Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }
            skillIndex = (skillIndex + 1) % skillList.Length;
            Core.Sleep(100);
        }
    }

    private void R5()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r5")
        {
            Core.Logger("jump to r5");
            Core.Jump("r5", "Left");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();
        if (!monsterAvail())
        {
            return;
        }

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? elysium = Bot.Config.Get<string>("Elysium");
        string? dauntless = Bot.Config.Get<string>("Dauntless");

        // Determine weapon based on availability and unlocks
        string? weapon =
            Adv.uElysium() && !string.IsNullOrWhiteSpace(elysium) ? elysium :
            Adv.uDauntless() && !string.IsNullOrWhiteSpace(dauntless) ? dauntless :
            !string.IsNullOrWhiteSpace(valiance) ? valiance : null;

        // Equip based on which group the weapon came from
        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped((weapon == elysium || weapon == dauntless) ? "Dragon of Time" : "Void Highlord"))
        {
            Bot.Inventory.EquipItem((weapon == elysium || weapon == dauntless) ? "Dragon of Time" : "Void Highlord");
            Core.Sleep(1500);
        }

        // Ensure the weapon is equipped
        if (!string.IsNullOrWhiteSpace(weapon))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(weapon))
            {
                Bot.Inventory.EquipItem(weapon);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }

        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }


        int skillIndex = 0;
        int[] skillList = Adv.uDauntless() ? new int[] { 1, 2, 4, 2, 3, 2 } : new int[] { 1, 2, 3, 4 };
        int[] priorityIDs = { 7, 8, 9 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }
            string playerCell = Bot.Player.Cell;
            List<Monster> mapMonsters = Bot.Monsters.MapMonsters;
            // List<Aura> targetAuras = Bot.Target?.Auras?.ToList() ?? new List<Aura>();
            Monster? target = null;
            foreach (var mon in mapMonsters)
            {
                if (mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                {
                    if (priorityIDs.Contains(mon.MapID))
                    {
                        // targetAuras = Bot.Target?.Auras?.ToList() ?? new List<Aura>();
                        target = mon;
                        break;
                    }
                    else target ??= mon;
                }
            }

            if (target == null)
            {
                return;
            }

            Bot.Combat.Attack(target.MapID);
            // targetAuras = Bot.Target?.Auras?.ToList() ?? new List<Aura>();

            int skillID = skillList[skillIndex];
            if (Bot.Player.HasTarget && Bot.Skills.CanUseSkill(skillID))
            {
                Bot.Skills.UseSkill(skillID);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }
        }
    }

    private void R6()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r6")
        {
            Core.Logger("jump to r6");
            Core.Jump("r6", "Left");
        }
        Core.Sleep(1000);
        if (!monsterAvail())
        {
            return;
        }

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Void Highlord"))
        {
            Bot.Inventory.EquipItem("Void Highlord");
            Core.Sleep(1500);
        }

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
            {
                Bot.Inventory.EquipItem(luckHelm);
                Core.Sleep(1500);
            }
        }

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }


        int skillIndex = 0;
        int[] skillList = { 2, 4 };
        string monsId = "10";
        int monsIdInt = 10;
        int monsHealth = 40000;



        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                monsId = "10";
                monsIdInt = 10;
                monsHealth = 40000;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail())
            {
                return;
            }

            if (monsId != "*" && GetMonsterHP(monsId) < monsHealth)
            {
                if (monsId == "12")
                {
                    monsId = "10";
                    monsIdInt = 10;

                    if (monsHealth == 10000)
                    {
                        monsId = "*";
                    }
                    if (monsHealth == 20000)
                    {
                        monsHealth = 10000;
                    }
                    if (monsHealth == 30000)
                    {
                        monsHealth = 20000;
                    }
                    if (monsHealth == 40000)
                    {
                        monsHealth = 30000;
                    }
                }
                else if (monsId == "11")
                {
                    monsId = "12";
                    monsIdInt = 12;
                }
                else if (monsId == "10")
                {
                    monsId = "11";
                    monsIdInt = 11;
                }
            }

            if (monsId == "*")
                doPriorityAttackId(new int[] { 10, 11, 12 });
            else doPriorityAttackId(new int[] { monsIdInt });

            if (Bot.Player.Health >= 3000 && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(1);
            }
            if (Bot.Player.Health >= 4000 && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(3);
            }
            Bot.Skills.UseSkill(skillList[skillIndex]);
            skillIndex = (skillIndex + 1) % skillList.Length;
            Core.Sleep(100);
        }
    }

    private void R9()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r9")
        {
            Core.Logger("jump to r9");
            Core.Jump("r9", "Left");
        }
        Core.Sleep(1000);
        if (!monsterAvail())
        {
            return;
        }

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Void Highlord"))
        {
            Bot.Inventory.EquipItem("Void Highlord");
            Core.Sleep(1500);
        }

        string? valiance = Bot.Config!.Get<string>("Valiance");
        if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }

        string? dauntless = Bot.Config.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }

        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        if (!string.IsNullOrWhiteSpace(luckHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
            {
                Bot.Inventory.EquipItem(luckHelm);
                Core.Sleep(1500);
            }
        }

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }

        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }


        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };



        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail())
            {
                return;
            }

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
            }

            if (Bot.Player.Health >= 2500 && (skillIndex == 0 || skillIndex == 2) && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }
            else if (skillIndex != 0 && skillIndex != 2 && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }
            skillIndex = (skillIndex + 1) % skillList.Length;
        }
    }

    private void R10()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r10")
        {
            Core.Logger("jump to r10");
            Core.Jump("r10", "Left");
        }
        Core.Sleep(1000);
        if (!monsterAvail())
        {
            return;
        }
        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Dragon of Time"))
        {
            Bot.Inventory.EquipItem("Dragon of Time");
            Core.Sleep(1500);
        }
        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? elysium = Bot.Config!.Get<string>("Elysium");
        if (!string.IsNullOrWhiteSpace(elysium))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(elysium))
            {
                Bot.Inventory.EquipItem(elysium);
                Core.Sleep(1500);
            }
        }
        else if (!string.IsNullOrWhiteSpace(valiance))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(valiance))
            {
                Bot.Inventory.EquipItem(valiance);
                Core.Sleep(1500);
            }
        }

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        if (!string.IsNullOrWhiteSpace(wizHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(wizHelm))
            {
                Bot.Inventory.EquipItem(wizHelm);
                Core.Sleep(1500);
            }
        }
        string? penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(penitence))
            {
                Bot.Inventory.EquipItem(penitence);
                Core.Sleep(1500);
            }
        }

        int skillIndex = 0;
        int[] skillList = { 1, 2, 4, 2, 3, 2 };

        string monsId = "16";
        int monsIdInt = 16;

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                monsId = "16";
                monsIdInt = 16;
                Bot.Sleep(500);
                continue;
            }
            if (!monsterAvail())
            {
                return;
            }

            if (monsId != "*" && GetMonsterHP(monsId) <= 70000)
            {
                switch (monsId)
                {
                    case "16":
                        monsId = "17"; monsIdInt = 17;
                        break;
                    case "17":
                        monsId = "18"; monsIdInt = 18;
                        break;
                    case "18":
                        monsId = "*";
                        break;
                }
            }

            if (monsId == "*") doPriorityAttackId(new int[] { 16, 17, 18, 19 });
            else doPriorityAttackId(new int[] { monsIdInt });
            if (Bot.Player.HasTarget && Bot.Skills.CanUseSkill(skillList[skillIndex]))
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }
        }
    }

    private void RVDK(string cell)
    {
        if (Bot.ShouldExit) return;

        if (Bot.Player.Cell != cell)
        {
            Core.Logger($"jump to {cell}");
            Core.Jump(cell, "Left");
        }

        jumpToAvailMonster();

        if (!monsterAvail()) return;

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Verus DoomKnight"))
        {
            Bot.Inventory.EquipItem("Verus DoomKnight");
            Core.Sleep(1500);
        }

        string? dauntless = Bot.Config!.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
            {
                Bot.Inventory.EquipItem(dauntless);
                Core.Sleep(1500);
            }
        }

        if (cell == "r11" || cell == "r12")
        {
            string? luckHelm = Bot.Config.Get<string>("LuckHelm");
            if (!string.IsNullOrWhiteSpace(luckHelm))
            {
                while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(luckHelm))
                {
                    Bot.Inventory.EquipItem(luckHelm);
                    Core.Sleep(1500);
                }
            }
        }
        else
        {
            string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
            if (!string.IsNullOrWhiteSpace(animaHelm))
            {
                while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
                {
                    Bot.Inventory.EquipItem(animaHelm);
                    Core.Sleep(1500);
                }
            }
        }

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
            {
                Bot.Inventory.EquipItem(vainglory);
                Core.Sleep(1500);
            }
        }

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                skillIndex = 0;
                Bot.Sleep(500);
                continue;
            }

            if (Bot.Player.Cell != cell)
            {
                Core.Logger($"jump back to {cell}");
                Core.Jump(cell, "Left");
            }

            if (!monsterAvail()) return;

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
            }

            if (Bot.Player.Health <= 2500)
            {
                Bot.Skills.UseSkill(2);
            }

            if (Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }
            skillIndex = (skillIndex + 1) % skillList.Length;
        }
    }

    private int GetMonsterHP(string monMapID)
    {
        try
        {
            var jsonData = Bot.Flash.Call("availableMonsters");
            if (string.IsNullOrEmpty(jsonData)) return 0;

            foreach (var mon in JArray.Parse(jsonData))
            {
                if (mon?["MonMapID"]?.ToString() == monMapID)
                    return mon["intHP"]?.ToObject<int>() ?? 0;
            }
        }
        catch { }

        return 0;
    }

    private void doPriorityAttackId(int[] monsterListId)
    {
        for (int i = 0; i < monsterListId.Length; i++)
        {
            if (monsterAvailId(monsterListId[i]))
            {
                Bot.Combat.Attack(monsterListId[i]);
                return;
            }
        }
    }

    private bool monsterAvailId(int id)
    {
        var playerCell = Bot.Player.Cell;
        foreach (var mon in Bot.Monsters.MapMonsters)
        {
            if (mon.MapID == id && mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                return true;
        }
        return false;
    }

    private bool monsterAvail()
    {
        string playerCell = Bot.Player.Cell;
        foreach (var mon in Bot.Monsters.MapMonsters)
        {
            if (mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                return true;
        }
        return false;
    }

    private void jumpToAvailMonster()
    {
        foreach (var mon in Bot.Monsters.MapMonsters)
        {
            if (mon.HP > 0 && mon.State != 0)
            {
                Core.Jump(mon.Cell, "Left");
                return;
            }
        }
    }

    private void CheckConfig()
    {
        // Loop through all Option<string> in Options list
        foreach (var opt in Options.OfType<Option<string>>())
        {
            // Skip the SkipOptions entry
            if (ReferenceEquals(opt, CoreBots.Instance.SkipOptions))
                continue;

            // Get the config key from the option's name (this will be used to retrieve the value)
            string key = opt.Name;

            // Get and trim the value from Bot.Config using the option's Name (key)
            string? value = Bot.Config?.Get<string>(key)?.Trim();

            // Use DisplayName as the label for the error message
            string label = opt.DisplayName ?? opt.Name; // Fall back to Name if DisplayName is null

            // If the value is null, empty, or still equal to the default (""), log an error and stop the bot
            if (string.IsNullOrEmpty(value))
            {
                Core.Logger($"The item with enhancement '{key}' is missing. Please enter its exact in-game name (including capitalization). If unsure, use Tools > Grabber > Inventory to find it.", $"Missing Item: {key}", stopBot: true);

            }
        }
    }

    private void Prereqs()
    {
        if (Core.isCompletedBefore(9465))
            return;

        Farm.Experience(80);
        DVB.StoryLine();

        Forge.Smite();

        #region Grimgaol Prereqs
        // Smite the Boulder! (9463)
        if (!Story.QuestProgression(9463))
        {
            Core.EnsureAccept(9463);
            Adv.BuyItem("forge", 2142, 70990);
            Core.GetMapItem(12327, map: "gaolcell");
            Core.EnsureComplete(9463);
        }

        // Strike the Boulder! (9464)
        if (!Story.QuestProgression(9464))
        {
            IAM.BuyAllMerge("Scythe of Azalith");
            Core.EnsureAccept(9464);
            Core.GetMapItem(12328, map: "gaolcell");
            Core.EnsureComplete(9464);
        }

        // Smash the Boulder! (9465)
        if (!Story.QuestProgression(9465))
        {
            J6.J6(true);
            Adv.BuyItem("hyperspace", 194, "J6's Hammer");
            Core.EnsureAccept(9465);
            Core.GetMapItem(12329, map: "gaolcell");
            Core.EnsureComplete(9465);
        }
        #endregion Grimgaol Prereqs
    }

    public void SetOptions()
    {
        #region SetOptions

        Bot.Events.ScriptStopping += Core.CrashDetector;
        Bot.Events.MapChanged += Core.CleanKilledMonstersList;
        Bot.Events.MonsterKilled += Core.KilledMonsterListener;
        Bot.Events.ExtensionPacketReceived += Core.RespawnListener;
        Core.ReadCBO();

        Core.IsMember = Bot.Player.IsMember;

        // Common Options
        Bot.Options.PrivateRooms = false;
        Bot.Options.AttackWithoutTarget = false;
        Bot.Options.SafeTimings = true;
        Bot.Options.RestPackets = true && Core.ShouldRest;
        Bot.Options.AutoRelogin = true;
        Bot.Options.InfiniteRange = true;
        Bot.Options.SkipCutscenes = true;
        Bot.Options.QuestAcceptAndCompleteTries = Core.AcceptandCompleteTries;
        Bot.Drops.RejectElse = true;
        Bot.Lite.UntargetDead = true;
        Bot.Lite.UntargetSelf = true;
        Bot.Lite.ReacceptQuest = false;
        Bot.Lite.DisableRedWarning = true;
        Bot.Lite.CharacterSelectScreen = false;

        //adding sommore
        Bot.Lite.DisableDamageStrobe = true;
        Bot.Lite.DisableRedWarning = true;
        Bot.Lite.InvisibleMonsters = false;
        Bot.Lite.SmoothBackground = true;
        Bot.Lite.ShowMonsterType = true;
        Bot.Lite.CustomDropsUI = true;

        if (Bot.Flash.GetGameObject("ui.mcPopup.currentLabel") != "\"Bank\"")
            Bot.Bank.Open();
        Core.Sleep(1500);
        Bot.Bank.Load();
        Bot.Bank.Loaded = true;

        #endregion SetOptionsq
    }
}