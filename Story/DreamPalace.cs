/*
name: Dream Palace Story
description: This will finish the Dream Palace Story.
tags: story, quest, dream-palace
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class DreamPalace
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        StoryLine();

        Core.SetOptions(false);
    }

    public void StoryLine()
    {
        if (Core.isCompletedBefore(7874))
            return;

        Story.PreLoad(this);

        // Potent Ruby 7869
        Story.KillQuest(7869, "dreampalace", new[] { "Flaming Harpy", "Golmoth" });

        // Mystic Sapphire 7870
        Story.KillQuest(7870, "dreampalace", new[] { "Lotus Spider", "Zelkur" });

        // Living Emerald 7871
        Story.KillQuest(7871, "dreampalace", new[] { "Palace Hound", "Gazeroth" });

        // Ethereal Diamond 7872
        Story.KillQuest(7872, "dreampalace", new[] { "Ethereal Harpy", "Zal" });

        // Open the Door 7873
        Story.MapItemQuest(7873, "dreampalace", 7944);

        // Zahad 7874
        Story.KillQuest(7874, "dreampalace", new[] { "Guardian Hound", "Zahad" });
    }
}
