/*
name: NecroCarnival Story
description: This will complete the NecroCarnival story quest.
tags: story, quest, mogloween, seasonal, necro, carnival
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/Mogloween/CoreMogloween.cs
using Skua.Core.Interfaces;

public class NecroCarnival
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreMogloween CoreMogloween
{
    get => _CoreMogloween ??= new CoreMogloween();
    set => _CoreMogloween = value;
}
public CoreMogloween _CoreMogloween;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CoreMogloween.NecroCarnival();

        Core.SetOptions(false);
    }

}
