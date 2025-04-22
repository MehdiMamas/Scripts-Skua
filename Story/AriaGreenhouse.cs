/*
name: Aria's Greenhouse Story
description: This will finish the Aria's Greenhouse quests.
tags: story, quest, aria, greenhouse, nature,water,ariagreenhouse
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class AriaGreenhouse
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new();
    private CoreFarms Farm = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoAll();

        Core.SetOptions(false);
    }

    public void DoAll()
    {
        Nature();
        Water();
    }

    public void Nature()
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
        Farm.Experience(60);
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

    public void Water()
    {
        if (Core.isCompletedBefore(10203))
            return;

        Story.PreLoad(this);

        Core.AddDrop(Core.QuestRewards(10193, 10194, 10195, 10196, 10197));

        // 10189 | People and Scarecrows
        if (!Story.QuestProgression(10189))
        {
            Core.HuntMonsterQuest(10189,
                ("farm", "Scarecrow", ClassType.Farm));
        }


        // 10190 | Dolphins and Sharks
        if (!Story.QuestProgression(10190))
        {
            Core.HuntMonsterQuest(10190,
                ("pirates", "Fishman Soldier", ClassType.Farm));
        }


        // 10191 | Dragons and Lizards
        if (!Story.QuestProgression(10191))
        {
            Core.HuntMonsterQuest(10191,
                ("natatorium", "Merdraconian", ClassType.Farm));
        }


        // 10192 | Water and Oil
        Farm.Experience(60);
        Story.KillQuest(10192, "feverfew", "Coral Creeper");
        Story.MapItemQuest(10192, "feverfew", 14399);

        // 10193 | Black Silk and White Fleece
        if (!Story.QuestProgression(10193))
        {
            Core.HuntMonsterQuest(10193,
                ("blackseakeep", "Blacksea Pirate Mage", ClassType.Farm));
        }


        // 10194 | Sunlight and Moonbeams
        if (!Story.QuestProgression(10194))
        {
            Core.HuntMonsterQuest(10194,
                ("sunlightzone", "Blighted Water", ClassType.Farm));
        }


        // 10195 | Midnight and Noon
        if (!Story.QuestProgression(10195))
        {
            Core.HuntMonsterQuest(10195,
                ("midnightzone", "Venerated Wraith", ClassType.Farm));
        }


        // 10196 | Lie and Truth
        if (!Story.QuestProgression(10196))
        {
            Core.HuntMonsterQuest(10196,
                ("abyssalzone", "Blighted Water", ClassType.Farm));
        }


        // 10197 | Odette and Odile
        if (!Story.QuestProgression(10197))
        {
            Core.Logger("Boss can't be soloed, so we skip it. Use army to kill it.");
            return;
        }


        // 10198 | Hyonix's Treasure Chest
        Story.ChainQuest(10198);

        // 10203 | Sinclair and Demien
        Story.MapItemQuest(10203, "sinclaircove", 14400);


    }
}
