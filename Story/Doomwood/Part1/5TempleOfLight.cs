/*
name: Temple of the Light
description: This will finish the Temple of the Light quest.
tags: story, quest, doomwood, temple-of-the-light, part1
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class TempleOfTheLight
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

        DW.TempleOfTheLight();

        Core.SetOptions(false);
    }
}
