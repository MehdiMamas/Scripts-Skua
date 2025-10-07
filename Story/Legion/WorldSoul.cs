/*
name: World Soul
description: This will finish the World Soul quest.
tags: story, quest, legion, world-soul
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class WorldSoul
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }
    private static CoreStory _Story;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        WorldSoulQuests();

        Core.SetOptions(false);
    }

    public void WorldSoulQuests()
    {
        if (Core.isCompletedBefore(6245))
            return;

        Story.PreLoad(this);

        if (!Core.isCompletedBefore(6245))
        {
            Core.EnsureAccept(6238);
            Core.HuntMonster("worldsoul", "Dwakel Infiltrator", "Void Cortex");
            Core.HuntMonster("worldsoul", "Dwakel Infiltrator", "Paradox Processor");
            Core.HuntMonster("worldsoul", "Dwakel Infiltrator", "Thermal Vent");
            Core.HuntMonster("worldsoul", "Dwakel Infiltrator", "Dwakel Defeated", 6);
            Core.EnsureComplete(6238);
        }
        Story.KillQuest(6239, "worldsoul", "Divine Water Elemental");

        Story.KillQuest(6240, "worldsoul", "Divine Fire Elemental");

        Story.MapItemQuest(6241, "worldsoul", 5681, 3);
        Story.KillQuest(6241, "worldsoul", "Skeletal Squatter");

        Story.KillQuest(6242, "worldsoul", "Radioactive Hydra");

        Story.MapItemQuest(6243, "worldsoul", 5680);
        Story.KillQuest(6243, "worldsoul", "Legion Dreadmarch");

        Story.MapItemQuest(6244, "worldsoul", 5682);
        Story.KillQuest(6244, "worldsoul", "Legion Dreadmarch");

        Story.KillQuest(6245, "worldsoul", "Core Guardian");
    }
}
