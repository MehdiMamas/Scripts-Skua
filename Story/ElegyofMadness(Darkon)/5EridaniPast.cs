/*
name: Eridani Past
description: This will finish the Eridani Past quest.
tags: story, quest, elegy-of-madness, darkon, eridani-past
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs
using Skua.Core.Interfaces;

public class CompleteEridaniPast
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

    public CoreAstravia Astravia => new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Astravia.EridaniPast();

        Core.SetOptions(false);
    }
}
