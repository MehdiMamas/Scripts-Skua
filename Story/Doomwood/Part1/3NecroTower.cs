/*
name: Necro Tower
description: This will complete the Necro Tower quest.
tags: story, quest, doomwood, necro-tower, part1
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class NecroTower
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDoomwood DW { get => _DW ??= new CoreDoomwood(); set => _DW = value; }
    private static CoreDoomwood _DW;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DW.NecroTower();

        Core.SetOptions(false);
    }
}
