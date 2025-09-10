/*
name: Shadow Slayer
description: This will finish the Shadow Slayer Story.
tags: story, quest, shadow-slayer
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/7DeadlyDragons/Core7DD.cs
//cs_include Scripts/Story/GiantTaleStory.cs
//cs_include Scripts/Farm/BuyScrolls.cs
using Skua.Core.Interfaces;

public class ShadowSlayerK
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public Core7DD DD
{
    get => _DD ??= new Core7DD();
    set => _DD = value;
}
public Core7DD _DD;

public GiantTaleStory GiantTaleStory
{
    get => _GiantTaleStory ??= new GiantTaleStory();
    set => _GiantTaleStory = value;
}
public GiantTaleStory _GiantTaleStory;

public BuyScrolls Scroll
{
    get => _Scroll ??= new BuyScrolls();
    set => _Scroll = value;
}
public BuyScrolls _Scroll;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoAll();

        Core.SetOptions(false);
    }

    public void DoAll()
    {
        Storyline();
        Part2();
    }

    public void Storyline()
    {
        if (Core.isCompletedBefore(8835))
            return;

        Story.PreLoad(this);
        Core.AddDrop("Shadowslayer Apprentice Badge", "Dairy Ration", "Grain Ration", "Meat Ration", "Holy Wasabi", "Racing Trophy");

        // 8829 | Lend an Ear
        if (!Story.QuestProgression(8829))
        {
            Core.EnsureAccept(8829);
            Core.HuntMonster("arcangrove", "Gorillaphant", "Gorillaphant Ear");
            Core.HuntMonster("boxes", "Sneevil", "Sneevil Ear");
            Core.HuntMonster("terrarium", "Dustbunny of Doom", "Dustbunny of Doom Ear");
            Core.HuntMonster("uppercity", "Drow Assassin", "Drow Ear");
            Core.EnsureComplete(8829);
        }

        // 8830 | The Voice from Yesterday
        if (!Story.QuestProgression(8830))
        {
            Core.EnsureAccept(8830);
            Adv.BuyItem("Northpointe", 1085, "Dark Book");
            Core.HuntMonster("Maxius", "Ghoul Minion", "Crimson BoneLord Tome", isTemp: false);
            Bot.Quests.UpdateQuest(8060);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("backroom", "Book Wyrm", "Book of Monsters Mace", isTemp: false);
            Core.BuyItem("chronohub", 2024, "Chronomancer's Opus");
            Core.EnsureComplete(8830);
        }

        // 8831 | Shadow Slayer Slayer
        Story.KillQuest(8831, "newfinale", "Shadow Slayer");

        // 8832 | Dinner for Two
        if (!Story.QuestProgression(8832))
        {
            Core.EnsureAccept(8832);
            Core.HuntMonster("dragonchallenge", "Greenguard Dragon", "Greenguard Dragon Ribs", log: false);
            Core.HuntMonster("battlefowl", "ChickenCow", "Chickencow Wings", log: false);
            Core.HuntMonster("pirates", "Shark Bait", "Shark Bait Fillet", log: false);
            Core.KillMonster("greenguardwest", "West12", "Up", "Big Bad Boar", "Big Bad Boar Sausage", log: false);
            Core.HuntMonster("trunk", "GreenGuard Basilisk", "GreenGuard Basilisk Tail", log: false);
            Core.HuntMonster("Well", "Gell Oh No", "Gell Oh No Jello", log: false);
            Core.HuntMonster("deathgazer", "Deathgazer", "Deathgazer Takoyaki", log: false);
            Core.HuntMonster("river", "Kuro", "Kuro Geso Karaage", log: false);
            Core.EnsureComplete(8832);
        }

        // 8833 | Preparedness Awareness
        if (!Story.QuestProgression(8833))
        {
            Core.EnsureAccept(8833);
            Core.BuyItem("embersea", 1100, 1749, 25);
            Core.BuyItem("embersea", 1100, 5572, 25);
            // Core.BuyItem("arcangrove", 211, "Mana Potion", 25);
            Core.HuntMonster("cleric", "Chaos Dragon", "Medicinal Unguent");
            Core.EnsureComplete(8833);
        }

        // 8834 | Quality Tea Time
        if (!Story.QuestProgression(8834))
        {
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAccept(8834);
            if (!Core.CheckInventory("Tea Cup (Mem)"))
            {
                GiantTaleStory.DoAll();
                while (!Bot.ShouldExit && !Core.CheckInventory("Racing Trophy", 100))
                    Core.ChainComplete(746);
                Core.EnsureAccept(741);
                Core.HuntMonster("table", "Roach", "Gold Roach Leg", 10);
                Core.EnsureComplete(741, 5401);
            }
            Core.HuntMonster("sleuthhound", "Chair", "Rich Tea Leaves");
            Core.HuntMonster("guru", "Wisteria", "Fragrant Wisteria Bloom");
            Core.HuntMonster("hachiko", "Samurai Nopperabo", "Bitter Matcha");
            Story.KillQuest(8834, "elemental", "Tree of Destiny", false);
        }


        // 8835 | Shadowslayer Summoning Ritual
        if (!Story.QuestProgression(8835))
        {
            if (!Core.CheckInventory("ShadowSlayer's Apprentice"))
            {
                Core.HuntMonster("chaosbeast", "Kathool", "Chibi Eldritch Yume", isTemp: false);
                Core.EnsureAccept(8266);
                Daily.EldersBlood();
                if (!Core.CheckInventory("Holy Wasabi"))
                {
                    Core.EnsureAccept(1075);

                    Core.EquipClass(ClassType.Farm);
                    Core.HuntMonster("doomwood", "Doomwood Ectomancer", "Dried Wasabi Powder", 4);
                    Core.GetMapItem(428, 1, "lightguard");

                    Core.EnsureComplete(1075);
                    Bot.Wait.ForPickup("Holy Wasabi");
                }
                Adv.BuyItem("alchemyacademy", 2036, "Sage Tonic", 3);
                DD.HazMatSuit();
                Core.HuntMonster("sloth", "Phlegnn", "Unnatural Ooze", 8);
                Core.HuntMonster("beehive", "Killer Queen Bee", "Sleepy Honey");
                Core.EnsureComplete(8266);
                Core.BuyItem("safiria", 2044, "ShadowSlayer's Apprentice");
            }

            Core.EnsureAccept(8835);
            Scroll.BuyScroll(Scrolls.SpiritRend, 30);
            Scroll.BuyScroll(Scrolls.Eclipse, 15);
            Scroll.BuyScroll(Scrolls.BlessedShard, 30);
            if (!Core.CheckInventory("Meat Ration"))
            {
                Core.EnsureAccept(8263);
                Core.HuntMonster("cellar", "GreenRat", "Green Mystery Meat", 10, log: false);
                Core.EnsureComplete(8263);
                Bot.Wait.ForPickup("Meat Ration");
            }
            Core.RegisterQuests(8264);
            while (!Bot.ShouldExit && !Core.CheckInventory("Grain Ration", 2))
            {
                Core.KillMonster("castletunnels", "r5", "Left", "Blood Maggot", "Bundle of Rice", 3, log: false);
                Bot.Wait.ForPickup("Grain Ration");
            }
            Core.CancelRegisteredQuests();
            if (!Core.CheckInventory("Dairy Ration"))
            {
                Core.EnsureAccept(8265);
                Core.KillMonster("odokuro", "Boss", "Right", "O-dokuro", "Bone Hurt Juice", 5);
                Core.EnsureComplete(8265);
                Bot.Wait.ForPickup("Dairy Ration");
            }
            Core.EnsureComplete(8835);
        }
    }

    public void Part2()
    {

        if (Core.isCompletedBefore(9845))
            return;

        Story.PreLoad(this);


        #region Useable Monsters
        string[] UseableMonsters = new[]
        {
            "Dire Wolf", // UseableMonsters[0],
            "Ghoul", // UseableMonsters[1],
            "Hunter", // UseableMonsters[2],
            "Tindalion Hound", // UseableMonsters[3],
            "Twisted Hunter", // UseableMonsters[4]
        };
        #endregion Useable Monsters

        // 9837 | Stalking Prey
        if (!Story.QuestProgression(9837))
        {
            Core.HuntMonsterQuest(9837,
("badmoon", UseableMonsters[0], ClassType.Farm)
);
        }


        // 9838 | Super Creeps
        if (!Story.QuestProgression(9838))
        {
            Core.HuntMonsterQuest(9838,
("badmoon", UseableMonsters[1], ClassType.Solo)
);
        }


        // 9839 | Sleepless Villagers
        Story.MapItemQuest(9839, "badmoon", Core.FromTo(13445, 13447));

        // 9840 | Suspicious Minds
        if (!Story.QuestProgression(9840))
        {
            Core.HuntMonsterQuest(9840,
("badmoon", UseableMonsters[0], ClassType.Farm),
        ("badmoon", UseableMonsters[1], ClassType.Solo)
);
        }

        // 9841 | Get Out The Way
        if (!Story.QuestProgression(9841))
        {
            Core.HuntMonsterQuest(9841,
("badmoon", UseableMonsters[2], ClassType.Farm)
);
        }

        // 9842 | Door Stuck
        if (!Story.QuestProgression(9842))
        {
            Story.MapItemQuest(9842, "badmoon", 13448, 3);
            Story.KillQuest(9842, "badmoon", UseableMonsters[1]);
            Story.MapItemQuest(9842, "badmoon", 13449);
        }


        // 9843 | Nothing But A Hound Dog
        if (!Story.QuestProgression(9843))
        {
            Core.HuntMonsterQuest(9843,
("badmoon", UseableMonsters[3], ClassType.Solo)
);
        }


        // 9844 | Coldest Regards
        if (!Story.QuestProgression(9844))
        {
            Core.HuntMonsterQuest(9844,
("badmoon", UseableMonsters[2], ClassType.Solo)
);
        }


        // 9845 | No Different From Prey
        if (!Story.QuestProgression(9845))
        {
            Core.HuntMonsterQuest(9845,
("badmoon", UseableMonsters[4], ClassType.Solo)
);
        }
    }

}
