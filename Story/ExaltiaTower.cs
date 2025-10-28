/*
name: Exaltia Tower Story
description: This will finish the Exaltia Tower story.
tags: story, quest, exaltia, exaltia tower, timeinn, dot
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class ExaltiaTower
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }
    private static CoreStory _Story;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        StoryLine();

        Core.SetOptions(false);
    }

    public void StoryLine()
    {
        if (Core.isCompletedBefore(8151))
            return;

        Story.PreLoad(this);

        Core.AddDrop("Exalted Node", "Exalted Forgemetal", "Exalted Relic Piece", "Exalted Artillery Shard");

        //Unlocking the Antechamber 8146
        Story.KillQuest(8146, "timeinn", new[] { "Ice Elemental", "Fire Elemental" });

        //Ezrajal 8147
        Story.KillQuest(8147, "timeinn", "Ezrajal");

        //Unlocking the Reliquary 8148
        Story.KillQuest(8148, "timeinn", new[] { "Nature Elemental", "Wind Elemental" });

        //The Warden 8149
        Story.KillQuest(8149, "timeinn", "The Warden");

        //Unlocking the Apex 8150
        Story.KillQuest(8150, "timeinn", new[] { "Energy Elemental", "Water Elemental" });

        //The Engineer 8151
        Story.KillQuest(8151, "timeinn", "The Engineer");

    }
}
