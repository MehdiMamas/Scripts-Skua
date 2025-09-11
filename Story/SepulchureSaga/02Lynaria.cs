/*
name: Lynaria
description: This will finish the Lynaria quest.
tags: story, quest, sepulchure-saga, lynaria
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/SepulchureSaga/CoreSepulchure.cs
using Skua.Core.Interfaces;

public class Lynaria
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;
    private static CoreSepulchure CoreSS { get => _CoreSS ??= new CoreSepulchure(); set => _CoreSS = value; }    private static CoreSepulchure _CoreSS;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CoreSS.Lynaria();

        Core.SetOptions(false);
    }

}
