/*
name: StoryARC
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
using Skua.Core.Interfaces;

public class StoryArcBadge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
private CoreStory _Story;

private CoreDoomwood DW
{
    get => _DW ??= new CoreDoomwood();
    set => _DW = value;
}
private CoreDoomwood _DW;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Badge();

        Core.SetOptions(false);
    }

    public void Badge()
    {
        if (Core.HasWebBadge(badge))
        {
            Core.Logger($"Already have the {badge} badge");
            return;
        }

        Core.Logger($"Doing Doomwood Part 1 story for {badge} badge");
        DW.DoomwoodPart1();
    }

    private string badge = "Story ARC";
}
