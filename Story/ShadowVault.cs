/*
name: Shadow Vault Story
description: This will finish the Shadow Vault Story.
tags: story, quest, shadow-vault
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class ShadowVault
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        StoryLine();

        Core.SetOptions(false);
    }

    public void StoryLine()
    {
        if (Core.isCompletedBefore(6794))
            return;

        Story.PreLoad(this);

        //Find the Ruins 6781
        Story.MapItemQuest(6781, "ShadowVault", 6310);

        //Calm the Shadows 6782
        Story.KillQuest(6782, "ShadowVault", "Fallen Adventurer");

        //A Clue! A Clue! 6783
        Story.KillQuest(6783, "ShadowVault", new[] { "Shadowscythe Minion", "Fallen Adventurer" });

        //Un-Cloaky! 6784
        if (!Story.QuestProgression(6784))
        {
            Core.EnsureAccept(6784);
            Core.GetMapItem(6311, 1, "ShadowVault");
            Core.KillMonster("shadowvault", "cell", "r3a", "Left", "Shadowscythe Guard Slain");
            Story.KillQuest(6784, "ShadowVault", "Shadowscythe Guard");
            Core.EnsureComplete(6784);
        }

        //Bound Seams Hide a Key 6787
        Story.MapItemQuest(6787, "ShadowVault", 6312);

        //Hole in the Wall 6788
        Story.MapItemQuest(6788, "ShadowVault", 6313);
        Story.KillQuest(6788, "ShadowVault", new[] { "Spiderscythe","Shadowscythe Minion" });

        //An Actual Skeleton... key? 6789
        Story.KillQuest(6789, "ShadowVault", new[] { "Fallen Adventurer", "Spiderscythe", "Shadowscythe Minion" });

        //Open Sesame 6790
        Story.MapItemQuest(6790, "ShadowVault", 6314);
        Story.KillQuest(6790, "ShadowVault", "Shadowstryke");

        //Magic the Door Open 6791
        Story.MapItemQuest(6791, "ShadowVault", 6315, 5);
        Story.KillQuest(6791, "ShadowVault", "Darkness");

        //Un-Stucky! 6792
        Story.MapItemQuest(6792, "ShadowVault", 6316);

        //BOSS FIGHT! 6793
        Story.KillQuest(6793, "ShadowVault", "Ancient Doomknight");

        //… Did we forget some guards? 6794
        if (!Story.QuestProgression(6794))
        {
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAccept(6794);
            Core.HuntMonsterMapID("ShadowVault", 22, "Guard Slain", 100);
            Core.EnsureComplete(6794);
            Core.JumpWait();
        }

    }
}
