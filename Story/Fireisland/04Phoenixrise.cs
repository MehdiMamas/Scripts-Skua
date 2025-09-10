/*
name: Phoenixrise
description: This will finish the Phoenixrise quest.
tags: story, quest, fire-island, phoenixrise
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs


using Skua.Core.Interfaces;

public class Phoenixrise
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

        FI.Phoenixrise();

        Core.SetOptions(false);
    }
}
