/*
name: Ice Rise Story
description: This script completes the IceRise quests.
tags: saga, story, quest, seasonal, frostval,frostvale,frost,icerise
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
using Skua.Core.Interfaces;

public class IceRise
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreFrostvale Frost
{
    get => _Frost ??= new CoreFrostvale();
    set => _Frost = value;
}
private CoreFrostvale _Frost;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Frost.IceRise();
        Core.SetOptions(false);
    }
}

