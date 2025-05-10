/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class CoreLynaria
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.RunCore();
    }

    public void DoAll()
    {
        BocklinGrove();
    }

    public void BocklinGrove()
    {
        if (Core.isCompletedBefore(10239))
            return;

        Story.PreLoad(this);

        #region Useable Monsters
        string[] UseableMonsters = new[]
        {
    "Wolf", // UseableMonsters[0],
	"Spider", // UseableMonsters[1],
	"Sp-Eye", // UseableMonsters[2],
	"Garde Grif", // UseableMonsters[3],
	"Undead Garde", // UseableMonsters[4],
	"Garde Wraith", // UseableMonsters[5],
	"Forsaken Necromancer", // UseableMonsters[6],
	"Elder Necromancer", // UseableMonsters[7]
};
        #endregion Useable Monsters

        // 10230 | Sleeping Diana
        Story.KillQuest(10230, "bocklingrove", UseableMonsters[0]);
        Story.MapItemQuest(10230, "bocklingrove", 14429);


        // 10231 | At the Edge of the Forest
        if (!Story.QuestProgression(10231))
        {
            Core.HuntMonsterQuest(10231,
                ("bocklingrove", UseableMonsters[1], ClassType.Farm));
        }


        // 10232 | Freedom Helvetia
        if (!Story.QuestProgression(10232))
        {
            Core.HuntMonsterQuest(10232,
                ("bocklingrove", UseableMonsters[2], ClassType.Farm));
        }


        // 10233 | Sacred Grove
        Story.MapItemQuest(10233, "bocklingrove", new[] { 14430, 14431 });


        // 10234 | Chained Prometheus
        if (!Story.QuestProgression(10234))
        {
            Core.HuntMonsterQuest(10234,
                ("bocklingrove", UseableMonsters[3], ClassType.Farm));
        }


        // 10235 | Ride of Death
        if (!Story.QuestProgression(10235))
        {
            Core.HuntMonsterQuest(10235,
                ("bocklingrove", UseableMonsters[4], ClassType.Farm));
        }


        // 10236 | The Fall and Death
        if (!Story.QuestProgression(10236))
        {
            Core.HuntMonsterQuest(10236,
                ("bocklingrove", UseableMonsters[5], ClassType.Farm));
        }


        // 10237 | Ruins in Moonlight
        Story.MapItemQuest(10237, new[] {
        (14432,1,"bocklingrove"), (14433,5,"bocklingrove")});


        // 10238 | Wandering Light
        if (!Story.QuestProgression(10238))
        {
            Core.HuntMonsterQuest(10238,
                ("bocklingrove", UseableMonsters[5], ClassType.Farm),
                ("bocklingrove", UseableMonsters[4], ClassType.Farm));
        }


        // 10239 | Death Plays the Fiddle
        if (!Story.QuestProgression(10239))
        {
            Core.HuntMonsterQuest(10239,
                ("bocklingrove", UseableMonsters[7], ClassType.Solo));
        }
    }

}
