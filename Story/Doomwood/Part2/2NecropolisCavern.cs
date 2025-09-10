/*
name: Necropolis Cavern
description: This will complete the Necropolis Cavern quest.
tags: story, quest, doomwood, necropolis-cavern, part2
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class NecropolisCavern
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreDoomwood DW
{
    get => _DW ??= new CoreDoomwood();
    set => _DW = value;
}
private CoreDoomwood _DW;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DW.NecropolisCavern();

        Core.SetOptions(false);
    }
}
