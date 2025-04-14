/*
name: Grimgoal
description: Goes through teh grimgaol dungeon... Testing Phase
tags: grimgoal, dungeon, why, did, we, make, this, Testing, WIP, beta
*/

//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/DoomVault.cs
//cs_include Scripts/Story/DoomVaultB.cs
//cs_include Scripts/Other/MergeShops/InfernalArenaMerge.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/InfernalArena.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/CelestialArena.cs
//cs_include Scripts/Story/J6Saga.cs
using System.Threading.Tasks;
using Skua.Core.Interfaces;
using Skua.Core.Models.Players;
using Skua.Core.Options;
using Newtonsoft.Json.Linq;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Items;

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

    public bool DontPreconfigure = true;
    public string OptionsStorage = "Grimgaol";
    public List<IOption> Options = new()
    {
        // VHL : luck
        // VDK : luck
        // Dragon of Time : Healer
        CoreBots.Instance.SkipOptions,
        // weaponons
        new Option<string>("Valiance", "Weapon: Valiance", "insert name of your Valiance weapon", ""),
        new Option<string>("Dauntless", "Weapon: Dauntless", "insert name of your Dauntless weapon", ""),

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
        // Setoptions is disable due to how we'l be using skills, leave it alone ^_^
        // Core.SetOptions(disableClassSwap: true);
        Bot.Options.InfiniteRange = true;
        Bot.Options.SkipCutscenes = true;

        DoGrimGaol();

        // Core.SetOptions(false, disableClassSwap: true);
    }

    private void DoGrimGaol()
    {
        // Class Check
        if (!Core.CheckInventory(new[] { "Dragon of Time", "Void Highlord", "Verus DoomKnight" }))
        {
            Core.Logger("You need to have the following classes: Dragon of Time, Void Highlord, Verus DoomKnight", stopBot: true);
        }

        // Options Check
        CheckConfig();

        Prereqs();

        // Classes
        Adv.EnhanceItem("Void Highlord", EnhancementType.Lucky);
        Adv.EnhanceItem("Verus DoomKnight", EnhancementType.Lucky);
        Adv.EnhanceItem("Dragon of Time", EnhancementType.Healer);

        // Weapons
        Adv.EnhanceItem(Bot.Config.Get<string>("Valiance"), EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.None, WeaponSpecial.Valiance);
        Adv.EnhanceItem(Bot.Config.Get<string>("Dauntless"), EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.None, WeaponSpecial.Dauntless);

        // Helms
        Adv.EnhanceItem(Bot.Config.Get<string>("WizHelm"), EnhancementType.Wizard);
        Adv.EnhanceItem(Bot.Config.Get<string>("LuckHelm"), EnhancementType.Lucky);
        Adv.EnhanceItem(Bot.Config.Get<string>("AnimaHelm"), EnhancementType.Lucky, CapeSpecial.None, HelmSpecial.Anima);

        // Capes
        Adv.EnhanceItem(Bot.Config.Get<string>("Penitence"), EnhancementType.Lucky, CapeSpecial.Penitence);
        Adv.EnhanceItem(Bot.Config.Get<string>("Vainglory"), EnhancementType.Lucky, CapeSpecial.Vainglory);
        Farm.ToggleBoost(BoostType.Reputation);

        while (!Bot.ShouldExit)
        {
            if (Bot.Map.Name.ToLower() == "grimgaol")
            {
                Init();
                continue;
            }
            Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol{(Core.PrivateRoomNumber > 0 ? "-" + Core.PrivateRoomNumber : "")}%");
            Core.Sleep(4000);
            Bot.Wait.ForCellChange("Enter");
            Bot.Wait.ForCellChange("Cut1");
            Bot.Map.Jump("Enter", "Left");
            Core.Sleep(4000);
            Bot.Wait.ForCellChange("Enter");
            Core.Sleep(4000);
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

            if (Bot.Player.Cell == "Enter")
            {
                Enter();
                Core.Jump("r2", "Left");
            }
            else if (Bot.Player.Cell == "r2")
            {
                R2();
                Core.Jump("r3", "Left");
            }
            else if (Bot.Player.Cell == "r4")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r5", "Left");
            }
            else if (Bot.Player.Cell == "r5")
            {
                R5();
                Core.Jump("r6", "Left");
            }
            else if (Bot.Player.Cell == "r6")
            {
                R6();
                Core.Jump("r7", "Left");
            }
            else if (Bot.Player.Cell == "r9")
            {
                R9();
                Core.Jump("r10", "Left");
            }
            else if (Bot.Player.Cell == "r10")
            {
                R10();
                Core.Jump("r11", "Left");
            }
            else if (Bot.Player.Cell == "r3")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r4", "Left");
            }
            else if (Bot.Player.Cell == "r7")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r8", "Left");
            }
            else if (Bot.Player.Cell == "r8")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r9", "Left");
            }
            else if (Bot.Player.Cell == "r11")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r12", "Left");
            }
            else if (Bot.Player.Cell == "r12")
            {
                RVDK(Bot.Player.Cell);
                Core.Jump("r12a", "Left");
            }

            Core.Sleep(500);
        }

        Core.ChainComplete(Core.isCompletedBefore(9467) ? (Core.IsMember ? 9468 : 9467) : 9466);
        Bot.Wait.ForQuestComplete(Core.isCompletedBefore(9467) ? (Core.IsMember ? 9468 : 9467) : 9466);
        Core.Sleep(1500);
        Bot.Send.Packet($"%xt%zm%dungeonQueue%{Bot.Map.RoomID}%grimgaol{(Core.PrivateRoomNumber > 0 ? "-" + Core.PrivateRoomNumber : "")}%");
        Core.Sleep(4000);
        Bot.Wait.ForMapLoad("grimgaol");
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

        Core.Equip("Void Highlord");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("LuckHelm"));
        Core.Equip(Bot.Config.Get<string>("Vainglory"));

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
                Core.Jump("Enter", "Left");
            }

            if (Bot.Target.HasActiveAura("Talon Twisting")) continue;

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

        Core.Equip("Void Highlord");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("LuckHelm"));
        Core.Equip(Bot.Config.Get<string>("Vainglory"));

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
        Core.Equip("Legion Revenant");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("WizHelm"));
        Core.Equip(Bot.Config.Get<string>("Penitence"));

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
        Core.Equip("Dragon of Time");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("WizHelm"));
        Core.Equip(Bot.Config.Get<string>("Penitence"));

        int skillIndex = 0;
        int[] skillList = { 1, 2, 4, 2, 3, 2 };
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
            Monster target = null;

            foreach (var mon in mapMonsters)
            {
                if (mon.Cell == playerCell && mon.HP > 0 && mon.State != 0)
                {
                    if (priorityIDs.Contains(mon.MapID))
                    {
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

            if (Bot.Player.HasTarget && Bot.Skills.CanUseSkill(skillList[skillIndex]))
            {
                Bot.Skills.UseSkill(skillList[skillIndex]);
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
        Core.Equip("Void Highlord");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("LuckHelm"));
        Core.Equip(Bot.Config.Get<string>("Vainglory"));

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

            // if (!Bot.Player.HasTarget)
            // {
            //     if (monsId == "*") Bot.Combat.Attack("*");
            //     else Bot.Combat.Attack(monsIdInt);
            // }

            if (monsId == "*") doPriorityAttackId(new int[] { 10, 11, 12 });
            // else doPriorityAttack(new string[] {$"id-{monsId}"});
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
        Core.Equip("Void Highlord");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("LuckHelm"));
        Core.Equip(Bot.Config.Get<string>("Vainglory"));

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
        Core.Equip("Dragon of Time");
        Core.Equip(Bot.Config.Get<string>("Valiance"));
        Core.Equip(Bot.Config.Get<string>("WizHelm"));
        Core.Equip(Bot.Config.Get<string>("Penitence"));

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

        Core.Equip("Verus DoomKnight");
        Core.Equip(Bot.Config.Get<string>("Dauntless"));

        if (cell == "r11" || cell == "r12")
        {
            Core.Equip(Bot.Config.Get<string>("LuckHelm"));
        }
        else
        {
            Core.Equip(Bot.Config.Get<string>("AnimaHelm"));
        }

        Core.Equip(Bot.Config.Get<string>("Vainglory"));

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
            string? value = Bot.Config.Get<string>(key)?.Trim();

            // Use DisplayName as the label for the error message
            string label = opt.DisplayName ?? opt.Name; // Fall back to Name if DisplayName is null

            // If the value is null, empty, or still equal to the default (""), log an error and stop the bot
            if (string.IsNullOrEmpty(value))
            {
                Core.Logger($"[ERROR] Item with enhancement '{label}' missing or unchanged from the default. Please fill this in (if it's not enhanced, we'll do it for you).", stopBot: true);
            }
        }
    }

    private void Prereqs()
    {
        if (Core.isCompletedBefore(9465))
            return;

        Farm.Experience(80);
        DVB.StoryLine();

        if (!Core.isCompletedBefore(8740))
        {
            Core.Logger("You need to get Smite Forge Enhancement, run Unlock Forge Enhancement script first.");
            return;
        }

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
    }

}