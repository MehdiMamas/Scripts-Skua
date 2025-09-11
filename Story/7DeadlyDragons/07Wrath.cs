/*
name: Wrath
description: This will finish the Wrath quest.
tags: story, quest, 7-deadly-dragons, wrath
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/7DeadlyDragons/Core7DD.cs
using Skua.Core.Interfaces;

public class Wrath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static Core7DD DD { get => _DD ??= new Core7DD(); set => _DD = value; }    private static Core7DD _DD;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DD.Wrath();

        Core.SetOptions(false);
    }
}
