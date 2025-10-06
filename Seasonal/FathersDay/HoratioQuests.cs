/*
name: HoratioQuests.cs
description: This Script Will Finish All Quests in /nursery
tags: hotario, quests, clatter, tidy, snackies
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class HoratioQuests
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }
    private static CoreStory _Story;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Horatio();
        Core.SetOptions(false);
    }

    public void Horatio()
    {
        if (Core.isCompletedBefore(6947))
            return;

        Story.PreLoad(this);

        //Hear the Clatter (6936)
        Story.KillQuest(6936, "nursery", "Skeletal Minion");

        //Tidy Up (6937)
        Story.MapItemQuest(6937, "nursery", new[] { 6466, 6467 }, 2);
        Story.MapItemQuest(6937, "nursery", new[] { 6468, 6469 }, 4);

        //Snackies (6938)
        Story.KillQuest(6938, "nursery", "Pablum");

        //Find the Progeny (6939)
        Story.MapItemQuest(6939, "nursery", 6470);

        //Houston, We Have A Pablum (6940)
        Story.KillQuest(6940, "nursery", "Pablongous");

        //Rattle the Bones (6941)
        Story.KillQuest(6941, "nursery", "Rattlebones");

        //Boost Time (6942)
        Story.KillQuest(6942, "nursery", "Skeletal Minion");

        //Conduction Function (6943)
        Story.MapItemQuest(6943, "nursery", 6471, 6);
        Story.KillQuest(6943, "nursery", "Skeletal Minion");

        //Gross (6944)
        Story.KillQuest(6944, "nursery", "Flesh Golem");

        //Time to Clean (6945)
        Story.MapItemQuest(6945, "nursery", new[] { 6473, 6474 }, 1);
        Story.KillQuest(6945, "nursery", "Spilled Ink");

        //Find the Progeny (Again) (6946)
        Story.MapItemQuest(6946, "nursery", 6472);

        //Gleeble the Garble! (6947)
        Story.KillQuest(6947, "nursery", "GleebleGlarble");
    }
}
