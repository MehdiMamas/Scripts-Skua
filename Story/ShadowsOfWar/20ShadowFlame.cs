/*
name: Shadow Flame
description: This will finish the ShadowFlame quest.
tags: story, quest, shadow-war, shadowflame
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
using Skua.Core.Interfaces;

public class ShadowFlame
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreSoW SoW
{
    get => _SoW ??= new CoreSoW();
    set => _SoW = value;
}
public CoreSoW _SoW;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        SoW.ShadowFlame();

        Core.SetOptions(false);
    }
}
