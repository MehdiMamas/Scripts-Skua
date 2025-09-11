/*
name: Complete Doomwood Part 3
description: This will complete the Doomwood Part 3 quest.
tags: story, quest, doomwood, complete, part3
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class DoomwoodPart3
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDoomwood DW { get => _DW ??= new CoreDoomwood(); set => _DW = value; }
    private static CoreDoomwood _DW;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DW.DoomwoodPart3();

        Core.SetOptions(false);
    }
}
