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
using System.Diagnostics;
using Skua.Core.Models;
using System.Globalization;

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

        // Skip Enhancements
        new Option<bool>("SkipEnhancements", "Skip Item Enhancing", "If enabled, will not enhance items for the run (this doesnt mean skip enhancements you dont have... these enhancements are **VERY** important).", false),

        // Weapons
        new Option<string>("Valiance", "Weapon: Valiance", "insert name of your Valiance weapon", ""),
        new Option<string>("Dauntless", "Weapon: Dauntless", "insert name of your Dauntless weapon", ""),
        new Option<string>("Elysium", "Weapon: Elysium", "insert name of your Elysium weapon", ""),
      
        // Helm
        new Option<string>("LuckHelm", "Helm: LuckHelm", "insert name of your Lucky helm", ""),
        new Option<string>("HealerHelm", "Helm: HealerHelm", "insert name of your Healer helm", ""),
        new Option<string>("AnimaHelm", "Helm: AnimaHelm", "insert name of your AnimaHelm helm", ""),
        new Option<string>("PneumaHelm", "Helm: PneumaHelm", "insert name of your Pneuma helm", ""),
        
        // Cape
        new Option<string>("Penitence", "Cape: Penitence", "insert name of your Penitence cape", ""),
        new Option<string>("Vainglory", "Cape: Vainglory", "insert name of your Vainglory cape", ""),
        new Option<string>("HealerCape", "Cape: HealerCape", "insert name of your Healer cape", ""),
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

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

        Stopwatch runTimer = new();
        TimeSpan bestTime = TimeSpan.MaxValue;
        while (!Bot.ShouldExit && Farm.FactionRank("Grimskull Trolling") < rank)
        {
            runTimer.Restart();

            if (!Bot.Quests.IsDailyComplete(9469) && Core.HasWebBadge("SkullCrusher"))
                Core.EnsureAccept(9469);

            Core.EnsureAccept(!Core.HasWebBadge("SkullCrusher") ? 9466 : (Core.IsMember ? 9468 : 9467));

            if (Bot.Map.Name.ToLower() == "grimgaol")
            {
                Init();
                LogRun();
                continue;
            }

            Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol-100000%");
            // Core.Sleep(4000);
            Bot.Wait.ForMapLoad("grimgaol");
            Bot.Wait.ForCellChange("Enter");
            Bot.Wait.ForCellChange("Cut1");
            if (Bot.Player.Cell != "Enter")
            {
                Bot.Map.Jump("Enter", "Left", autoCorrect: false);
                Bot.Wait.ForCellChange("Enter");
            }

            Init();
            LogRun();
        }

        void LogRun()
        {
            runTimer.Stop();
            TimeSpan currentTime = runTimer.Elapsed;

            AppendRun(currentTime);
            bestTime = LoadBestTime(); // Refresh from all runs

            bool isNewPB = currentTime <= bestTime;
            Core.Logger($"Dungeon run took: {currentTime:mm\\:ss\\.fff} | Personal Best: {bestTime:mm\\:ss\\.fff}" +
                        (isNewPB ? " (New PB!)" : ""));
        }

        TimeSpan LoadBestTime()
        {
            string path = Path.Combine(ClientFileSources.SkuaScriptsDIR, "Prototypes", "GrimGaolRunTimes.txt");

            if (!File.Exists(path))
                return TimeSpan.MaxValue;

            TimeSpan best = TimeSpan.MaxValue;

            foreach (string line in File.ReadAllLines(path))
            {
                if (TimeSpan.TryParseExact(line.Trim(), "c", CultureInfo.InvariantCulture, out TimeSpan parsed) && parsed < best)
                    best = parsed;
            }

            return best;
        }

        void AppendRun(TimeSpan run)
        {
            string path = Path.Combine(ClientFileSources.SkuaScriptsDIR, "Prototypes", "GrimGaolRunTimes.txt");

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.AppendAllText(path, run.ToString("c", CultureInfo.InvariantCulture) + Environment.NewLine);
        }

        Farm.ToggleBoost(BoostType.Reputation, false);
    }

    private void Init()
    {
        if (Bot.Player.Cell.ToLower().Contains("cut"))
        {
            Core.Logger($"in {Bot.Player?.Cell} cell, jumping to enter");
            Bot.Map.Jump("Enter", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("Enter");
        }

        // Stop usage of AdvSkills after story & prereqs. as we'll use our own here.
        Bot.Skills.Stop();

        while (!Bot.ShouldExit && !Bot.TempInv.Contains("Grimskull's Gaol Cleared"))
        {
            jumpToAvailMonster();
            Core.Sleep();
            if (Bot.Player != null)
                switch (Bot.Player.Cell)
                {
                    case "Enter":
                        Enter();
                        if (Bot.Player.Cell != "r2")
                        {
                            Bot.Map.Jump("r2", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r2");
                        }
                        break;
                    case "r2":
                        R2();
                        if (Bot.Player.Cell != "r3")
                        {
                            Bot.Map.Jump("r3", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r3");
                        }
                        break;
                    case "r3":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r4")
                        {
                            Bot.Map.Jump("r4", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r4");
                        }
                        break;
                    case "r4":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r5")
                        {
                            Bot.Map.Jump("r5", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r5");
                        }
                        break;
                    case "r5":
                        R5();
                        if (Bot.Player.Cell != "r6")
                        {
                            Bot.Map.Jump("r6", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r6");
                        }
                        break;
                    case "r6":
                        R6();
                        if (Bot.Player.Cell != "r7")
                        {
                            Bot.Map.Jump("r7", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r7");
                        }
                        break;
                    case "r7":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r8")
                        {
                            Bot.Map.Jump("r8", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r8");
                        }
                        break;
                    case "r8":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r9")
                        {
                            Bot.Map.Jump("r9", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r9");
                        }
                        break;
                    case "r9":
                        R9();
                        if (Bot.Player.Cell != "r10")
                        {
                            Bot.Map.Jump("r10", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r10");
                        }
                        break;
                    case "r10":
                        R10();
                        if (Bot.Player.Cell != "r11")
                        {
                            Bot.Map.Jump("r11", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r11");
                        }
                        break;
                    case "r11":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r12")
                        {
                            Bot.Map.Jump("r12", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r12");
                        }
                        break;
                    case "r12":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Player.Cell != "r12a")
                        {
                            Bot.Map.Jump("r12a", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r12a");
                        }
                        break;
                    default:
                        break;
                }
            else
            {
                Core.Logger("Object Bot.Player is null.");
                break;
            }
            Core.Sleep();
        }

        Core.EnsureComplete(!Core.HasWebBadge("SkullCrusher") ? 9466 : (Core.IsMember ? 9468 : 9467));

        if (!Bot.Quests.IsDailyComplete(9469) && Core.HasWebBadge("SkullCrusher"))
            Core.EnsureComplete(9469);

        // Exit map after completing the quest, and Free up flash memory
        Core.Join("whitemap-100000");

        Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol-100000%");
        Bot.Wait.ForMapLoad("grimgaol");
        if (Bot.Player != null)
            Bot.Wait.ForTrue(() => Bot.Player.Loaded, 20);
    }

    private void Enter()
    {
        if (Bot.ShouldExit) return;

        if (Bot.Player.Cell != "Enter")
        {
            Core.Logger("jump to enter");
            Bot.Map.Jump("Enter", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("Enter");
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
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
            }
            if (!monsterAvail()) return;

            if (Bot.Player.Cell != "Enter")
            {
                Core.Logger("jump back to enter");
                Bot.Map.Jump("Enter", "Left", autoCorrect: false);
                Bot.Wait.ForCellChange("Enter");
                Core.Sleep(1000);
            }

            if (Bot.Player.HasTarget && Bot.Target.HasActiveAura("Talon Twisting"))
            {
                Bot.Combat.CancelAutoAttack();
                Bot.Combat.StopAttacking = true;
                Bot.Sleep(500);
                Bot.Wait.ForTrue(() => Bot.Target.HasActiveAura("Retaliate"), 20);
                Bot.Sleep(Bot.Target.Auras.Where(a => a.Name == "Retaliate").FirstOrDefault()?.SecondsRemaining() ?? 2500);
                Bot.Combat.StopAttacking = false;
                skillIndex = 0; // Reset skill index after stopping skills
                Bot.Skills.Start();
            }

            if (!Bot.Player.HasTarget)
            {
                Bot.Combat.Attack("*");
                Core.Sleep();
            }

            if (!Bot.Self.HasActiveAura("Shackled") && skillIndex == 0 && Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }

            if (Bot.Player.HasTarget && skillIndex != 0)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
            }

            skillIndex = (skillIndex + 1) % skillList.Length;

        }
    }

    private void R2()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r2")
        {
            Core.Logger("jump to r2");
            Bot.Map.Jump("r2", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r2");
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
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
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
            Bot.Map.Jump("r4", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r4");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();
        if (!monsterAvail())
        {
            return;
        }

        #region equip and enh
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
        #endregion equip and enh

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
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
            Bot.Map.Jump("r5", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r5");
        }
        Core.Sleep(1000);
        jumpToAvailMonster();
        if (!monsterAvail())
        {
            return;
        }

        #region Equipment Setup
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

        string? PneumaHelm = Bot.Config.Get<string>("PneumaHelm");
        if (!string.IsNullOrWhiteSpace(PneumaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(PneumaHelm))
            {
                Bot.Inventory.EquipItem(PneumaHelm);
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
        #endregion Equipment Setup

        int skillIndex = 0;
        int[] skillList = { 4, 1, 2, 4, 2, 3, 2 };
        int[] priorityIDs = { 7, 8, 9 };

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
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

        // Jump to r6 if not already there
        if (Bot.Player.Cell != "r6")
        {
            Core.Logger("jump to r6");
            Bot.Map.Jump("r6", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r6");
        }

        if (!monsterAvail()) return;

        #region Equipment Setup
        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Void Highlord"))
        {
            Bot.Inventory.EquipItem("Void Highlord");
            Core.Sleep(1500);
        }

        string? dauntless = Bot.Config!.Get<string>("Dauntless");
        string? valiance = Bot.Config.Get<string>("Valiance");
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
        if (!string.IsNullOrWhiteSpace(animaHelm))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(animaHelm))
            {
                Bot.Inventory.EquipItem(animaHelm);
                Core.Sleep(1500);
            }
        }

        string? Penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(Penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(Penitence))
            {
                Bot.Inventory.EquipItem(Penitence);
                Core.Sleep(1500);
            }
        }
        #endregion

        Core.OneTimeMessage("Fell Statue",
            "Due to server delays and things out of my control... you may still die to it over-attacking by one during the `Crit Damage Amplified` aura.");

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };
        int skillCount = 0;
        bool switchTarget = false;
        while (!Bot.ShouldExit)
        {
            // Wait until player is alive
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(100);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    skillCount = 0;
                }
            }

            if (!monsterAvail()) return;

            foreach (Monster m in Bot.Monsters.CurrentAvailableMonsters)
            {
                Bot.Sleep(500); // Small delay for target swap

                while (!Bot.ShouldExit)
                {
                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                    {
                        Bot.Sleep(100);
                        if (Bot.Player.Alive)
                        {
                            skillIndex = 0;
                            skillCount = 0;
                            switchTarget = true;
                            break;
                        }
                    }

                    if (switchTarget)
                        break; // <-- breaks out of ②, goes to next monster in foreach

                    if (!monsterAvail()) return;

                    // Break after certain cycles to re-target
                    if (skillCount >= 5)
                    {
                        Bot.Combat.CancelAutoAttack();
                        Bot.Combat.CancelTarget();
                        skillCount = 0;
                        skillIndex = 0;
                        break;
                    }

                    Bot.Combat.Attack(m.MapID);

                    if (Bot.Player.HasTarget)
                    {
                        if (Bot.Player.Health <= 2500)
                            Bot.Skills.UseSkill(2); // Emergency heal/defense
                        else
                            Bot.Skills.UseSkill(skillList[skillIndex]);

                        // Always advance rotation, even if low HP skill is used
                        skillIndex = (skillIndex + 1) % skillList.Length;
                    }

                    Core.Sleep();
                    skillCount++;
                }
            }
        }
    }


    private void R9()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r9")
        {
            Core.Logger("jump to r9");
            Bot.Map.Jump("r9", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r9");
        }
        Core.Sleep(1000);
        if (!monsterAvail())
        {
            return;
        }

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
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
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
            Bot.Map.Jump("r10", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r10");
        }
        Core.Sleep(1000);
        if (!monsterAvail())
        {
            return;
        }

        #region Equipment Setup

        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Dragon of Time"))
        {
            Bot.Inventory.EquipItem("Dragon of Time");
            Core.Sleep(1500);
        }

        string? elysium = Bot.Config!.Get<string>("Elysium");
        if (!string.IsNullOrWhiteSpace(elysium))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(elysium))
            {
                Bot.Inventory.EquipItem(elysium);
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

        string? Penitence = Bot.Config.Get<string>("Penitence");
        if (!string.IsNullOrWhiteSpace(Penitence))
        {
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(Penitence))
            {
                Bot.Inventory.EquipItem(Penitence);
                Core.Sleep(1500);
            }
        }
        #endregion Equipment Setup

        int skillIndex = 0;
        int[] skillList = { 1, 2, 4, 2, 3, 2 };

        string monsId = "16";
        int monsIdInt = 16;

        while (!Bot.ShouldExit)
        {
            while (!Bot.ShouldExit && !Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                {
                    skillIndex = 0;
                    continue;
                }
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
            Core.Logger($"Jumping to {cell}");
            Bot.Map.Jump(cell, "Left", autoCorrect: false);
            Bot.Wait.ForCellChange(cell);
        }

        jumpToAvailMonster();
        if (!monsterAvail()) return;

        #region Equipment Setup
        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped("Verus DoomKnight"))
            Bot.Inventory.EquipItem("Verus DoomKnight");

        string? dauntless = Bot.Config!.Get<string>("Dauntless");
        if (!string.IsNullOrWhiteSpace(dauntless))
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(dauntless))
                Bot.Inventory.EquipItem(dauntless);

        string? helm = cell is "r11" or "r12"
            ? Bot.Config.Get<string>("LuckHelm")
            : Bot.Config.Get<string>("AnimaHelm");

        if (!string.IsNullOrWhiteSpace(helm))
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(helm))
                Bot.Inventory.EquipItem(helm);

        string? vainglory = Bot.Config.Get<string>("Vainglory");
        if (!string.IsNullOrWhiteSpace(vainglory))
            while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(vainglory))
                Bot.Inventory.EquipItem(vainglory);
        #endregion

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            if (!Bot.Player.Alive)
            {
                Bot.Sleep(500);
                if (Bot.Player.Alive)
                    skillIndex = 0;
                continue;
            }

            if (Bot.Player.Cell != cell)
            {
                Bot.Map.Jump(cell, "Left", autoCorrect: false);
                Bot.Wait.ForCellChange(cell);
            }

            if (!monsterAvail()) return;

            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");

            if (Bot.Player.Health <= 2500)
                Bot.Skills.UseSkill(2);

            if (Bot.Player.HasTarget)
                Bot.Skills.UseSkill(skillList[skillIndex]);

            skillIndex = (skillIndex + 1) % skillList.Length;
        }
    }

    private int GetMonsterHP(string monMapID)
    {
        try
        {
            string? jsonData = Bot.Flash.Call("availableMonsters");
            if (string.IsNullOrWhiteSpace(jsonData)) return 0;

            foreach (var mon in JArray.Parse(jsonData))
                if (mon?["MonMapID"]?.ToString() == monMapID)
                    return mon["intHP"]?.ToObject<int>() ?? 0;
        }
        catch { }

        return 0;
    }

    private void doPriorityAttackId(int[] monsterListId)
    {
        foreach (int id in monsterListId)
            if (monsterAvailId(id))
            {
                Bot.Combat.Attack(id);
                return;
            }
    }

    private bool monsterAvailId(int id)
    {
        string playerCell = Bot.Player.Cell;
        foreach (var mon in Bot.Monsters.MapMonsters)
            if (mon.MapID == id && mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                return true;

        return false;
    }

    private bool monsterAvail()
    {
        string playerCell = Bot.Player.Cell;
        foreach (var mon in Bot.Monsters.MapMonsters)
            if (mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                return true;

        return false;
    }

    private void jumpToAvailMonster()
    {
        foreach (var mon in Bot.Monsters.MapMonsters)
            if (mon.HP > 0 && mon.State != 0)
            {
                Bot.Map.Jump(mon.Cell, "Left", autoCorrect: false);
                Bot.Wait.ForCellChange(mon.Cell);
                return;
            }
    }

    private void CheckConfig()
    {
        // Load config values into dictionary
        Dictionary<string, string?> gear = new()
    {
        // Weapon Enhancements
        { "Dauntless", Bot.Config!.Get<string>("Dauntless") },
        { "Valiance", Bot.Config.Get<string>("Valiance") },
        { "Elysium",  Bot.Config.Get<string>("Elysium") },

        // Cape Enhancements
        { "Vainglory", Bot.Config.Get<string>("Vainglory") },
        { "Penitence", Bot.Config.Get<string>("Penitence") },
        { "HealerCape", Bot.Config.Get<string>("HealerCape") },

        // Helm Enhancements
        { "PneumaHelm", Bot.Config.Get<string>("PneumaHelm")},
        { "AnimaHelm", Bot.Config.Get<string>("AnimaHelm") },
        { "HealerHelm", Bot.Config.Get<string>("HealerHelm") },
        { "WizHelm",  Bot.Config.Get<string>("WizHelm") },
        { "LuckHelm", Bot.Config.Get<string>("LuckHelm") },
    };

        // Require critical classes and log what's missing
        string[] requiredClasses = { "Dragon of Time", "Void Highlord", "Verus DoomKnight", };
        string[] missingClasses = requiredClasses
            .Where(c => !Core.CheckInventory(c))
            .ToArray();

        if (missingClasses.Length > 0)
        {
            Core.Logger(
                "You are missing one or more required classes:\n" +
                $"- {string.Join("\n- ", missingClasses)}",
                stopBot: true);
        }

        // Filter non-null and non-whitespace items and cast to non-nullable string
        List<string> requiredItems = gear.Values
     .Where(item => !string.IsNullOrWhiteSpace(item))
     .Select(item => item!) // Cast to non-nullable string
     .Where(item => !Bot.Inventory.IsEquipped(item) && !Bot.Bank.Contains(item))
     .ToList();

        Core.CheckInventory(requiredItems.ToArray());


        // Determine whether to skip enhancements
        bool skipEnh = Bot.Config.Get<bool>("SkipEnhancements");

        // Validate config values
        foreach (var opt in Options.OfType<Option<string>>())
        {
            if (ReferenceEquals(opt, CoreBots.Instance.SkipOptions))
                continue;

            if (!gear.TryGetValue(opt.Name, out string? value))
                continue;

            if (string.IsNullOrWhiteSpace(value))
            {
                Core.Logger(
                    $"The item for enhancement '{opt.Name}' is missing.\n" +
                    $"Go to: Scripts > [Edit Script Options], then enter the exact item name (case-sensitive).\n" +
                    $"Use Tools > Grabber > Inventory to get the correct name.",
                    $"Missing Item: {opt.Name}",
                    stopBot: true);
            }
        }

        // Precompile lowercase name list for comparison
        HashSet<string> allItemNames = Bot.Inventory.Items
            .Concat(Bot.Bank.Items)
            .Select(i => i.Name.ToLowerInvariant().Trim())
            .ToHashSet();

        // Enhancement result log
        List<string> summaryLogs = new();

        void EnhanceIfFound(string? name, EnhancementType type, CapeSpecial cape = CapeSpecial.None, HelmSpecial helm = HelmSpecial.None, WeaponSpecial weapon = WeaponSpecial.None)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            if (!Core.CheckInventory(name))
            {
                string key = name.ToLowerInvariant().Trim();
                if (allItemNames.Contains(key))
                    Core.Logger($"[WARN] \"{name}\" is in inventory/bank but may have a capitalization/spacing mismatch.");
                else
                    Core.Logger($"[MISSING] Enhancement target \"{name}\" not found in inventory or bank.");
                return;
            }

            if (!skipEnh)
            {
                Adv.EnhanceItem(name, type, cape, helm, weapon, logging: false);
                summaryLogs.Add($"- {name}: {type}" +
                    (weapon != WeaponSpecial.None ? $" ({weapon})" :
                     cape != CapeSpecial.None ? $" ({cape})" :
                     helm != HelmSpecial.None ? $" ({helm})" : ""));
            }
        }

        // Static class enhancements
        EnhanceIfFound("Void Highlord", EnhancementType.Lucky);
        EnhanceIfFound("Verus DoomKnight", EnhancementType.Lucky);
        EnhanceIfFound("Dragon of Time", EnhancementType.Healer);

        // Weapon enhancements
        EnhanceIfFound(gear["Valiance"], EnhancementType.Lucky, weapon: WeaponSpecial.Valiance);
        EnhanceIfFound(gear["Dauntless"], EnhancementType.Lucky, weapon: WeaponSpecial.Dauntless);
        EnhanceIfFound(gear["Elysium"], EnhancementType.Healer, weapon: WeaponSpecial.Elysium);

        // Helm enhancements
        EnhanceIfFound(gear["WizHelm"], EnhancementType.Wizard);
        EnhanceIfFound(gear["LuckHelm"], EnhancementType.Lucky);
        EnhanceIfFound(gear["HealerHelm"], EnhancementType.Healer);
        EnhanceIfFound(gear["AnimaHelm"], EnhancementType.Lucky, helm: HelmSpecial.Anima);

        // Cape enhancements
        EnhanceIfFound(gear["HealerCape"], EnhancementType.Healer);
        EnhanceIfFound(gear["Penitence"], EnhancementType.Lucky, cape: CapeSpecial.Penitence);
        EnhanceIfFound(gear["Vainglory"], EnhancementType.Lucky, cape: CapeSpecial.Vainglory);

        // Final log
        if (!skipEnh)
            foreach (string log in summaryLogs)
                Core.Logger(log);
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

    // public void SetOptions()
    // {
    //     #region SetOptions

    //     Bot.Events.ScriptStopping += Core.CrashDetector;
    //     Bot.Events.MapChanged += Core.CleanKilledMonstersList;
    //     Bot.Events.MonsterKilled += Core.KilledMonsterListener;
    //     Bot.Events.ExtensionPacketReceived += Core.RespawnListener;


    //     Core.ReadCBO();

    //     Core.IsMember = Bot.Player.IsMember;

    //     // Common Options
    //     Bot.Options.PrivateRooms = false;
    //     Bot.Options.AttackWithoutTarget = false;
    //     Bot.Options.SafeTimings = true;
    //     Bot.Options.RestPackets = true && Core.ShouldRest;
    //     Bot.Options.AutoRelogin = true;
    //     Bot.Options.InfiniteRange = true;
    //     Bot.Options.SkipCutscenes = true;
    //     Bot.Options.QuestAcceptAndCompleteTries = Core.AcceptandCompleteTries;
    //     Bot.Drops.RejectElse = true;
    //     Bot.Lite.UntargetDead = true;
    //     Bot.Lite.UntargetSelf = true;
    //     Bot.Lite.ReacceptQuest = false;
    //     Bot.Lite.DisableRedWarning = true;
    //     Bot.Lite.CharacterSelectScreen = false;

    //     //adding sommore
    //     Bot.Lite.DisableDamageStrobe = true;
    //     Bot.Lite.DisableRedWarning = true;
    //     Bot.Lite.InvisibleMonsters = false;
    //     Bot.Lite.SmoothBackground = true;
    //     Bot.Lite.ShowMonsterType = true;
    //     Bot.Lite.CustomDropsUI = true;

    //     if (Bot.Flash.GetGameObject("ui.mcPopup.currentLabel") != "\"Bank\"")
    //         Bot.Bank.Open();
    //     Core.Sleep(1500);
    //     Bot.Bank.Load();
    //     Bot.Bank.Loaded = true;

    //     #endregion SetOptionsq
    // }

}