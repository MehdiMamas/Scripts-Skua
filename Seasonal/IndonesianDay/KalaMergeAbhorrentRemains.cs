/*
name: Abhorrent Remains Farm
description: Farms the max Abhorrent Remains quantity.
tags: abhorrent-remains, kala, seasonal
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Seasonal/IndonesianDay/Kala.cs
//cs_include Scripts/Seasonal/IndonesianDay/Rangda.cs
using Skua.Core.Interfaces;

public class KalaMergeNonDaily
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public KalaSeasonal Kala
{
    get => _Kala ??= new KalaSeasonal();
    set => _Kala = value;
}
public KalaSeasonal _Kala;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        KalaMerge();

        Core.SetOptions(false);
    }

    public void KalaMerge(string item = "Abhorrent Remains", int Quantity = 130)
    {
        if (Core.CheckInventory(item, Quantity))
            return;

        if (!Core.isCompletedBefore(8215))
            Kala.StoryLine();

        Core.AddDrop(item);
        Core.EquipClass(ClassType.Farm);
        Core.RegisterQuests(8215);
        while (!Bot.ShouldExit && (!Core.CheckInventory(item, Quantity)))
        {
            Core.KillMonster("kala", "r4", "Left", "Cemani Dricken", "Drickens Plucked", 8);
            Core.KillMonster("kala", "r5", "Left", "Coconut Treeant", "Coconuts Collected", 8);
        }
    }
    //Didnt use Hunt because it kept getting into Kala's room and soft locking itself.
}
