/*
name: Aozora Hills
description: This will finish the Aozora Hills quest.
tags: story, quest, shadow-war, aozora-hills
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
using Skua.Core.Interfaces;

public class AozoraHills
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreSoW SoW
{
    get => _SoW ??= new CoreSoW();
    set => _SoW = value;
}
public CoreSoW _SoW;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        SoW.AozoraHills();

        Core.SetOptions(false);
    }
}
