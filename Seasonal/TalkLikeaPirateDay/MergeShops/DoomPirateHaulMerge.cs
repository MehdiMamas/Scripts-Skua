/*
name: DoomPirate Haul Merge
description: This bot will farm the items belonging to the selected mode for the DoomPirate Haul Merge [2330] in /doompirate
tags: doompirate, haul, merge, doompirate, shadowscythe, admiral, empire, fleet, admirals, flintlock, flintlocks, doomtech, doomknight, shadowspace, crewman, crew, woman, aerated, cloak, serrated, cutlass, cutlasses, dark, crimson
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/DoomPirateStory.cs
using Newtonsoft.Json.Linq;
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Monsters;
using Skua.Core.Options;

public class DoomPirateHaulMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private static CoreAdvanced sAdv = new();
    private DoomPirate DP = new();


    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Doom Doubloon", "Gallaeon's Piece of Eight" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        DP.Storyline();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("doompirate", 2330, findIngredients, buyOnlyThis, buyMode: buyMode);

        #region Dont edit this part
        void findIngredients()
        {
            ItemBase req = Adv.externalItem;
            int quant = Adv.externalQuant;
            int currentQuant = req.Temp ? Bot.TempInv.GetQuantity(req.Name) : Bot.Inventory.GetQuantity(req.Name);
            if (req == null)
            {
                Core.Logger("req is NULL");
                return;
            }

            switch (req.Name)
            {
                default:
                    bool shouldStop = !Adv.matsOnly || !dontStopMissingIng;
                    Core.Logger($"The bot hasn't been taught how to get {req.Name}." + (shouldStop ? " Please report the issue." : " Skipping"), messageBox: shouldStop, stopBot: shouldStop);
                    break;
                #endregion

                case "Gallaeon's Piece of Eight":
                    Core.FarmingLogger(req.Name, quant);
                    Core.RegisterQuests(9355);
                    Core.EquipClass(ClassType.Solo);
                    Core.Join("doompirate", "r5", "Left");

                    bool restartKills = true;

                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                    RestartKills:
                        if (restartKills)
                        {
                            Bot.Map.Reload();
                            Bot.Wait.ForMapLoad("doompirate");
                            restartKills = false;
                        }

                        // Ensure player is in the correct cell
                        while (!Bot.ShouldExit && Bot.Player.Cell != "r5")
                        {
                            Core.Jump("r5", "Left");
                            Core.Sleep();
                        }

                        Bot.Player.SetSpawnPoint();

                        // Mob IDs in kill order
                        foreach (int mob in new[] { 5, 4, 7, 6, 9, 8, 11, 10 })
                        {
                            // Try to get the monster by MapID
                            Monster? target = Bot.Monsters.MapMonsters
                                .FirstOrDefault(x => x?.MapID! == mob);

                            // Get monster HP (safe with retries)
                            int hp = Core.InitializeWithRetries(() => GetMonsterHP(mob.ToString()));

                            // Skip if monster doesn't exist or has no HP
                            if (target == null || hp <= 0)
                            {
                                Core.Logger($"Skipping mob {mob}[{(target == null ? "" : target.MapID.ToString())}] " +
                                            $"({(target == null ? ", it's null or not available" : "it's dead")}).");
                                continue;
                            }

                            Core.Logger($"Killing: {target.Name}[{target.MapID}]");
                            while (!Bot.ShouldExit && GetMonsterHP(mob.ToString()) > 0)
                            {
                                // Handle player death
                                if (!Bot.Player.Alive)
                                {
                                    while (!Bot.ShouldExit && !Bot.Player.Alive)
                                        Bot.Sleep(100);

                                    Core.Logger("Player died, restarting room.");
                                    restartKills = true;
                                    goto RestartKills;
                                }

                                Bot.Combat.Attack(target.MapID);
                                Bot.Sleep(100);

                                // Break the loop when it dies
                                if (!(GetMonsterHP(mob.ToString()) > 0))
                                {
                                    Core.Logger($"Killed: {target.Name}[{target.MapID}]");
                                    continue;
                                }
                            }


                        }

                        // Final mob in the room
                        Bot.Kill.Monster(12);
                    }
                    break;

                case "Doom Doubloon":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Solo);
                    Core.RegisterQuests(9354);
                    Core.HuntMonsterMapID("doompirate", 3, req.Name, quant, log: false);
                    Bot.Wait.ForPickup(req.Name);
                    Core.CancelRegisteredQuests();
                    break;

            }
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


    public List<IOption> Select = new()
    {
        new Option<bool>("79592", "Shadowscythe Admiral", "Mode: [select] only\nShould the bot buy \"Shadowscythe Admiral\" ?", false),
        new Option<bool>("79593", "Empire Fleet Admiral's Hat", "Mode: [select] only\nShould the bot buy \"Empire Fleet Admiral's Hat\" ?", false),
        new Option<bool>("79594", "Empire Fleet Admiral's Locks", "Mode: [select] only\nShould the bot buy \"Empire Fleet Admiral's Locks\" ?", false),
        new Option<bool>("79595", "Empire Fleet Flintlock", "Mode: [select] only\nShould the bot buy \"Empire Fleet Flintlock\" ?", false),
        new Option<bool>("79596", "Empire Fleet Flintlocks", "Mode: [select] only\nShould the bot buy \"Empire Fleet Flintlocks\" ?", false),
        new Option<bool>("79599", "DoomTech DoomKnight", "Mode: [select] only\nShould the bot buy \"DoomTech DoomKnight\" ?", false),
        new Option<bool>("73749", "Shadowspace Crewman", "Mode: [select] only\nShould the bot buy \"Shadowspace Crewman\" ?", false),
        new Option<bool>("73750", "Shadowspace Crewman Hair", "Mode: [select] only\nShould the bot buy \"Shadowspace Crewman Hair\" ?", false),
        new Option<bool>("73751", "Shadowspace Crew Woman Locks", "Mode: [select] only\nShould the bot buy \"Shadowspace Crew Woman Locks\" ?", false),
        new Option<bool>("73752", "Aerated Cloak", "Mode: [select] only\nShould the bot buy \"Aerated Cloak\" ?", false),
        new Option<bool>("73753", "Serrated Cutlass", "Mode: [select] only\nShould the bot buy \"Serrated Cutlass\" ?", false),
        new Option<bool>("73754", "Serrated Cutlasses", "Mode: [select] only\nShould the bot buy \"Serrated Cutlasses\" ?", false),
        new Option<bool>("79600", "Shadowspace Empire Crewman", "Mode: [select] only\nShould the bot buy \"Shadowspace Empire Crewman\" ?", false),
        new Option<bool>("79601", "Dark Aerated Cloak", "Mode: [select] only\nShould the bot buy \"Dark Aerated Cloak\" ?", false),
        new Option<bool>("79602", "Serrated Crimson Cutlass", "Mode: [select] only\nShould the bot buy \"Serrated Crimson Cutlass\" ?", false),
        new Option<bool>("79603", "Serrated Crimson Cutlasses", "Mode: [select] only\nShould the bot buy \"Serrated Crimson Cutlasses\" ?", false),
    };
}
