/*
name: Holiday Hotel Story
description: This script completes the HolidayHotel quests.
tags: saga, story, quest, seasonal, frostval,frostvale,frost,holidayhotel
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
using Skua.Core.Interfaces;

public class HolidayHotel
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFrostvale Frost = new();
    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Frost.HolidayHotel();
        Core.SetOptions(false);
    }
}

