/*
name: Complete Doomwood Part 1
description: This will complete the Doomwood Part 1 story.
tags: story, quest, doomwood, complete, part1
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class DoomwoodPart1
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreDoomwood DW
{
    get => _DW ??= new CoreDoomwood();
    set => _DW = value;
}
private CoreDoomwood _DW;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DW.DoomwoodPart1();

        Core.SetOptions(false);
    }
}
