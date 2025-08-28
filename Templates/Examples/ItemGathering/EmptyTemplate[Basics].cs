/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Monsters;
using Skua.Core.Models.Quests;

public class DefaultTemplate
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;

    private CoreAdvanced Adv = new();
    private CoreFarms Farm = new();
    private CoreStory Story = new();
    private CoreDailies Daily = new();

    public void ScriptMain(IScriptInterface Bot)
    {
        // Core.BankingBlackList.AddRange(new[] { "item1", "Item2", "Etc" });
        Core.SetOptions();

        Example();

        Core.SetOptions(false);
    }

    public void Example(bool TestMode = false)
    {
        // Test Area vv

        // Test Area ^^

        // Optional Test Mode
        if (TestMode)
        {
            if (Core.CheckInventory("item", 1))
                return;

            Core.RegisterQuests(000);
            while (!Bot.ShouldExit && !Core.CheckInventory("item", 1))
            {
                Core.HuntMonster("map", "mob", "item", 1, isTemp: false, log: false);
            }
            Core.CancelRegisteredQuests();
        }
    }


}



