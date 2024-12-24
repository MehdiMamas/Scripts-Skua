/*
name: Snowview Story
description: This script completes the Snowview quests.
tags: saga, story, quest, seasonal, frostval,frostvale,frost,snowview
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
using Skua.Core.Interfaces;

public class Snowview
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFrostvale Frost = new();
    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Frost.Snowview();
        Core.SetOptions(false);
    }
}

