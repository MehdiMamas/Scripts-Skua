/*
name: Dark Ally
description: This will finish the Dark Ally quest.
tags: story, quest, shadow-war, dark-ally
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
using Skua.Core.Interfaces;

public class DarkAlly
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreSoW SoW { get => _SoW ??= new CoreSoW(); set => _SoW = value; }    private static CoreSoW _SoW;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        SoW.DarkAlly();

        Core.SetOptions(false);
    }
}
