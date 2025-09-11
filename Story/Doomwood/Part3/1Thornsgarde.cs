/*
name: Thorns Garde
description: This will finish the Thorns Garde quest.
tags: story, quest, doomwood, thornsgarde, part3
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class Thornsgarde
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDoomwood DW { get => _DW ??= new CoreDoomwood(); set => _DW = value; }
    private static CoreDoomwood _DW;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DW.Thornsgarde();

        Core.SetOptions(false);
    }
}
