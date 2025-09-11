/*
name: Pooka Story
description: This will complete the Pooka story quest.
tags: story, quest, pooka, seasonal, lucky
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class PookaStory
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        CompletePooka();

        Core.SetOptions(false);
    }

    public void CompletePooka()
    {
        if (!Core.isSeasonalMapActive("pooka"))
            return;
        if (Core.isCompletedBefore(7962))
            return;

        Story.PreLoad(this);

        Core.AddDrop("Amethyst Faerie Wings");

        //Luck Boost
        Story.KillQuest(7959, "pooka", "Sneevilchaun");

        //Safe Space
        Story.KillQuest(7960, "pooka", "Lucky Treeant");

        //Tricksy Gold
        Story.KillQuest(7961, "pooka", "Faerie");

        //You Feel Lucky?
        Story.KillQuest(7962, "pooka", "Pooka");
    }
}
