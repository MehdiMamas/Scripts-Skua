/*
name: Fireforge
description: This will finish the Fireforge quest.
tags: story, quest, fire-island, fireforge
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs

using Skua.Core.Interfaces;

public class Fireforge
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFireIsland FI
{
    get => _FI ??= new CoreFireIsland();
    set => _FI = value;
}
public CoreFireIsland _FI;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        FI.Fireforge();

        Core.SetOptions(false);
    }
}
