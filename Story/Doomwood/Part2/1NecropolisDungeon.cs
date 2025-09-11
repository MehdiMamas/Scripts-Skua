/*
name: Necropolis Dungeon
description: This will complete the Necropolis Dungeon quest.
tags: story, quest, doomwood, necropolis-dungeon, part2
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class NecropolisDungeon
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDoomwood DW { get => _DW ??= new CoreDoomwood(); set => _DW = value; }
    private static CoreDoomwood _DW;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DW.NecropolisDungeon();

        Core.SetOptions(false);
    }
}
