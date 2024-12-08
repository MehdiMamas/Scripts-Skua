/*
name: Donated ACs Checker
description: This will check all of the accounts you provided that stored locally for ACs recieved from the event.
tags: donated-acs-checker, seasonal, frostvale
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Seasonal/Frostvale/ChillysParticipation.cs
using Skua.Core.Interfaces;
using Skua.Core.Models;
using Skua.Core.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;

public class CheckForDonatedACs
{
    private static IScriptInterface Bot => IScriptInterface.Instance;
    private static CoreBots Core => CoreBots.Instance;
    private readonly CoreFarms Farm = new();
    private readonly ChillysQuest CQ = new();
    private readonly CoreDailies Daily = new();
    private readonly CoreArmyLite Army = new();

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        CheckACs();

        Core.SetOptions(false);
    }

    public void CheckACs()
    {
        string logPath = Path.Combine(ClientFileSources.SkuaOptionsDIR, "FrostvaleDonationLog.txt");
        bool firstTime = !File.Exists(logPath);
        var oldACs = firstTime ? new List<string>() : File.ReadAllLines(logPath).ToList();
        var newACs = new List<string>();
        var warnings = new List<string>();

        if (firstTime) File.WriteAllText(logPath, string.Empty);

        Bot.Events.ExtensionPacketReceived += ACsListener;

        while (Army.doForAll())
        {
            if (!EnsurePlayerReady()) continue;

            Bot.Send.Packet($"%xt%zm%house%1%{Bot.Player.Username}%");
            Bot.Wait.ForMapLoad("house");

            ProcessDailyRewards();

            if (!ValidateAccountAge(out double accountAgeInDays))
            {
                AddWarning($"{Bot.Player.Username}: account too young ({accountAgeInDays:F1}/14 days)");
                continue;
            }

            if (!Bot.Flash.CallGameFunction<bool>("world.myAvatar.isEmailVerified"))
            {
                string email = Bot.Flash.GetGameObject("world.myAvatar.objData.strEmail")?[1..^1] ?? "unknown email";
                AddWarning($"{Bot.Player.Username}: email unverified ({email})");
                continue;
            }

            ProcessParticipation();
        }

        Bot.Events.ExtensionPacketReceived -= ACsListener;

        WriteResults(logPath, oldACs, newACs, warnings);

        // Local Helper Methods
        void AddWarning(string message)
        {
            warnings.Add($"- {message}");
            Core.Logger(message);
        }

        void ACsListener(dynamic packet)
        {
            if (packet["params"].type != "str") return;

            string cmd = packet["params"].dataObj[0];
            if (cmd != "server") return;

            string text = packet["params"].dataObj[2]?.ToString() ?? string.Empty;
            if (text.Contains("AdventureCoins from other players. Happy Frostval!"))
            {
                int ac = int.Parse(text.Split(' ')[2]);
                int totalACs = int.Parse((oldACs.Find(x => x.StartsWith(Bot.Player.Username)) ?? "a:0").Split(':').Last()) + ac;
                newACs.Add($"{Bot.Player.Username}:{totalACs}");
            }
        }
    }

    // Supporting Methods
    private bool EnsurePlayerReady()
    {
        Bot.Wait.ForTrue(() => Bot.Player.LoggedIn, 20);
        Core.Sleep(2000);
        Bot.Wait.ForMapLoad("battleon");
        return Bot.Wait.ForTrue(() => Bot.Player.Loaded, 20);
    }

    private void ProcessDailyRewards()
    {
        Daily.WheelofDoom();
        Daily.MonthlyTreasureChestKeys();
        Farm.Experience(30); // Ensure level requirement
    }

    private bool ValidateAccountAge(out double accountAgeInDays)
    {
        try
        {
            var creationDate = ParseCreationDate(Bot.Flash.GetGameObject("world.myAvatar.objData.dCreated")!);
            accountAgeInDays = (DateTime.Now - creationDate).TotalDays;
            return accountAgeInDays >= 14;
        }
        catch (Exception ex)
        {
            Core.Logger($"Error validating account age: {ex.Message}");
            accountAgeInDays = 0;
            return false;
        }
    }

    private DateTime ParseCreationDate(string creationData)
    {
        if (string.IsNullOrWhiteSpace(creationData))
            throw new ArgumentException("Invalid creation data provided.", nameof(creationData));

        var parts = creationData[1..^1].Split(' ');
        if (parts.Length < 6)
            throw new FormatException("Unexpected format in creation data.");

        if (!Months.TryGetValue(parts[1], out int month))
            throw new ArgumentException($"Invalid month abbreviation: {parts[1]}", nameof(creationData));

        var timeParts = parts[3].Split(':');
        if (timeParts.Length < 3)
            throw new FormatException("Unexpected time format in creation data.");

        return new DateTime(
            int.Parse(parts[5]),      // Year
            month,                    // Month
            int.Parse(parts[2]),      // Day
            int.Parse(timeParts[0]),  // Hour
            int.Parse(timeParts[1]),  // Minute
            int.Parse(timeParts[2]),  // Second
            DateTimeKind.Unspecified
        );
    }

    private static readonly Dictionary<string, int> Months = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Jan", 1 }, { "Feb", 2 }, { "Mar", 3 }, { "Apr", 4 },
        { "May", 5 }, { "Jun", 6 }, { "Jul", 7 }, { "Aug", 8 },
        { "Sep", 9 }, { "Oct", 10 }, { "Nov", 11 }, { "Dec", 12 }
    };


    private void ProcessParticipation()
    {
        if (Core.isCompletedBefore(ChillysQuest.questID)) return;
        CQ.ChillysParticipation();
        Bot.Wait.ForQuestComplete(ChillysQuest.questID);
    }

    private void WriteResults(string logPath, List<string> oldACs, List<string> newACs, List<string> warnings)
    {
        var allACs = newACs.Concat(oldACs.ExceptBy(newACs.Select(ac => ac.Split(':')[0]), ac => ac.Split(':')[0])).ToList();
        Core.WriteFile(logPath, allACs);

        string resultMessage = newACs.Count > 0
            ? $"{newACs.Count} accounts received ACs:\n\n{string.Join('\n', newACs)}"
            : $"No ACs gained.{(warnings.Count > 0 ? "\nWarnings:\n" + string.Join('\n', warnings) : "")}";
        Bot.ShowMessageBox(resultMessage, newACs.Count > 0 ? "Got ACs!" : "No ACs");
    }
}
