/*
name: Swordhaven The New World
description: This will finish the Swordhaven The New World quest.
tags: story, quest, queen-of-monsters, swordhaven-the-new-world
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQoM.cs

using Skua.Core.Interfaces;

public class CompleteTheNewWorld
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

    public CoreQOM QOM => new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        QOM.SwordhavenTheNewWorld();

        Core.SetOptions(false);
    }
}
