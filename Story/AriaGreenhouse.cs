/*
name: Aria's Greenhouse Story
description: This will finish the Aria's Greenhouse quests.
tags: story, quest, aria, greenhouse, nature,water,ariagreenhouse
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class AriaGreenhouse
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        StoryLine();

        Core.SetOptions(false);
    }

    public void StoryLine()
    {
        if (Core.isCompletedBefore(10188))
            return;

        Story.PreLoad(this);

        // 10179 | Drosanthemum
        Story.MapItemQuest(10179, "faerie", new[] { 14392, 14393 });


        // 10180 | String of Turtles
        if (!Story.QuestProgression(10180))
        {
            Core.HuntMonsterQuest(10180,
                ("pines", "Red Shell Turtle", ClassType.Farm));
        }


        // 10181 | Aconite
        Core.AddDrop(Core.QuestRewards(10181));
        Story.KillQuest(10181, "cloister", "Karasu");
        Story.MapItemQuest(10181, "cloister", 14394);


        // 10182 | Blood Red Carnations
        Story.MapItemQuest(10182, "darkoviaforest", 14395);


        // 10183 | Cottongrass
        if (!Story.QuestProgression(10183))
        {
            Core.HuntMonsterQuest(10183,
                ("northlands", "Snow Golem", ClassType.Farm));
        }


        // 10184 | Hebeloma Aminophilum
        Story.MapItemQuest(10184, "deleuzetundra", new[] { 14396, 14397 });
        Story.KillQuest(10184, "deleuzetundra", "Empty Creature");


        // 10185 | Annual Mercury
        if (!Story.QuestProgression(10185))
        {
            Core.HuntMonsterQuest(10185,
                ("yokaitreasure", "Quicksilver", ClassType.Farm));
        }


        // 10186 | Gorshka Maika
        if (!Story.QuestProgression(10186))
        {
            Core.HuntMonsterQuest(10186,
                ("hakuwar", "Zakhvatchik", ClassType.Solo));
        }


        // 10187 | Alchemilla
        if (!Story.QuestProgression(10187))
        {
            Core.HuntMonsterQuest(10187,
                ("yokairealm", "Mikoto Kukol'nyy", ClassType.Solo));
        }


        // 10188 | Arianne Vivaldi
        Story.MapItemQuest(10188, "vivaldicavern", 14398);



    }
}
