/*
name: Oddities Story
description: This will finish the Oddities Storyline.
tags: oddities-story, friday-the-13th, seasonal
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/Friday13th/Story/CoreFriday13th.cs
using Skua.Core.Interfaces;

public class Oddities
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreFriday13th CoreFriday13th
{
    get => _CoreFriday13th ??= new CoreFriday13th();
    set => _CoreFriday13th = value;
}
private CoreFriday13th _CoreFriday13th;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CoreFriday13th.Oddities();

        Core.SetOptions(false);
    }
}
