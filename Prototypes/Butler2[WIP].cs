/*
name: Butler
description: This will follow a player and copy their actions and do attack actions.
tags: butler, follow, player, copy, actions, attack, maidr, auto, goto
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreFarms.cs
using System.Threading.Tasks;
using Skua.Core.Interfaces;
using Skua.Core.Models.Players;
using Skua.Core.Options;

public class Butler2
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public static CoreBots Core => CoreBots.Instance;
    private static CoreArmyLite Army => new();

    public bool DontPreconfigure = true;
    public string OptionsStorage = "Butler";
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<string>("playerName", "Player Name", "Insert the name of the player to follow", ""),
        new Option<ClassType>("classType", "Class Type", "This uses the farm or solo class set in [Options] > [CoreBots]", ClassType.Farm),
        new Option<bool>("rejectDrops", "Reject Drops", "Do you wish for the Butler to reject all drops? If false, your drop screen will fill up.", true),
        new Option<string>("attackPriority", "Attack Priority", "Fill in the monsters that the bot should prioritize (in order), seperated with a , (comma).", ""),
        new Option<string>("Quests", "Quests", "This will Register the Quests to be ran asynchronously", ""),
        new Option<string>("Drops", "Drops", "Insert the name of the Drops to be picked up, seperated by a , (comma).", ""),
        new Option<bool>("lockedMaps", "Locked Zone Handling", "When the followed account goes in to a locked map, this function allows the Butler to follow that account.", true),
        new Option<string>("lockedMapsList", "Custom Locked Maps", "Fill in the Maps that the bot will check (in order), if the player is not in the current map, split with a , (comma).", ""),
        new Option<bool>("copyWalk", "Copy Walk", "Set to true if you want to move to the same position of the player you follow.", false),
        new Option<string>("roomNumber", "Room Number", "Insert the room number which will be used when looking through Locked Zones.", "999999"),
        // new Option<string>("hibernationTimer", "Hibernate Timer", "How many seconds should the bot wait before trying to /goto again?\nIf set to 0, it will not hibernate at all.", "60"),
    };


    private CancellationTokenSource? ButlerTokenSource;
    private CancellationToken _cancellationToken;


    int gotoTry = 0;
    const int maxTry = 5;
    bool LockedZone = false;
    bool needJump = false;
    string cellJump = null;
    string padJump = null;
    string followedPlayerCell = null;
    string playerToFollow = null;
    bool isGoto = false;
    bool initializationDone = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions(disableClassSwap: true);

        DoButler(Bot.Config!.Get<string>("playerName"));

        Core.SetOptions(false, disableClassSwap: true);
    }


    public void DoButler(string? playerName, bool log = false)
    {
        // Core.DL_Enable();
        Core.DebugLogger(this);
        // Initialize the CancellationTokenSource and get the Token
        ButlerTokenSource = new CancellationTokenSource();
        _cancellationToken = ButlerTokenSource.Token;

        #region Setup area
        Core.OneTimeMessage("Butler2 [WIP]", "this butler is more stable, but atm only has the follow and attack feature", forcedMessageBox: true);
        if (string.IsNullOrEmpty(playerName))
        {
            Bot.Log("You need to set a player name.");
            return;
        }

        if (!int.TryParse(Bot.Config!.Get<string>("roomNumber"), out int roomNr) && Bot.Config!.Get<bool>("lockedMaps"))
        {
            Core.Logger("Please provide a room number for the bot to use whilst searching locked zones", messageBox: true);
            Bot.Config.Configure();
            Bot.Stop(false);
        }

        if (Bot.Config!.Get<bool>("rejectDrops"))
        {
            Bot.Options.RejectAllDrops = true;
        }

        // Load Config Data
        string drops = Bot.Config!.Get<string>("Drops") ?? "";
        string attackPriority = Bot.Config!.Get<string>("attackPriority") ?? "";
        string quests = Bot.Config!.Get<string>("Quests") ?? "";
        string lockedMapsList = Bot.Config!.Get<string>("lockedMapsList") ?? "";

        // Process Config Data
        Core.AddDrop(drops.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray());

        // Process attackPriority and add to Army._attackPriority
        if (!string.IsNullOrEmpty(attackPriority))
        {
            var attackPriorityItems = attackPriority.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Army._attackPriority.AddRange(attackPriorityItems);
        }

        // Process lockedMapsList and add to Army._LockedMapsList
        if (!string.IsNullOrEmpty(lockedMapsList))
        {
            var lockedMaps = lockedMapsList.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();  // Convert to array
            Army._LockedMapsList.AddRange(lockedMaps);
        }

        // Process quests and register them
        if (!string.IsNullOrEmpty(quests))
        {
            var questItems = quests.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToArray();
            Core.RegisterQuests(questItems);
        }

        #region Log Section
        // // LOGGING SECTION
        // if (!log)
        // {
        //     // Construct the log message with each variable on a new line
        //     string logMessage = $"Raw drops: {drops}\n" +
        //                         $"Raw attackPriority: {attackPriority}\n" +
        //                         $"Raw quests: {quests}\n" +
        //                         $"Raw lockedMapsList: {lockedMapsList}\n";

        //     // Add drops without empty values
        //     var dropsList = drops.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();
        //     if (dropsList.Length > 0) logMessage += $"drops: {string.Join(", ", dropsList)}\n";

        //     // Add attackPriority without empty values
        //     var attackPriorityItems = attackPriority.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();
        //     if (attackPriorityItems.Length > 0) logMessage += $"attackPriority: {string.Join(", ", attackPriorityItems)}\n";

        //     // Add quests without empty values
        //     var questsList = quests.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();
        //     if (questsList.Length > 0) logMessage += $"quests: {string.Join(", ", questsList)}\n";

        //     // Add lockedMapsList without empty values
        //     var lockedMaps = lockedMapsList.Split(',', StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrEmpty(s)).ToArray();
        //     if (lockedMaps.Length > 0) logMessage += $"lockedMapsList: {string.Join(", ", lockedMaps)}\n";

        //     // Log everything in one call
        //     Core.Logger(logMessage);
        // }
        #endregion Log Section


        // EQUIP CLASS & START BUTLER MODE
        Core.EquipClass(Bot.Config!.Get<ClassType>("classType"));
        Core.DebugLogger(this);
        Bot.Events.PlayerAFK += PlayerAFK;
        Core.DebugLogger(this);
        Bot.Events.ExtensionPacketReceived += MapHandler;
        Core.DebugLogger(this);
        Bot.Events.ExtensionPacketReceived += LockedZoneListener;
        // Bot.Player.Goto(playerName);


        // if (Bot.Map.PlayerExists(playerName))
        // {
        //     Core.DebugLogger(this);
        //     PlayerInfo Player = Bot.Map.TryGetPlayer(playerName, out Player) && Player != null ? Player : null;
        //     Core.DebugLogger(this);
        //     if (Player != null)
        //     {
        //         Core.DebugLogger(this);
        //         followedPlayerCell = Player.Cell;
        //         gotoTry = 0;
        //     }
        //     Core.DebugLogger(this);
        // }

        Core.DebugLogger(this);
        StartButler(playerName);
        Core.DebugLogger(this);

        Bot.Log($"Butler started for player {playerName}");
        Core.Sleep(5000);


        #endregion Setup area

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        Core.DebugLogger(this);
        while (!Bot.ShouldExit)
        {
            Core.DebugLogger(this, $"{isGoto}");
            #region ignore this
            if (Bot.ShouldExit)
            {
                Bot.Log("Bot is exiting, canceling Butler task...");
                StopButler();
                return;
            }

            if (!Bot.Player.LoggedIn)
            {
                Bot.Log("You are not logged in.");
                return;
            }
            #endregion ignore this
            Bot.Wait.ForMapLoad(Bot.Map.Name);
            if (Army.IsMonsterAlive("*") && !isGoto)
            {
                Core.DebugLogger(this);
                if (Army._attackPriority.Count > 0)
                {
                    Core.DebugLogger(this);
                    if (!Bot.Combat.StopAttacking)
                        Army.PriorityAttack();
                }
                else
                {
                    Core.DebugLogger(this);
                    if (!Bot.Combat.StopAttacking)
                    {
                        Core.DebugLogger(this);
                        Bot.Combat.Attack("*"); // Attack any monster if no priority exists
                        Core.Sleep();
                    }
                }

                // Use skills in rotation
                Bot.Skills.UseSkill(skillList[skillIndex]);
                skillIndex = (skillIndex + 1) % skillList.Length;
                Core.Sleep();

                // Handle locked zone scenario
                if (Bot.Config!.Get<bool>("lockedMaps") == true && LockedZone)
                {
                    Core.DebugLogger(this);
                    Army.LockedMaps(playerName);
                    LockedZone = false;
                    Core.Sleep();
                }
            }
            // Handle locked zone scenario outside of monsters being alive
            else if (Bot.Config!.Get<bool>("lockedMaps") == true && LockedZone)
            {
                Core.DebugLogger(this);
                Army.LockedMaps(playerName);
                LockedZone = false;
                Core.Sleep();
            }

        }
        StopButler();
    }

    public void StartButler(string? playerName = null)
    {
        // Initialize the CancellationTokenSource and get the Token
        ButlerTokenSource = new CancellationTokenSource();
        _cancellationToken = ButlerTokenSource.Token;

        Core.DebugLogger(this);
        // Start Butler task
        Task.Run(async () =>
        {
            Core.DebugLogger(this);
            while (!Bot.ShouldExit && !ButlerTokenSource.IsCancellationRequested)
            {
                Core.DebugLogger(this);
                if (playerName == null)
                {
                    Core.Logger("You need to set a player name.");
                    StopButler();
                    return;
                }

                await Task.Delay(Core.ActionDelay * 2);

                // Check if the bot should exit
                if (Bot.ShouldExit)
                {
                    Core.DebugLogger(this);
                    Bot.Log("Bot is exiting, canceling Butler task...");
                    ButlerTokenSource?.Cancel(); // Explicitly cancel
                    StopButler();
                    return;
                }

                // Check if the player is logged in
                if (!Bot.Player.LoggedIn)
                {
                    Core.DebugLogger(this);
                    Bot.Log("You are not logged in.");
                    StopButler();
                    return;
                }

                if (needJump || Bot.Map.PlayerExists(playerName))
                {
                    Core.DebugLogger(this);
                    if (!initializationDone)
                    {
                        Core.DebugLogger(this);
                        if (!Bot.Map.TryGetPlayer(playerName, out PlayerInfo? player) && player != null && player.Cell != null && player.Pad != null)
                        {
                            Core.DebugLogger(this);
                            continue;
                        }

                        if (!string.IsNullOrEmpty(player.Cell))
                            cellJump ??= player.Cell;
                        if (!string.IsNullOrEmpty(player.Pad))
                            padJump ??= player.Pad;

                        Core.DebugLogger(this, $"{player.Cell}, {player.Pad}");

                        if (cellJump != null && padJump != null)
                        {
                            Core.DebugLogger(this);
                            initializationDone = true;
                        }
                    }
                    Core.DebugLogger(this);

                    Core.Jump(cellJump, padJump);
                    Core.DebugLogger(this);
                    needJump = false;
                    if (initializationDone)
                        return;

                }


                if (!Bot.Map.PlayerExists(playerName) && !LockedZone)
                {
                    Core.DebugLogger(this);
                    isGoto = true;
                    if (followedPlayerCell == null)
                    {
                        Core.DebugLogger(this);
                        Bot.Map.Jump(Bot.Player.Cell, Bot.Player.Pad);
                    }
                    Core.DebugLogger(this);
                    await GoToPlayer(playerName, _cancellationToken);
                }

                Core.DebugLogger(this);
                isGoto = false;

                // Reset and log if successfully moved *if* goto is true
                Core.DebugLogger(this);
                if (Bot.Player.Cell == followedPlayerCell && isGoto == true)
                {
                    Core.DebugLogger(this);
                    gotoTry = 0;  // Reset the counter properly
                    Core.DebugLogger(this);
                    isGoto = false;
                    Core.DebugLogger(this);
                    Bot.Log("Successfully moved to player, resetting gotoTry.");
                }
                Core.DebugLogger(this);

                // idk when to reset gotoTry
                if (gotoTry >= maxTry || ButlerTokenSource.IsCancellationRequested)
                {
                    Bot.Log("Stopping Butler loop. Max retries reached or token cancled.");
                    StopButler();
                    return;
                }
                Core.DebugLogger(this);

                // Add a small delay to prevent fast iterations
                await Task.Delay(200);
                Core.DebugLogger(this);
            }
        }, cancellationToken: _cancellationToken);
    }

    public async Task GoToPlayer(string name, CancellationToken? cancellationToken = null)
    {
        Core.DebugLogger(this);
        if (isGoto == false)
        {
            Core.DebugLogger(this);
            return;
        }

        while (!Bot.ShouldExit && !Bot.Player.Alive && !ButlerTokenSource.IsCancellationRequested)
        {
            await Task.Delay(500);
        }

        // Stop Butler if max retries are reached
        if (gotoTry >= maxTry || ButlerTokenSource.IsCancellationRequested)
        {
            Core.DebugLogger(this);
            Bot.Log("token canceled.");
            StopButler();
            return;
        }

        if (Bot.Map.PlayerExists(name))
        {
            Core.DebugLogger(this);
            LockedZone = false;
            Army.LockedMaps(name, true);
        }

        Core.DebugLogger(this);
        Bot.Log(LockedZone ? $"{name} is in a Locked zone, will attempt to intermittently goto player incase they leave the lockedzone mid-Searching" : $"Going to player: {name}");

        Bot.Send.Packet($"%xt%zm%cmd%1%goto%{name}%");
        Core.DebugLogger(this);
        await Task.Delay(LockedZone ? 2500 : 1500);
        Core.DebugLogger(this);
    }

    public void StopButler()
    {
        // Initialize the CancellationTokenSource and get the Token
        ButlerTokenSource = new CancellationTokenSource();
        _cancellationToken = ButlerTokenSource.Token;

        // Ensure proper cancellation and cleanup
        if (ButlerTokenSource != null)
        {
            ButlerTokenSource.Cancel();  // Explicitly cancel the token
            ButlerTokenSource.Dispose(); // Clean up resources
            ButlerTokenSource = null; // Set it to null
        }
        Bot.Events.ExtensionPacketReceived -= MapHandler;
        Bot.Events.ExtensionPacketReceived -= LockedZoneListener;
        Bot.Events.PlayerAFK -= PlayerAFK;
        GC.Collect(); // Clean up to free up memory
        Bot.Log("Butler task has been canceled.");
    }

    public void MapHandler(dynamic packet)
    {
        string type = packet["params"].type;
        dynamic data = packet["params"].dataObj;

        // Handle str-type packets with data containing movement information
        if (type == "str" && data.Count >= 4)
        {
            string? playerName = Bot.Config!.Get<string>("playerName");
            if (string.IsNullOrEmpty(playerName)) return;

            // Check if the packet matches the followed player
            if (data[0]?.ToString() == "uotls" && data[2]?.ToString().ToLower() == playerName.ToLower())
            {
                string movementData = data[3]?.ToString();
                if (string.IsNullOrEmpty(movementData)) return;

                string[] movementParts = movementData.Split(',', StringSplitOptions.TrimEntries);
                string? cell = null, pad = null;
                int x = 0, y = 0, sp = 0;
                bool xSuccess = false, ySuccess = false, spSuccess = false;

                foreach (string part in movementParts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length != 2) continue;

                    string key = keyValue[0], value = keyValue[1];
                    switch (key)
                    {
                        case "strFrame":
                            cell = value;
                            break;
                        case "strPad":
                            pad = value;
                            break;
                        case "tx":
                            xSuccess = int.TryParse(value, out x);
                            break;
                        case "ty":
                            ySuccess = int.TryParse(value, out y);
                            break;
                        case "sp":
                            spSuccess = int.TryParse(value, out sp);
                            break;
                    }
                }

                // Handle Walking or Jumping Logic
                if (!movementData.Contains("mvts"))
                {
                    // Ensure valid x and y before walking
                    if (xSuccess && ySuccess)
                    {
                        Bot.Flash.Call("walkTo", x, y, sp);
                        Core.Logger($"Walking to X: {x}, Y: {y}, Speed: {sp}");
                    }
                }
                else if (!string.IsNullOrEmpty(cell) && !string.IsNullOrEmpty(pad))
                {
                    followedPlayerCell = cell;
                    needJump = true;
                    cellJump = cell;
                    padJump = pad;
                    Core.Logger($"Need to Jump to Cell: {cellJump}, Pad: {padJump}");
                }
            }
        }
        // Handle exit area scenario
        else if (data[0]?.ToString() == "exitArea" && data[3]?.ToString().ToLower() == playerToFollow.ToLower())
        {
            followedPlayerCell = null;
        }
        // Handle warning message
        else if (data[0]?.ToString() == "warning")
        {
            Core.Logger($"Warning: {data[2]?.ToString()}, we'll now search for them");
            gotoTry++;
        }

        // Handle json-type packets with moveToArea command
        else if (type == "json" && data.cmd.ToString() == "moveToArea" && data.uoBranch != null)
        {
            foreach (dynamic uoBranch in data.uoBranch)
            {
                string uoName = Convert.ToString(uoBranch.uoName);
                if (uoName?.ToLower() == playerToFollow.ToLower())
                {
                    followedPlayerCell = uoBranch.strFrame;
                    Core.Logger($"Updated followedPlayerCell: {followedPlayerCell}");
                }
            }
        }
    }

    public void LockedZoneListener(dynamic packet)
    {
        string type = packet["params"].type;
        dynamic data = packet["params"].dataObj;

        if (type is not null and "str")
        {
            string cmd = data[0];
            switch (cmd)
            {
                case "warning":
                    string LockerZonePacket = Convert.ToString(packet);
                    if (LockerZonePacket.Contains("a Locked zone.") || LockerZonePacket.Contains("is not available."))
                    {
                        Bot.Events.ExtensionPacketReceived -= MapHandler;
                        Bot.Events.ExtensionPacketReceived -= LockedZoneListener;
                        LockedZone = true;
                    }
                    break;
            }
        }
    }

    public void PlayerAFK()
    {
        Core.Logger("Anti-AFK engaged");
        Core.Sleep(1500);
        Bot.Send.Packet("%xt%zm%afk%1%false%");
    }
}
