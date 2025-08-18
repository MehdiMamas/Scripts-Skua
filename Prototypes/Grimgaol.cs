/*
name: Grimgoal
description: Goes through the grimgaol dungeon... Testing Phase
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


    Stopwatch runTimer = new();
    TimeSpan bestTime = TimeSpan.MaxValue;
    int RunCount = 0;

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
        new Option<bool>("RoomTimers", "Time each room?", "If enabled, this will log the time for each room into chat/the Logs > scripts tab.", false),

        // Weapons
        new Option<string>("Valiance", "Weapon: Valiance", "insert name of your Valiance weapon", ""),
        new Option<string>("Dauntless", "Weapon: Dauntless", "insert name of your Dauntless weapon ( this will be subbed with valiance if u dont have dsuant so just copy valiance weapon name here)", ""),
        new Option<string>("Elysium", "Weapon: Elysium", "insert name of your Elysium weapon", ""),
      
        // Helm
        new Option<string>("LuckHelm", "Helm: LuckHelm", "insert name of your Lucky helm", ""),
        new Option<string>("HealerHelm", "Helm: HealerHelm", "insert name of your Healer helm (used for DoT Sheltons)", ""),
        new Option<string>("AnimaHelm", "Helm: AnimaHelm", "insert name of your AnimaHelm helm", ""),
        new Option<string>("PneumaHelm", "Helm: PneumaHelm", "insert name of your Pneuma helm (used for VHL Sheltons)", ""),
        
        // Cape
        new Option<string>("Penitence", "Cape: Penitence", "insert name of your Penitence cape", ""),
        new Option<string>("Vainglory", "Cape: Vainglory", "insert name of your Vainglory cape", ""),
        new Option<string>("HealerCape", "Cape: HealerCape", "insert name of your Healer cape", ""),
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions(disableClassSwap: true);

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
        Bot.Options.RestPackets = true;
        Core.Logger("Prerequisites and configurations checked successfully.");

        Core.Logger($"Farming rank {rank} Grimskull Trolling reputation.");

        Farm.ToggleBoost(BoostType.Reputation);
        while (!Bot.ShouldExit && Farm.FactionRank("Grimskull Trolling") < rank)
        {
            if (!Bot.Quests.IsDailyComplete(9469) && Core.HasWebBadge("SkullCrusher"))
                Core.EnsureAccept(9469);

            Core.EnsureAccept(!Core.HasWebBadge("SkullCrusher") ? 9466 : (Core.IsMember ? 9468 : 9467));

            if (Bot.Map.Name.ToLower() == "grimgaol")
            {
                Core.Logger("Already in the dungeon (weird flex but ok)... we'll continue from where you left off");
                Init();
                continue;
            }
            else
            {
                Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol-100000%");

                while (!Bot.ShouldExit && Bot.Map.Name != "grimgaol") { Bot.Sleep(100); }

                // Incase we're in the Cutscene cell
                if (Bot.Player.Cell != "Enter")
                    Bot.Map.Jump("Enter", "Spawn", autoCorrect: false);

                Init();
            }
        }

        Core.Logger($"Runs Complete: {RunCount}");
        Farm.ToggleBoost(BoostType.Reputation, false);
    }

    const int MaxBackupRuns = 50;

    void LogRun()
    {
        runTimer.Stop();
        TimeSpan currentTime = runTimer.Elapsed;
        if (currentTime < TimeSpan.Zero)
            currentTime = TimeSpan.Zero;

        AppendRun(currentTime);

        TimeSpan bestTime = LoadBestTime();
        bool isNewPB = currentTime < bestTime;

        Core.Logger($"Dungeon run took: {currentTime:mm\\:ss\\.fff} | Personal Best: {(bestTime == TimeSpan.MaxValue ? "N/A" : bestTime.ToString("mm\\:ss\\.fff"))}" +
                    (isNewPB ? " (New PB!)" : ""));
    }

    TimeSpan LoadBestTime()
    {
        string path = Path.Combine(ClientFileSources.SkuaScriptsDIR, "Prototypes", "GrimGaolRunTimes.txt");
        string backupPath = Path.Combine(ClientFileSources.SkuaScriptsDIR, "Prototypes", "GrimGaolRunTimes_backup.txt");

        // Auto-restore from backup if main file missing or empty
        if (!File.Exists(path) || new FileInfo(path).Length == 0)
        {
            if (File.Exists(backupPath))
            {
                File.Copy(backupPath, path, overwrite: true);
                Core.Logger("Main run file missing or empty, restored from backup.");
            }
            else
            {
                return TimeSpan.MaxValue; // No data at all
            }
        }

        TimeSpan best = TimeSpan.MaxValue;
        List<string> validLines = new();

        foreach (string line in File.ReadAllLines(path))
        {
            string trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed))
                continue;

            if (TimeSpan.TryParseExact(trimmed, "c", CultureInfo.InvariantCulture, out TimeSpan parsed) && parsed >= TimeSpan.Zero)
            {
                validLines.Add(parsed.ToString("c", CultureInfo.InvariantCulture));
                if (parsed < best)
                    best = parsed;
            }
        }

        // If all lines were invalid, try restore from backup
        if (validLines.Count == 0 && File.Exists(backupPath))
        {
            File.Copy(backupPath, path, overwrite: true);
            Core.Logger("All main file entries were invalid, restored from backup.");
            foreach (string line in File.ReadAllLines(path))
            {
                if (TimeSpan.TryParseExact(line.Trim(), "c", CultureInfo.InvariantCulture, out TimeSpan parsed) && parsed >= TimeSpan.Zero)
                {
                    validLines.Add(parsed.ToString("c", CultureInfo.InvariantCulture));
                    if (parsed < best)
                        best = parsed;
                }
            }
        }

        // Rewrite main file with only valid entries
        if (validLines.Count > 0)
            File.WriteAllLines(path, validLines);

        // Maintain backup with last MaxBackupRuns
        if (validLines.Count > 0)
        {
            List<string> backupLines = validLines.Count > MaxBackupRuns
                ? validLines.GetRange(validLines.Count - MaxBackupRuns, MaxBackupRuns)
                : new List<string>(validLines);

            File.WriteAllLines(backupPath, backupLines);
        }

        return best;
    }

    void AppendRun(TimeSpan run)
    {
        if (run < TimeSpan.Zero)
            run = TimeSpan.Zero;

        string path = Path.Combine(ClientFileSources.SkuaScriptsDIR, "Prototypes", "GrimGaolRunTimes.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        try
        {
            File.AppendAllText(path, run.ToString("c", CultureInfo.InvariantCulture) + Environment.NewLine);
        }
        catch (IOException ex)
        {
            Core.Logger($"Failed to write run time: {ex.Message}");
        }
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
        while (!Bot.ShouldExit && !Bot.TempInv.Contains("Grimskull's Gaol Cleared"))
        {
            jumpToAvailMonster();
            Bot.Skills.Stop();
            if (Bot.Player != null)
                switch (Bot.Player.Cell)
                {
                    case "Enter":
                        // Start runtime here
                        runTimer.Restart();
                        Enter();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"Enter\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r2")
                        {
                            Bot.Map.Jump("r2", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r2");
                        }
                        break;
                    case "r2":
                        R2();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r2\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r3")
                        {
                            Bot.Map.Jump("r3", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r3");
                        }
                        break;
                    case "r3":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r3\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r4")
                        {
                            Bot.Map.Jump("r4", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r4");
                        }
                        break;
                    case "r4":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r4\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r5")
                        {
                            Bot.Map.Jump("r5", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r5");
                        }
                        break;
                    case "r5":
                        R5();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r5\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r6")
                        {
                            Bot.Map.Jump("r6", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r6");
                        }
                        break;
                    case "r6":
                        R6();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r6\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r7")
                        {
                            Bot.Map.Jump("r7", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r7");
                        }
                        break;
                    case "r7":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r7\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r8")
                        {
                            Bot.Map.Jump("r8", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r8");
                        }
                        break;
                    case "r8":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r8\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r9")
                        {
                            Bot.Map.Jump("r9", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r9");
                        }
                        break;
                    case "r9":
                        R9();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r9\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r10")
                        {
                            Bot.Map.Jump("r10", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r10");
                        }
                        break;
                    case "r10":
                        R10();
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r10\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r11")
                        {
                            Bot.Map.Jump("r11", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r11");
                        }
                        break;
                    case "r11":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r11\" Done in: {runTimer.Elapsed}");
                        if (Bot.Player.Cell != "r12")
                        {
                            Bot.Map.Jump("r12", "Left", autoCorrect: false);
                            Bot.Wait.ForCellChange("r12");
                        }
                        break;
                    case "r12":
                        RVDK(Bot.Player.Cell);
                        if (Bot.Config!.Get<bool>("RoomTimers"))
                            Core.Logger($"Room \"r12\" Done in: {runTimer.Elapsed}");
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

        // End runtime here
        if (Core.CheckInventory("Grimskull's Gaol Cleared"))
        {
            Core.Logger($"Runs Complete: {RunCount++}");
            LogRun();
        }

        Core.EnsureComplete(!Core.HasWebBadge("SkullCrusher") ? 9466 : (Core.IsMember ? 9468 : 9467));

        if (!Bot.Quests.IsDailyComplete(9469) && Core.HasWebBadge("SkullCrusher"))
            Core.EnsureComplete(9469);

        Core.Join("whitemap-100000");

        Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol-100000%");
        Bot.Wait.ForMapLoad("grimgaol");
        if (Bot.Player != null)
            Bot.Wait.ForTrue(() => Bot.Player.Loaded, 20);
    }

    #region These are fine
    private void Enter()
    {
        if (Bot.ShouldExit) return;

        if (Bot.Player.Cell != "Enter")
        {
            Core.Logger("jump to enter");
            Bot.Map.Jump("Enter", "Spawn", autoCorrect: false);
            Bot.Wait.ForCellChange("Enter");
        }

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Void Highlord");

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(dauntless) ? dauntless : valiance);

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(animaHelm) ? animaHelm : luckHelm);

        string? penitence = Bot.Config.Get<string>("Penitence");
        string? vainglory = Bot.Config.Get<string>("Vainglory");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(vainglory) ? vainglory : penitence);
        #endregion

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
                Bot.Sleep(Bot.Target.Auras.FirstOrDefault(a => a.Name == "Retaliate")?.SecondsRemaining() ?? 2500);
                Bot.Combat.StopAttacking = false;
                skillIndex = 0;
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

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Void Highlord");

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(dauntless) ? dauntless : valiance);

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(animaHelm) ? animaHelm : luckHelm);

        string? penitence = Bot.Config.Get<string>("Penitence");
        string? vainglory = Bot.Config.Get<string>("Vainglory");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(vainglory) ? vainglory : penitence);
        #endregion

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

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Legion Revenant");

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(dauntless) ? dauntless : valiance);

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(animaHelm) ? animaHelm : luckHelm);

        string? penitence = Bot.Config.Get<string>("Penitence");
        string? vainglory = Bot.Config.Get<string>("Vainglory");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(vainglory) ? vainglory : penitence);
        #endregion

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

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Void Highlord");

        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(dauntless) ? dauntless : valiance);

        string? animaHelm = Bot.Config.Get<string>("AnimaHelm");
        string? luckHelm = Bot.Config.Get<string>("LuckHelm");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(animaHelm) ? animaHelm : luckHelm);

        string? penitence = Bot.Config.Get<string>("Penitence");
        string? vainglory = Bot.Config.Get<string>("Vainglory");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(vainglory) ? vainglory : penitence);
        #endregion

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

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Dragon of Time");

        string? elysium = Bot.Config!.Get<string>("Elysium");
        EquipIfAvailable(elysium);

        string? wizHelm = Bot.Config.Get<string>("WizHelm");
        EquipIfAvailable(wizHelm);

        string? penitence = Bot.Config.Get<string>("Penitence");
        EquipIfAvailable(penitence);
        #endregion

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

            if (!monsterAvail()) return;

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

        // Jump to cell if needed
        if (Bot.Player.Cell != cell)
        {
            Core.Logger($"Jumping to {cell}");
            Bot.Map.Jump(cell, "Left", autoCorrect: false);
            Bot.Wait.ForCellChange(cell);
        }

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable("Verus DoomKnight");

        string? dauntless = Bot.Config!.Get<string>("Dauntless"); // fixed typo
        EquipIfAvailable(dauntless);

        string? helm = cell is "r11" or "r12"
            ? Bot.Config.Get<string>("LuckHelm")
            : Bot.Config.Get<string>("AnimaHelm");
        EquipIfAvailable(helm);

        string? vainglory = Bot.Config.Get<string>("Vainglory"); // fixed typo
        EquipIfAvailable(vainglory);
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

            // Ensure we're still in the right cell
            if (Bot.Player.Cell != cell)
            {
                Bot.Map.Jump(cell, "Left", autoCorrect: false);
                Bot.Wait.ForCellChange(cell);
            }

            if (!monsterAvail()) return;

            // Start attack if no target
            if (!Bot.Player.HasTarget)
                Bot.Combat.Attack("*");

            // Heal if needed
            if (Bot.Player.Health <= 2500)
                Bot.Skills.UseSkill(2);

            // Use next skill
            if (Bot.Player.HasTarget)
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
            }

            Bot.Sleep(100); // prevent skill spam
        }
    }
    #endregion


    private void R5()
    {
        if (Bot.ShouldExit) return;
        if (Bot.Player.Cell != "r5")
        {
            Core.Logger("jump to r5");
            Bot.Map.Jump("r5", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r5");
        }

        if (!monsterAvail()) return;
        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        string? valiance = Bot.Config!.Get<string>("Valiance");
        string? elysium = Bot.Config.Get<string>("Elysium");
        string? dauntless = Bot.Config.Get<string>("Dauntless");
        string? healerHelm = Bot.Config.Get<string>("HealerHelm");
        string? pneumaHelm = Bot.Config.Get<string>("PneumaHelm");
        string? penitence = Bot.Config.Get<string>("Penitence");

        bool useDoT = Adv.uElysium() && !string.IsNullOrWhiteSpace(elysium);

        string? weapon = null;
        if (useDoT)
        {
            if (!string.IsNullOrWhiteSpace(elysium))
                weapon = elysium;
            else if (!string.IsNullOrWhiteSpace(valiance))
                weapon = valiance;
        }
        else
        {
            if (Adv.uDauntless() && !string.IsNullOrWhiteSpace(dauntless))
                weapon = dauntless;
            else if (!string.IsNullOrWhiteSpace(valiance))
                weapon = valiance;
        }

        EquipIfAvailable(useDoT ? "Dragon of Time" : "Void Highlord");
        EquipIfAvailable(weapon);
        EquipIfAvailable(useDoT ? healerHelm : pneumaHelm);
        EquipIfAvailable(penitence);
        #endregion Equipment Setup

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 2, 4 };
        int skillID = skillList[skillIndex];
        int DeathCount = 0;
        while (!Bot.ShouldExit)
        {
            foreach (Monster mon in Bot.Monsters.CurrentAvailableMonsters)
            {

                while (!Bot.ShouldExit)
                {
                    if (mon == null)
                        continue;

                    if (!monsterAvail())
                    {
                        Core.Logger($"DeathCount: {DeathCount}");
                        return;
                    }

                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                    {
                        DeathCount++;
                        Bot.Sleep(500);
                        if (Bot.Player.Alive)
                        {
                            skillIndex = 0;
                            continue;
                        }
                    }

                    if (!Bot.Player.HasTarget)
                        Bot.Combat.Attack(mon.MapID);

                    if (Bot.Player.HasTarget)
                    {
                        if (Bot.Player.Health < 1500 && Bot.Skills.CanUseSkill(2))
                            Bot.Skills.UseSkill(2);
                        else if (Bot.Player.Health > 4000)
                            Bot.Skills.UseSkill(Bot.Skills.CanUseSkill(1) ? 1 : 3);
                        else
                        {
                            Bot.Skills.UseSkill(skillList[skillIndex]);
                            skillIndex = (skillIndex + 1) % skillList.Length;
                        }
                    }

                    if (Bot.Player.HasTarget && Bot.Target.HasActiveAura("Crashed"))
                    {
                        // Core.Logger("Aura: \"Crashed\" Detected! Damage Time!!");
                        Monster? crashedMon = mon ?? Bot.Monsters.CurrentAvailableMonsters.FirstOrDefault(x => x != null && GetMonsterHP(x.MapID.ToString()) > 0);
                        if (crashedMon != null)
                            Crashed(crashedMon);
                        else
                            Core.Logger("No valid monster found for \"Crashed\" aura.");
                    }
                }
            }
        }

        void Crashed(Monster mon)
        {
            if (!Bot.Player.HasTarget || (Bot.Player.HasTarget && !Bot.Target.HasActiveAura("Crashed")) || !Bot.Player.Alive)
                return;

            while (!Bot.ShouldExit && Bot.Player.HasTarget && Bot.Target.HasActiveAura("Crashed"))
            {
                if (!Bot.Player.Alive)
                    return;

                Bot.Combat.Attack(mon.MapID);
                Bot.Sleep(500);
                if (Bot.Player.HasTarget)
                {
                    Bot.Skills.UseSkill(skillList[skillIndex]);
                    skillIndex = (skillIndex + 1) % skillList.Length;
                }

                if (!monsterAvail() || !Bot.Player.Alive || Bot.Player.HasTarget && Bot.Target.HasActiveAura("Ludicrous Speed") || !Bot.Target.HasActiveAura("Crashed"))
                    return;
            }
        }
    }

    private void R6()
    {
        if (Bot.ShouldExit) return;

        if (Bot.Player.Cell != "r6")
        {
            Core.Logger("Jumping to r6");
            Bot.Map.Jump("r6", "Left", autoCorrect: false);
            Bot.Wait.ForCellChange("r6");
        }

        if (!monsterAvail()) return;

        Bot.Player.SetSpawnPoint();

        #region Equipment Setup
        EquipIfAvailable(Core.CheckInventory("Chaos Avenger") ? "Chaos Avenger" : "Void Highlord");

        string? dauntless = Bot.Config!.Get<string>("Dauntless");
        string? valiance = Bot.Config.Get<string>("Valiance");
        EquipIfAvailable(!string.IsNullOrWhiteSpace(dauntless) ? dauntless : valiance);

        EquipIfAvailable(Bot.Config.Get<string>("AnimaHelm"));
        EquipIfAvailable(Bot.Config.Get<string>("Penitence"));
        #endregion Equipment Setup

        int skillIndex = 0;
        int[] skillList = Bot.Inventory.Contains("Chaos Avenger") ? new[] { 4, 1, 3 } : new[] { 2, 4 };

        while (!Bot.ShouldExit)
        {
            if (!monsterAvail()) return;

            foreach (Monster m in Bot.Monsters.CurrentAvailableMonsters)
            {
                while (!Bot.ShouldExit)
                {
                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                    {
                        Bot.Sleep(100);
                        if (Bot.Player.Alive)
                        {
                            skillIndex = 0;
                            break;
                        }
                    }

                    if (!monsterAvail()) return;

                    if (Bot.Target.HasActiveAura("Crit Damage Amplified"))
                    {
                        Bot.Combat.CancelAutoAttack();
                        Bot.Combat.CancelTarget();
                        skillIndex = 0;
                        break;
                    }

                    if (!Bot.Player.HasTarget)
                        Bot.Combat.Attack(m.MapID);

                    if (Bot.Player.HasTarget)
                    {
                        if (!Core.CheckInventory("Chaos Avenger") && Bot.Player.Health <= 2500)
                            Bot.Skills.UseSkill(2);
                        else
                        {
                            Bot.Skills.UseSkill(skillList[skillIndex]);
                            skillIndex = (skillIndex + 1) % skillList.Length;
                        }
                    }

                    Core.Sleep();
                }
            }
        }


    }

    void EquipIfAvailable(string? itemName, int sleepMs = 500)
    {
        if (string.IsNullOrWhiteSpace(itemName))
            return;

        // Handle special IoDA case
        if (itemName == "Void Highlord")
        // Check if VHL (IoDA) is owned, use that if its rank 10, else normal vhl
            itemName = (Core.CheckInventory("Void HighLord (IoDA)") && Core.CheckClassRank(false, "Void HighLord (IoDA)") == 10) ? "Void HighLord (IoDA)" : "Void Highlord";

        // Use this to unbank if we own it.
        if (!Core.CheckInventory(itemName))
        {
            Core.Logger($"[EquipIfAvailable] Item not found in inventory or bank: \"{itemName}\"");
            return;
        }

        // Keep trying until equipped or script exits
        while (!Bot.ShouldExit && !Bot.Inventory.IsEquipped(itemName))
        {
            Bot.Inventory.EquipItem(itemName);
            Core.Sleep(sleepMs);
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
                if (Bot.Player.Cell != mon.Cell)
                {
                    Bot.Map.Jump(mon.Cell, "Left", autoCorrect: false);
                    Bot.Wait.ForCellChange(mon.Cell);
                }
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
        string[] requiredClasses = { "Dragon of Time", Core.CheckInventory("Void HighLord (IoDA)") ? "Void HighLord (IoDA)" : "Void Highlord", "Verus DoomKnight", };

        // Extra Class for statues; CaV
        if (Core.CheckInventory("Chaos Avenger"))
        {
            Bot.Log("Chaos Avenger Found, we'll use this for the Fallen Statues");
        }

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
        if (Core.CheckInventory("Chaos Avenger"))
            EnhanceIfFound("Chaos Avenger", EnhancementType.Lucky);

        // Weapon enhancements
        EnhanceIfFound(gear["Valiance"], EnhancementType.Lucky, weapon: WeaponSpecial.Valiance);
        EnhanceIfFound(gear["Dauntless"], EnhancementType.Lucky, weapon: WeaponSpecial.Dauntless);
        EnhanceIfFound(gear["Elysium"], EnhancementType.Healer, weapon: WeaponSpecial.Elysium);

        // Helm enhancements
        EnhanceIfFound(gear["WizHelm"], EnhancementType.Wizard);
        EnhanceIfFound(gear["LuckHelm"], EnhancementType.Lucky);
        // EnhanceIfFound(gear["HealerHelm"], EnhancementType.Healer);
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
}