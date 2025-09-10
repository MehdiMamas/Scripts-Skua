/*
name: Dage Challenge Story
description: This will finish the Dage Challenge Story quest.
tags: story, quest, legion, dage-challenge-story
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Story/Legion/SevenCircles(War).cs
//cs_include Scripts/Legion/HeadOfTheLegionBeast.cs
using Skua.Core.Interfaces;

public class DageChallengeStory
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;

public HeadoftheLegionBeast HOTLB
{
    get => _HOTLB ??= new HeadoftheLegionBeast();
    set => _HOTLB = value;
}
public HeadoftheLegionBeast _HOTLB;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DageChallengeQuests();

        Core.SetOptions(false);
    }


    public void DageChallengeQuests()
    {
        if (Core.isCompletedBefore(8546))
            return;

        Story.PreLoad(this);

        Core.AddDrop("Underworld Medal", "Underworld Laurel", "Underworld Accolade");

        if (!Story.QuestProgression(8544))
        {
            Core.EquipClass(ClassType.Solo);
            //Training with Dage
            Core.EnsureAccept(8544);
            Core.HuntMonster("Dage", "Dage the Evil", "Dage Dueled", publicRoom: true);
            Core.EnsureComplete(8544);
            Bot.Wait.ForPickup("Underworld Laurel");
        }

        if (!Story.QuestProgression(8545))
        {
            Core.AddDrop("Underworld Medal", "Souls of Heresy", "Dage's Favor");
            Core.EquipClass(ClassType.Farm);

            //Darkness for Darkness'Sake
            Core.EnsureAccept(8545);
            if (!Core.CheckInventory("Dage's Favor", 200))
                Core.HuntMonster("underworld", "Dark Makai", "Dage's Favor", 200, isTemp: false);
            Legion.ObsidianRock(10);

            HOTLB.SoulsHeresy(30);
            Core.EnsureComplete(8545);
            Bot.Wait.ForPickup("Underworld Medal");
        }

        if (!Story.QuestProgression(8546))
        {
            //Power of the Undead Legion
            Core.EnsureAccept(8546);
            Core.HuntMonster("legionarena", "Legion Fiend Rider", "Fiend Rider's Approval");
            Core.HuntMonster("frozenlair", "Lich Lord", "Lich Lord's Approval");
            Core.HuntMonster("dagefortress", "Grrrberus", "Grrrberus's Grr Grrr");
            Core.EnsureComplete(8546);
            Bot.Wait.ForPickup("Underworld Accolade");
        }
    }
}
