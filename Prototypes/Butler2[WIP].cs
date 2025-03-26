/*
name: Butler
description: This will follow a player and copy their actions and do attack actions.
tags: butler, follow, player, copy, actions, attack, maidr, auto, goto
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;
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
        new Option<string>("attackPriority", "Attack Priority", "Fill in the monsters that the bot should prioritize (in order), seperated with a , (comma)."),
        new Option<string>("Quests", "Quests", "This will Register the Quests to be ran asynchronously", ""),
        new Option<string>("Drops", "Drops", "Insert the name of the Drops to be picked up, seperated by a , (comma).", ""),

       
        // new Option<bool>("lockedMaps", "Locked Zone Handling", "When the followed account goes in to a locked map, this function allows the Butler to follow that account.", true),
        // new Option<string>("lockedMapsList", "Custom Locked Maps", "Fill in the Maps that the bot will check (in order), if the player is not in the current map, split with a , (comma)."),
        // new Option<bool>("copyWalk", "Copy Walk", "Set to true if you want to move to the same position of the player you follow.", false),
        // new Option<string>("roomNumber", "Room Number", "Insert the room number which will be used when looking through Locked Zones.", "999999"),
        // new Option<string>("hibernationTimer", "Hibernate Timer", "How many seconds should the bot wait before trying to /goto again?\nIf set to 0, it will not hibernate at all.", "60"),
    };

    private CancellationTokenSource? ButlerTokenSource = new();
    private CancellationToken _cancellationToken;
    int gotoTry = 0;
    const int maxTry = 5;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions(disableClassSwap: true);
        // Core.DL_Enable();
        // Start Butler
        DoButler(Bot.Config!.Get<string>("playerName"));

        Core.SetOptions(false, disableClassSwap: true);
    }

    public void DoButler(string? playerName, bool log = false)
    {
        Core.OneTimeMessage("Butler2 [WIP]", "this butler is more stable, but atm only has the follow and attack feature", forcedMessageBox: true);
        if (string.IsNullOrEmpty(playerName))
        {
            Bot.Log("You need to set a player name.");
            return;
        }

        if (Bot.Config!.Get<bool>("rejectDrops"))
        {
            Bot.Log($"Rejecting all set to {Bot.Config!.Get<bool>("rejectDrops")}.");
            Bot.Options.RejectAllDrops = true;
        }


        #region Log Secion
        string? drops = Bot.Config.Get<string>("Drops") ?? string.Empty;
        if (!string.IsNullOrEmpty(drops))
            Core.AddDrop(drops.Split(',', StringSplitOptions.TrimEntries)
                              .Where(s => !string.IsNullOrEmpty(s))
                              .ToArray());

        string? attackPriority = Bot.Config.Get<string>("attackPriority") ?? string.Empty;
        if (!string.IsNullOrEmpty(attackPriority))
            Army._attackPriority.AddRange(attackPriority.Split(',', StringSplitOptions.TrimEntries)
                                                        .Where(s => !string.IsNullOrEmpty(s)));

        string? quests = Bot.Config.Get<string>("Quests") ?? string.Empty;
        if (!string.IsNullOrEmpty(quests))
            Core.RegisterQuests(quests.Split(',', StringSplitOptions.TrimEntries)
                                      .Where(s => !string.IsNullOrEmpty(s))
                                      .Select(int.Parse)
                                      .ToArray());

        if (log)
        { // For Drops (as string array)
            Core.Logger("drops: " + string.Join(", ", drops.Split(',', StringSplitOptions.TrimEntries)
                                                          .Where(s => !string.IsNullOrEmpty(s))
                                                          .ToArray()));

            // For Attack Priority (as string array)
            Core.Logger("attackPriority: " + string.Join(", ", attackPriority.Split(',', StringSplitOptions.TrimEntries)
                                                                           .Where(s => !string.IsNullOrEmpty(s))));

            // For Quests (as int array)
            Core.Logger("quests: " + string.Join(", ", quests.Split(',', StringSplitOptions.TrimEntries)
                                                            .Where(s => !string.IsNullOrEmpty(s))
                                                            .Select(int.Parse)
                                                            .ToArray()));
        }
        #endregion Lgo Secion

        int[] bypasses = {
        598, 3004, 3008, 3484, 3799, 4616, 8107, 9126, 5915, 9814, 7522, 10125
    };
        Bot.Quests.Load(bypasses);
        foreach (int questId in bypasses)
            Bot.Quests.UpdateQuest(questId);
        Core.SetAchievement(18); // doomvaultb
        if (Bot.Player.Level < 100)
            Bot.Send.ClientPacket("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"0\",\"intLevel\":100}}}", type: "json"); // level bypass

        if (Bot.Config!.Get<ClassType>("classType") != ClassType.None)
            Core.EquipClass(Bot.Config!.Get<ClassType>("classType"));
        StartButler(playerName);
        Bot.Events.PlayerAFK += PlayerAFK;
        Bot.Events.ExtensionPacketReceived += MapHandler;

        int skillIndex = 0;
        int[] skillList = { 1, 2, 3, 4 };

        while (!Bot.ShouldExit)
        {
            #region ignore this
            // Make sure the cancellation token is used properly
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

            // If there's no target, attack
            if (Army._attackPriority.Count > 0)
            {
                if (!Bot.Combat.StopAttacking)
                    Army.PriorityAttack();
            }
            else
            {
                if (!Bot.Combat.StopAttacking)
                {
                    Bot.Combat.Attack("*"); // Attack any monster if no priority exists
                    Core.Sleep(); // Pause to avoid busy waiting
                }
            }

            // Use skills in order
            Bot.Skills.UseSkill(skillList[skillIndex]);
            skillIndex = (skillIndex + 1) % skillList.Length;
            Core.Sleep(Core.ActionDelay);
        }

        Bot.Events.ExtensionPacketReceived -= MapHandler;

        // Reset token when stopping
        if (ButlerTokenSource != null)
        {
            ButlerTokenSource.Cancel();
            ButlerTokenSource.Dispose();
            ButlerTokenSource = null;
        }
    }

    public void StartButler(string? playerName = null)
    {
        ButlerTokenSource = new();
        _cancellationToken = ButlerTokenSource.Token;
        // Start Butler task
        Task.Run(async () =>
        {
            while (!Bot.ShouldExit && !ButlerTokenSource.IsCancellationRequested)
            {
                try
                {
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
                        Bot.Log("Bot is exiting, canceling Butler task...");
                        ButlerTokenSource.Cancel();
                        return;
                    }

                    // Check if the player is logged in
                    if (!Bot.Player.LoggedIn)
                    {
                        Bot.Log("You are not logged in.");
                        return;
                    }

                    // Check if the player is in the map
                    if (Bot.Map.PlayerNames?.Any(p => p.Equals(playerName, StringComparison.OrdinalIgnoreCase)) != true || Bot.Player.Cell.ToLower().StartsWith("cut"))
                    {
                        if (Bot.Player.Cell != "Blank")
                        {
                            Core.JumpWait();
                            await Task.Delay(Core.ActionDelay * 2);
                        }

                        await Task.Delay(Core.ActionDelay * 2);
                        await GoToPlayer(playerName);

                        if (++gotoTry >= maxTry || ButlerTokenSource.IsCancellationRequested)
                        {
                            Bot.Log("Stopping Butler loop. Max retries reached or token cancled.");
                            StopButler();
                            return;
                        }
                    }
                    else
                    {
                        gotoTry = 0;
                    }

                    // Add a small delay to prevent fast iterations
                    await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    Bot.Log($"Error in Butler task: {ex.Message}");
                }

            }
        }, cancellationToken: _cancellationToken);
    }

    public void StopButler()
    {
        // Ensure proper cancellation and cleanup
        if (ButlerTokenSource != null)
        {
            ButlerTokenSource.Cancel();
            ButlerTokenSource.Dispose();
            ButlerTokenSource = null;
        }
        Bot.Events.ExtensionPacketReceived -= MapHandler;
        Bot.Events.PlayerAFK -= PlayerAFK;
        GC.Collect();
        Bot.Log("Butler task has been canceled.");
    }

    public async Task GoToPlayer(string name)
    {
        Bot.Log($"Going to player: {name}");

        await Task.Delay(500);  // Allow time before attempting GoToPlayer
        await Task.Run(() => Bot.Flash.CallGameFunction("world.goto", name) /*Bot.Player.Goto(name)*/);  // Teleport to the player
        await Task.Delay(1500);  // Give some time for the map transition to complete
    }



    public void MapHandler(dynamic packet)
    {
        string type = packet["params"].type;
        dynamic data = packet["params"].dataObj;

        if (type == "str")
        {
            string playerName = Bot.Config!.Get<string>("playerName")!.ToLower();
            if (data.Count >= 4 && data[0].ToString() == "uotls" && data[2].ToString().ToLower() == playerName && data[3].ToString().Contains("strFrame"))
            {
                string cellInfo = data[3].ToString();
                string cellName = cellInfo.Substring(cellInfo.IndexOf("strFrame:") + "strFrame:".Length);
                Bot.Map.Jump(cellName, "Left", false);
                Task.Delay(1500);
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
