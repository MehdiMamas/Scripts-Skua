/*
name: Complete Sepulchure Saga Story
description: This will finish the Sepulchure Saga story.
tags: story, quest, sepulchure-saga, complete, all
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/SepulchureSaga/CoreSepulchure.cs
using Skua.Core.Interfaces;

public class CompleteSS
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreSepulchure CoreSS
{
    get => _CoreSS ??= new CoreSepulchure();
    set => _CoreSS = value;
}
public CoreSepulchure _CoreSS;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CoreSS.CompleteSS();

        Core.SetOptions(false);
    }

}
