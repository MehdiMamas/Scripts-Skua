/*
name: Frostvale All Stories
description: This will finish the entire frostvale storylines.
tags: frostvale-story, seasonal, frostvale
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
using Skua.Core.Interfaces;

public class CoreFrostvale
{
    public CoreBots Core => CoreBots.Instance;
    public IScriptInterface Bot => IScriptInterface.Instance;
    private static CoreStory Story { get => _Story ??= new CoreStory(); set => _Story = value; }    private static CoreStory _Story;
    private static GlaceraStory GlaceraStory { get => _GlaceraStory ??= new GlaceraStory(); set => _GlaceraStory = value; }    private static GlaceraStory _GlaceraStory;
    public void ScriptMain(IScriptInterface Bot)
    {
        Core.RunCore();
    }

    public void DoAll(bool SwordofHope = false, bool IcyHolly = false)
    {
        if (!Core.isSeasonalMapActive("frostvale"))
        {
            Core.Logger($"it is Currently {DateTime.Now:MMMM}, The Maps Will Be out In December, as per the Design Notes.");
            return;
        }

        IceCave();
        SnowGlobe();
        Alpine();
        SnowyVale();
        IceRise();
        ColdWindValley();
        Battlefield();
        //Frsotval Barb ends here
        Darkwinter();
        Frozensoul();
        Howardshill();
        Icerisepast();
        Winterhorror();
        //Gifthulu();
        Cryostorm();
        Icewindpass();
        Icepike();
        FrostvalPastPresentandFuture();
        Snowview();
        SnowviewRace();
        DeerHunt();
        BowJangles();
        GlaceTomb();
        Fimbultomb();
        MountOtzi();
        Otziwar();
        HolidayHotel();
        HolidayHorror();
    }

    public void IceCave()
    {
        if (Core.isCompletedBefore(906) || !Core.isSeasonalMapActive("icecave"))
            return;

        Story.PreLoad(this);

        // Rescue Blizzy
        Story.KillQuest(155, "icecave", "Frosty");

        // Scary Snow Men
        Story.KillQuest(156, "icecave", "Snow Golem");

        // Moglin Popsicles
        Story.KillQuest(157, "icecave", "Frozen Moglin");

        // Crystal Spider
        Story.KillQuest(158, "icecave", "Ice Spider");

        // Fluffy Bears
        Story.KillQuest(159, "icecave", "Polar Bear");

        // Blue Eyed Beast
        Story.KillQuest(160, "icecave", "Frost Dragon");

        // Trouble Makers
        Story.KillQuest(161, "factory", "Sneevil Toy Maker");

        // Bad Ice Cream
        Story.KillQuest(162, "factory", "Snow Golem");

        // Greedy Sneevil
        Story.KillQuest(163, "factory", "Ebilsneezer");

        // Shadow Figure
        Story.KillQuest(164, "frost", "FrostScythe");

        // 'Twas the night before Frostval
        Story.KillQuest(456, "icecave", "Frosty");

        // Find Page 2
        Story.KillQuest(457, "icecave", "Frozen Moglin");
        Story.MapItemQuest(457, "yulgar", 85);

        // Find Page 3
        Story.KillQuest(458, "icecave", "Frozen Moglin");
        Story.MapItemQuest(458, "battleontown", 86);

        // Find Page 4
        Story.KillQuest(459, "factory", "Sneevil Toy Maker");

        // Find Page 5
        Story.KillQuest(460, "northlandlight", "Santy Claws");

        // Find Page 6
        Story.MapItemQuest(461, "battleontown", 87);
        Story.KillQuest(461, "icecave", "Frozen Moglin");

        // Spirit Abducted 
        Story.ChainQuest(905);
    }

    public void SnowGlobe()
    {
        if (Core.isCompletedBefore(1508) || !Core.isSeasonalMapActive("snowglobe"))
            return;
        if (!Core.isCompletedBefore(905))
            IceCave();

        Story.PreLoad(this);

        // Shaking the Globes
        Story.MapItemQuest(906, "snowglobe", 243, 10);
        Story.KillQuest(906, "snowglobe", "Snow Golem");

        //A Demonstration
        Story.KillQuest(907, "snowglobe", "Snow Golem");

        // Hearts of Ice
        Story.KillQuest(908, "snowglobe", "snowman Soldier");

        // Defeat Garaja
        Story.KillQuest(909, "snowglobe", "Garaja");

        // Springing Traps
        Story.KillQuest(910, "goldenruins", "Golden Warrior");
        Story.MapItemQuest(910, "goldenruins", 244, 10);

        // Frost Lions
        Story.KillQuest(911, "goldenruins", "Frost Lion");

        // Onslaught Keyrings
        Story.KillQuest(912, "goldenruins", "Golden Warrior");

        // Defeat Lionfang
        Story.KillQuest(913, "goldenruins", "Maximillian Lionfang");
    }

    public void Alpine()
    {
        if (Core.isCompletedBefore(1521) || !Core.isSeasonalMapActive("alpine"))
            return;

        if (!Core.isCompletedBefore(913))
            SnowGlobe();

        Story.PreLoad(this);

        // Snow Way to Know Where to Go
        Story.MapItemQuest(1508, "alpine", 758);

        // Arming the Undead Army
        Story.KillQuest(1509, "alpine", "Glacier Mole");

        // Cold As A Corpse
        Story.MapItemQuest(1510, "alpine", 759, 10);

        // Pretty Pretty Undead Princess Decor
        Story.MapItemQuest(1511, "alpine", 760, 13);

        // Deadfying Frost Lions
        Story.KillQuest(1512, "alpine", "Frost Lion");

        // Defiant Undead Deserters
        Story.KillQuest(1516, "alpine", "Frozen Deserter");

        // Forest Guadian Gauntlet
        Story.KillQuest(1513, "alpine", "Wendigo");

        // Snow Turning Back!
        Story.KillQuest(1519, "icevolcano", new[] { "Snow Golem", "Dead-ly Ice Elemental" });
        Story.MapItemQuest(1519, "icevolcano", 761, 10);

        // Venom in Your Veins
        Story.KillQuest(1520, "icevolcano", "Ice Symbiote");

        // Song of the Frozen Heart
        Story.KillQuest(1521, "icevolcano", "Dead Morice");
    }

    public void SnowyVale(bool SwordofHope = false)
    {
        if (Core.isCompletedBefore(2576) || !Core.isSeasonalMapActive("snowyvale"))
            return;
        if (!Core.isCompletedBefore(1521))
            Alpine();

        Story.PreLoad(this);

        Core.AddDrop("Ray of Hope", "Sands of Time");

        // Locate Kezeroth
        Story.MapItemQuest(2522, "snowyvale", 1584);

        // Chronoton Detection
        Story.KillQuest(2523, "snowyvale", "Polar Golem");

        // Core Knowledge
        Story.MapItemQuest(2524, "snowyvale", 1585, 6);

        // Temporal Revelation
        Story.MapItemQuest(2525, "snowyvale", 1586);

        // Before the Darkest Hour - Will continue after the QuestComplete tries end (idk how many it is but y[e])
        // if (!Story.QuestProgression(2526))
        // {
        //     Core.EnsureAccept(2526);
        //     Core.Join("frostdeep");
        //     Bot.Wait.ForMapLoad("frostdeep");
        //     Core.GetMapItem(1587, 1, "frostdeep");
        //     Core.EnsureComplete(2526);
        // }
        Story.MapItemQuest(2526, "frostdeep", 1587, AutoCompleteQuest: false);

        // Heart of Ice
        Story.KillQuest(2527, "frostdeep", new[] { "Polar Golem", "Polar Elemental" });

        // Absolute Zero Success
        Story.KillQuest(2528, "frostdeep", new[] { "Temple Prowler", "Polar Elemental", "Polar Golem" });

        // Dirty Secret
        Story.KillQuest(2529, "frostdeep", new[] { "Temple Prowler", "Polar Mole" });

        // Frozen Venom
        Story.KillQuest(2530, "frostdeep", new[] { "Polarwyrm Rider", "Polar Spider" });

        // Rune-ing His Plan
        Story.KillQuest(2531, "frostdeep", "Ancient Golem");

        // Deadly Beauty
        Story.KillQuest(2532, "frostdeep", new[] { "Polar Elemental", "Polar Golem", "Polar Golem" });

        // Cold-Hearted Trophies
        Story.KillQuest(2533, "frostdeep", new[] { "Polar Mole", "Temple Prowler", "Temple Prowler" });

        // Warmth in the Cold
        Story.KillQuest(2534, "frostdeep", new[] { "Temple Spider", "Temple Maggot" });

        // Icy Prizes
        Story.KillQuest(2535, "frostdeep", new[] { "Temple Prowler", "Temple Maggot" });

        // Fading Magic - may bug out as its 2 items from 1 mob if the delay doesnt work idfk, doesnt work as a string[] as it gets the sand drop 
        if (!Story.QuestProgression(2536))
        {
            Core.EnsureAccept(2536);
            Core.HuntMonster("frostdeep", "Ancient Golem", "Sands of Time", 6);
            Core.HuntMonster("frostdeep", "Ancient Golem", "Obsidian Key", 2);
            Core.EnsureComplete(2536);
        }

        // FrostDeep Dwellers
        Story.KillQuest(2537, "frostdeep", new[] { "Polarwyrm Rider", "Polar Mole", "Polar Mole" });

        // A Breather
        Story.KillQuest(2538, "frostdeep", new[] { "Polar Mole", "Temple Spider", "Polar Spider" });

        // Raiders From FrostDeep
        Story.KillQuest(2539, "frostdeep", new[] { "Polar Draconian", "Temple Maggot" });

        // 8 Legged Frost Freaks
        Story.KillQuest(2540, "frostdeep", new[] { "Temple Spider", "Polar Spider" });

        // Freezing the Stone
        Story.KillQuest(2541, "frostdeep", new[] { "Ancient Golem", "Ancient Golem" });

        // Can You Feel the Chill Tonight?
        Story.KillQuest(2542, "frostdeep", new[] { "Temple Prowler", "Polar Elemental", "Polar Elemental" });

        // Shrouded in Ice
        Story.KillQuest(2543, "frostdeep", new[] { "Ancient Maggot", "Ancient Maggot" });

        // Hard Fight for a Cold Truth
        Story.KillQuest(2544, "frostdeep", new[] { "Ancient Prowler", "Ancient Prowler" });

        // Sand and Shardin' Bones
        Story.KillQuest(2545, "frostdeep", new[] { "Ancient Mole", "Ancient Mole" });

        // Older and Colder
        Story.KillQuest(2546, "frostdeep", new[] { "Ancient Mole", "Ancient Prowler", "Ancient Maggot" });

        // The Sword Of Hope
        Story.KillQuest(2547, "frostdeep", new[] { "Ancient Terror", "Ancient Terror" });
    }

    public void IceRise()
    {
        if (Core.isCompletedBefore(2582) || !Core.isSeasonalMapActive("icerise"))
            return;
        if (!Core.isCompletedBefore(2547))
            SnowyVale();

        Story.PreLoad(this);

        // A Little Warmth and Light
        Story.MapItemQuest(2576, "icerise", 1592, 5);

        // Behind Locked Doors
        Story.MapItemQuest(2577, "icerise", 1593);

        // The Lost Key
        Story.KillQuest(2578, "icerise", "Polar Golem");

        // Uncovering Pages Of The Past
        Story.KillQuest(2579, "icerise", new[] { "Polar Golem", "Polar Elemental", "Arctic DireWolf" });

        // We Know Where To Look
        Story.KillQuest(2580, "icerise", new[] { "Polar Golem", "Polar Elemental", "Arctic DireWolf" });

        // A Terrible Hiding Place
        Story.KillQuest(2581, "icerise", "Arctic DireWolf");

        // Face Kezeroth!
        Story.KillQuest(2582, "icerise", "Kezeroth");
    }

    public void ColdWindValley()
    {
        if (Core.isCompletedBefore(6132) || !Core.isSeasonalMapActive("coldwindvalley"))
            return;
        if (!Core.isCompletedBefore(2582))
            IceRise();

        Story.PreLoad(this);

        // Help Blizzy
        Story.MapItemQuest(6122, "coldwindvalley", 5547);
        Story.MapItemQuest(6122, "coldwindvalley", 5548);
        Story.MapItemQuest(6122, "coldwindvalley", 5549);
        Story.MapItemQuest(6122, "coldwindvalley", 5550);

        // Gather Ammunition
        Story.KillQuest(6123, "coldwindvalley", "Hail Elemental");

        // Arm the Mob
        Story.KillQuest(6124, "farm", "Scarecrow");
        Story.MapItemQuest(6124, "coldwindvalley", 5551, 5);

        // Gather Bait
        Story.KillQuest(6125, "coldwindvalley", "Arctic Wolf");

        // Bait the Trap
        Story.KillQuest(6126, "coldwindvalley", "Ice Master Yeti");
        Story.MapItemQuest(6126, "coldwindvalley", 5552);

        // Gather Snowman Pieces
        Story.KillQuest(6127, "coldwindvalley", "Snow Golem");
        Story.MapItemQuest(6127, "coldwindvalley", 5553, 2);

        // Gather Snowman Decorations
        Story.KillQuest(6128, "coldwindvalley", "Coal Imp");
        Story.MapItemQuest(6128, "coldwindvalley", 5554);

        // Grab some Garb
        Story.KillQuest(6129, "coldwindvalley", "Frost Goblin");

        // Bait and Gifts
        Story.MapItemQuest(6130, "coldwindvalley", 5555);

        // Check out the Cave
        Story.MapItemQuest(6131, "coldwindvalley", 5556);
        Story.KillQuest(6131, "coldwindvalley", "Arctusk");

        // Holly and Ice
        Story.KillQuest(6132, "coldwindvalley", "Snow Golem");
        Story.MapItemQuest(6132, "coldwindvalley", 5557, 8);
    }

    public void Battlefield(bool ReturnEarly = false)
    {
        if (Core.isCompletedBefore(2575) || !Core.isSeasonalMapActive("battlefield"))
            return;
        if (!Core.isCompletedBefore(6132))
            ColdWindValley();

        Story.PreLoad(this);

        // Mana for the Magi 2570
        Story.KillQuest(2570, "newbie", "Slime", GetReward: false);
        if(ReturnEarly) return;

        // Gathering Spell Components 2571
        Story.KillQuest(2571, "hydra", "Fire Imp", GetReward: false);

        // Looking for Loggers 2572
        Story.KillQuest(2572, "farm", "Treeant", GetReward: false);

        // Ballista Cables 2573
        Story.KillQuest(2573, "orctown", "Horc Warrior", GetReward: false);

        // Arrowheads for Archers 2574
        Story.KillQuest(2574, "yokairiver", "Kappa Ninja", GetReward: false);

        // Fetching Fletching Feathers 2575
        Story.KillQuest(2575, "creatures", "Red Bird", GetReward: false);
    }

    public void Darkwinter()
    {
        if (Core.isCompletedBefore(3260) || !Core.isSeasonalMapActive("darkwinter"))
            return;
        if (!Core.isCompletedBefore(2575))
            Battlefield();

        //Good way | Yorumi & Einyuki Questline
        Core.ChangeAlignment(Alignment.Good);

        Story.PreLoad(this);

        // Feed the Greed 3217
        Story.KillQuest(3217, "darkwinter", new[] { "Blighted Moglin", "White Stalker", "Blighted Moglin" });
        // if (!Story.QuestProgression(3217))
        // {
        //     Core.EnsureAccept(3217);
        //     Core.HuntMonster("darkwinter", "Blighted Moglin", "Frostval Gift", 5);
        //     Core.HuntMonster("darkwinter", "White Stalker", "Frostval Decoration", 5);
        //     Core.HuntMonster("darkwinter", "Blighted Moglin", "Frostval Dessert", 5);
        //     Core.EnsureComplete(3217);
        // }

        // Sleet Samples 3218
        Story.KillQuest(3218, "darkwinter", "White Stalker");

        // Blighted Deer 3219
        Story.KillQuest(3219, "darkwinter", "Blighted Deer");

        // Frosty Hearts 3220
        Story.KillQuest(3220, "darkwinter", "Ice Golem");

        // On the Offensive 3221
        Story.KillQuest(3221, "darkwinter", "Legion Minion");

        // Inoculation 3222
        Story.MapItemQuest(3222, "darkwinter", new[] { 2280, 2281 }, 6);

        // A Different Way 3223
        Story.KillQuest(3223, "darkwinter", "Blighted Deer");

        // Breaking In 3257
        Story.MapItemQuest(3257, "darkwinter", 2315);

        // Break the Barrier 3258
        Story.KillQuest(3258, "darkwinter", "Ice Golem");

        // The Final Ward 3259
        Story.KillQuest(3259, "darkwinter", "Frost Golem");

        // Defeat Frostfang (Good) 3260 /Evil is the same
        Story.KillQuest(3260, "darkwinter", "Frost Fang");
    }

    public void Frozensoul()
    {
        if (Core.isCompletedBefore(7264) || !Core.isSeasonalMapActive("frozensoul"))
            return;
        if (!Core.isCompletedBefore(3260))
            Darkwinter();

        Story.PreLoad(this);

        // Looks like quest is not unlocked behind anything
        // Ice Cold Killer 7262
        Story.KillQuest(7262, "frozensoul", "Frozen Minion", GetReward: false);

        // Get Jacked 7263
        Story.KillQuest(7263, "frozensoul", "Jack Frost", GetReward: false);

        // Shatter the FrozenSoul Queen 7264
        Story.KillQuest(7264, "frozensoul", "FrozenSoul Queen", GetReward: false);
    }

    public void Howardshill()
    {
        if (Core.isCompletedBefore(7854) || !Core.isSeasonalMapActive("howardshill"))
            return;
        if (!Core.isCompletedBefore(7264))
            Frozensoul();

        Story.PreLoad(this);

        // Blizzy's
        // Find the Source 7843
        Story.KillQuest(7843, "howardshill", "Frozen Wisp");
        Story.MapItemQuest(7843, "howardshill", 7921);

        // Try the Door 7844
        Story.MapItemQuest(7844, "howardshill", 7922);

        // Find the Key 7845
        Story.KillQuest(7845, "howardshill", "Frozen Treeant");

        //Howard's
        // Till the Ground 7846
        Story.KillQuest(7846, "howardshill", "FrostBite");

        // Beautiful Blossoms 7847
        Story.KillQuest(7847, "howardshill", "Chillybones");

        // Moldy Trees 7848
        Story.KillQuest(7848, "howardshill", "Frozen Treeant");

        // Ichor for Elixir 7849
        Story.KillQuest(7849, "howardshill", "Chillybones");

        // Frozen Tears 7850
        Story.KillQuest(7850, "howardshill", "Chillybones");

        // Keep them Away 7851
        Story.KillQuest(7851, "howardshill", "FrostBite");

        // Light up the Darkness 7852
        Story.KillQuest(7852, "howardshill", "Frozen Wisp");

        // Return to Blizzy 7853
        Story.KillQuest(7853, "howardshill", "Chillybones");
        Story.MapItemQuest(7853, "howardshill", 7924);

        // Howard's Grief 7854
        Story.KillQuest(7854, "howardshill", "Howard's Grief");
    }

    public void Icerisepast()
    {
        if (!Core.IsMember || Core.isCompletedBefore(3904) || !Core.isSeasonalMapActive("Icerisepast"))
            return;
        if (!Core.isCompletedBefore(7854))
            Howardshill();

        Story.PreLoad(this);

        // Through the pass 3899
        Story.KillQuest(3899, "icerisepast", "Ice Wolf");

        // Higher Passes 3900
        Story.KillQuest(3900, "icerisepast", new[] { "Ice Bear", "Ice Bear", "Ice Bear" });

        // Bears? 3901
        Story.MapItemQuest(3901, "icerisepast", 2987);

        // In the Den 3902
        Story.KillQuest(3902, "icerisepast", "Guard Drumlin");

        // The Camp 3903
        if (!Story.QuestProgression(3903))
        {
            Core.EnsureAccept(3903);
            Core.KillMonster("icerisepast", "r7", "Left", "Drumlin", "Inhabitant found", 7);
            Core.EnsureComplete(3903);
        }

        // Fire from the Hole 3904
        Story.KillQuest(3904, "icerisepast", "Ice Drumlinster");
    }

    public void Winterhorror()
    {
        if (Core.isCompletedBefore(7859) || !Core.isSeasonalMapActive("winterhorror"))
            return;
        if (!Core.isCompletedBefore(3904))
            Icerisepast();

        Story.PreLoad(this);

        // Monster Gems  7856 && Mega Monster Gems 7857
        if (!Bot.Quests.IsUnlocked(7858))
        {
            Core.EnsureAcceptmultiple(new[] { 7856, 7857 });
            Core.KillMonster("winterhorror", "Enter", "Spawn", "*", "Monster Gem", 5);
            Core.EnsureComplete(7856);
            Core.KillMonster("winterhorror", "Enter", "Spawn", "*", "Mega Monster Gem", 3);
            Core.EnsureComplete(7857);
        }

        // Oh Heck! 7858
        Story.KillQuest(7858, "winterhorror", "Arthur and Elise");

        // He's Ragin' 7859
        Story.KillQuest(7859, "winterhorror", $"Howard’s Rage");
    }

    public void Gifthulu()
    {
        if (!Core.isSeasonalMapActive("gifthulu"))
            return;
        //Not avaiable
        //There is no quests over here
    }

    public void Cryostorm()
    {
        if (!Bot.Quests.IsUnlocked(4705))
        {
            Core.Logger("Quests are locked. Running Glacera Script.");
            GlaceraStory.DoAll();
        }

        if (Core.isCompletedBefore(4716) || !Core.isSeasonalMapActive("cryostorm"))
            return;

        Story.PreLoad(this);

        // Plans for Frostval
        Story.MapItemQuest(4705, "cryostorm", 4069);
        Story.MapItemQuest(4705, "cryostorm", 4070);
        Story.KillQuest(4705, "cryostorm", "Glacial Elemental");

        // Find the Missing Presents
        Story.MapItemQuest(4706, "cryostorm", 4067, 8);

        // More Gifts
        Story.KillQuest(4707, "cryostorm", new[] { "Glacial Wolf", "Cryo Mammoth", "Glacial Elemental" });

        // Warmth for the Small
        Story.KillQuest(4708, "cryostorm", "Glacial Wolf");

        // Cut Down the Tree
        Story.MapItemQuest(4709, "cryostorm", 4068);
        Story.KillQuest(4709, "cryostorm", "Glacial Wolf");

        // Decorate the Tree
        if (!Story.QuestProgression(4710))
        {
            Core.EnsureAccept(4710);
            Core.HuntMonster("cryostorm", "Cryo Mammoth", "Gilded Moglin Ornament", 2);
            Core.HuntMonster("cryostorm", "Glacial Elemental", "Frosty Wreath", 3);
            Core.HuntMonster("cryostorm", "Glacial Wolf", "Frostval Cane", 5);
            Core.HuntMonster("cryostorm", "Cryo Mammoth", "Frostval Bells", 7);
            Core.HuntMonster("cryostorm", "Glacial Elemental", "Frostval Lights", 10);
            Core.EnsureComplete(4710);
        }

        // Find the Ice StarStone
        Story.KillQuest(4711, "cryostorm", "Behemoth");

        // War Medal Quest
        if (!Core.isCompletedBefore(4716))
        {
            Core.EnsureAccept(4712);
            Core.HuntMonster("cryowar", "Frost Reaper", "Cryo War Medal", 10);
            Core.EnsureComplete(4712);
        }

        // Defeat Ultra Karok
        Story.KillQuest(4716, "cryowar", "Super-Charged Karok");
    }

    public void Icewindpass()
    {
        if (Core.isCompletedBefore(5596) || !Core.isSeasonalMapActive("icewindpass"))
            return;
        if (!Core.isCompletedBefore(4716))
            Cryostorm();

        Story.PreLoad(this);

        // Where is Karok?
        Story.MapItemQuest(5587, "icewindpass", 5074, 5);

        // Cloaking Spell
        Story.KillQuest(5588, "icewindpass", "Glacial Elemental");

        // Splattered Mana
        Story.MapItemQuest(5589, "icewindpass", 5075, 5);
        Story.KillQuest(5589, "icewindpass", "Glacial Elemental");

        // Dispell the Spell
        Story.KillQuest(5590, "icewindpass", "Living Snow");

        // Catch Up to Karok
        Story.KillQuest(5591, "icewindpass", "Frost Invader");

        // Blast the Frostspawn Symbiote
        Story.KillQuest(5592, "icewindpass", "Frostspawn Symbiote");

        // Keep Going!
        Story.KillQuest(5593, "icewindpass", "Frost Invader");

        // Take it Down!
        Story.KillQuest(5594, "icewindpass", "Frostspawn Horror");

        // Keep the Frostspawn Away!
        Story.KillQuest(5595, "icewindpass", new[] { "Frostspawn Troll", "Frost Invader" });

        // Take a Break from Fighting 
        Story.KillQuest(5596, "icewindpass", new[] { "Polar Golem", "Glacial Elemental" });
    }

    public void Icepike()
    {
        if (Core.isCompletedBefore(5617) || !Core.isSeasonalMapActive("icepike"))
            return;
        if (!Core.isCompletedBefore(5596))
            Icewindpass();

        Story.PreLoad(this);

        // Fight For Kezeroth!
        if (!Bot.Quests.IsUnlocked(5606))
        {
            Core.EnsureAccept(5597);
            Core.HuntMonster("icewindwar", "Kezeroth's Blade", "Frostspawn Medal", 10);
            Core.EnsureComplete(5597);
        }

        // WHAT is THAT?
        Story.KillQuest(5601, "icewindwar", "Soricomorpha");

        // Take a Look Around
        Story.MapItemQuest(5606, "icepike", 5085, 2);
        Story.KillQuest(5606, "icepike", "Living Ice");

        // The Stars Have Foretold
        Story.MapItemQuest(5607, "icepike", new[] { 5086, 5087 });

        // Continue this Path
        Story.MapItemQuest(5608, "icepike", 5088, 5);
        Story.KillQuest(5608, "icepike", "Ice Lord");

        // Cross the Ice Bridge
        Story.MapItemQuest(5609, "icepike", 5089);

        // Free The Moglins
        Story.KillQuest(5610, "icepike", "Frozen Moglin");

        // Get the Moglinsters
        Story.KillQuest(5612, "icepike", "Frozen Moglinster");

        // Take the Crystal
        Story.MapItemQuest(5613, "icepike", 5090);

        // You have to Fight
        Story.KillQuest(5614, "icepike", "Crystal of Glacera");

        // Fight your way Clear
        Story.MapItemQuest(5615, "icepike", 5091);

        // Take down Kezeroth!
        Story.KillQuest(5616, "icepike", "Chained Kezeroth");

        // Karok still Stands
        Story.KillQuest(5617, "icepike", "Karok The Fallen");
    }

    public void FrostvalPastPresentandFuture()
    {
        if (Core.isCompletedBefore(6651) || !Core.isSeasonalMapActive("frostvalperil"))
            return;
        if (!Core.isCompletedBefore(5617))
            Icepike();

        Story.PreLoad(this);

        // Memory #1 - Yeti or Not - 6636
        Story.KillQuest(6636, "frostvalpast", "Ice Master Yeti");

        // Activate the Spacetimebobulator - 6637   
        Story.MapItemQuest(6637, "frostvalpast", 6165);

        // Memory #2 - Who Started the Fire - 6638
        Story.KillQuest(6638, "frostvalnext", "Arcane Fire");

        // Memory #2 - Moglins on Ice - 6639
        Story.KillQuest(6639, "frostvalnext", "Frozen Moglin");

        // Memory #2 - Ice Ice Golems - 6640
        Story.KillQuest(6640, "frostvalnext", "Ice Golem");

        // Memory #2 - Xanta Claus Can't Come - 6641
        Story.KillQuest(6641, "frostvalnext", "Xanta Claus");

        // Activate the Spacetimebobulator - 6642
        Story.MapItemQuest(6642, "frostvalnext", 6165);

        // Memory #3 - Wraithing Away - 6643
        Story.KillQuest(6643, "frostvalpresent", "Time Wraith");

        // Memory #3 - Echoes - 6644
        Story.KillQuest(6644, "frostvalpresent", new[] { "Echo of Cysero", "Echo of Lim", "Echo of Sora", "Echo of Warlic" });

        // Activate the Spacetimebobulator - 6645
        Story.MapItemQuest(6645, "frostvalpresent", 6165);

        // Memory #4 - Clear the Snow - 6646
        Story.MapItemQuest(6646, "frostvalfuture", 6166);

        // Memory #4 - Fend off the Fiends - 6647
        Story.KillQuest(6647, "frostvalfuture", "Frost Fiend");

        // Memory #4 - The Frozen Warlock - 6648
        Story.KillQuest(6648, "frostvalfuture", "Wargoth the Frozen");

        // Bring the Cheer! - 6651
        Story.KillQuest(6651, "frostvalfuture", "Wargoth the Frozen");
        Story.KillQuest(6651, "frostvalpresent", "Time Wraith");
        Story.KillQuest(6651, "frostvalnext", "Xanta Claus");
        Story.KillQuest(6651, "frostvalpast", "Ice Master Yeti", GetReward: false);
    }

    public void Snowview()
    {
        if (Core.isCompletedBefore(9015) || !Core.isSeasonalMapActive("snowview"))
            return;
        if (!Core.isCompletedBefore(6651))
            FrostvalPastPresentandFuture();

        Story.PreLoad(this);

        //Glorified Pest Control (9006)
        Story.KillQuest(9006, "snowview", new[] { "Mountain Owl", "Arctic Fox" });

        //Mingling Sights (9007)
        Story.MapItemQuest(9007, "snowview", new[] { 10989, 10990 });

        //Sore Long Faces (9008)
        Story.KillQuest(9008, "snowview", "Tundra Steed");

        //Eggcellent Trade (9009)
        Story.KillQuest(9009, "snowview", "Arctic Fox");
        Story.MapItemQuest(9009, "snowview", 10991);

        //Homemade Stars (9010)
        Story.KillQuest(9010, "snowview", "Mountain Owl");
        Story.MapItemQuest(9010, "snowview", 10992, 4);

        //Rooted Remedy (9011)
        Story.MapItemQuest(9011, "snowview", 10993, 5);
        Story.MapItemQuest(9011, "snowview", 10994);

        //No Lasso Rodeo (9012)
        Story.KillQuest(9012, "snowview", "Tundra Steed");

        //A Gift of Faith (9013)
        Story.KillQuest(9013, "snowview", new[] { "Mountain Owl", "Arctic Fox" });

        //Together from Afar (9014)
        Story.KillQuest(9014, "snowview", "Tundra Steed");
        Story.MapItemQuest(9014, "snowview", 10995);

        //Intruder From the Stars (9015)
        Story.KillQuest(9015, "snowview", "Vaderix");
    }

    public void SnowviewRace()
    {
        if (Core.isCompletedBefore(9026) || !Core.isSeasonalMapActive("snowviewrace"))
            return;
        if (!Core.isCompletedBefore(9015))
            Snowview();

        Story.PreLoad(this);

        //Encroaching Frost (9017)
        Story.KillQuest(9017, "snowviewrace", "Mountain Owl");
        Story.MapItemQuest(9017, "snowviewrace", 11010);

        //Horse Vision (9018)
        Story.KillQuest(9018, "snowviewrace", "Tundra Steed");

        //Frigid Mirage (9019)
        Story.MapItemQuest(9019, "snowviewrace", new[] { 11011, 11012, 11013 });

        //Hiding Cavities (9020)
        Story.KillQuest(9020, "snowviewrace", new[] { "Mountain Owl", "Tundra Steed" });
        Story.MapItemQuest(9020, "snowviewrace", 11014);

        //Cosmic Interference (9021)
        Story.KillQuest(9021, "snowviewrace", "Juvenile Vaderix");
        Story.MapItemQuest(9021, "snowviewrace", 11015);

        //Cold Resistance (9022)
        Story.KillQuest(9022, "snowviewrace", "Juvenile Vaderix");

        //Bandits of Summer (9023)
        Story.MapItemQuest(9023, "snowviewrace", 11016);
        Story.KillQuest(9023, "snowviewrace", "Bandit");

        //Avalanche of Wings and Feelers (9024)
        Story.KillQuest(9024, "snowviewrace", new[] { "Bandit", "Juvenile Vaderix" });

        //Bargain Bin Bounty (9025)
        Story.KillQuest(9025, "snowviewrace", "Bandit Fletcher");

        //Vaderix Requiem (9026)
        Story.KillQuest(9026, "snowviewrace", "Aurora Vaderix");
    }

    public void DeerHunt()
    {
        if (Bot.Quests.IsUnlocked(8433) || !Core.isSeasonalMapActive("deerhunt"))
            return;
        if (!Core.isCompletedBefore(9026))
            SnowviewRace();

        Story.PreLoad(this);

        // 8423 Scout the Area,
        Story.KillQuest(8423, "deerhunt", "Deer?");
        Story.MapItemQuest(8423, "deerhunt", 9372);

        // 8424 Deer?
        Story.KillQuest(8424, "deerhunt", "Deer?");

        // 8425 Comparing Claws
        Story.KillQuest(8425, "deerhunt", new[] { "Scared Wolf", "Frightened Owl" });
        Story.MapItemQuest(8425, "deerhunt", 9373, 4);

        // 8426 Lair Investigated
        Story.MapItemQuest(8426, "deerhunt", new[] { 9374, 9375 });

        // 8427 Fight or Flight or Freeze
        Story.KillQuest(8427, "deerhunt", "Frightened Owl");

        // 8428 Not Deer Hunting
        Story.KillQuest(8428, "deerhunt", "Deer?");

        // 8429 Monstrous Tracks
        Story.MapItemQuest(8429, "deerhunt", 9376, 6);

        // 8430  Final Blessing
        Story.KillQuest(8430, "deerhunt", new[] { "Deer?", "Scared Wolf", "Frightened Owl" });

        // 8431 The Zweinichthirsch
        Story.KillQuest(8431, "deerhunt", "Zweinichthirsch");

        // 8432 Cries Investigated 
        Story.MapItemQuest(8432, "deerhunt", 9377);

    }

    public void BowJangles()
    {
        if (Core.isCompletedBefore(7828) || !Core.isSeasonalMapActive("frostvale"))
            return;
        if (!Core.isCompletedBefore(8432))
            DeerHunt();

        Story.PreLoad(this);
        Core.EquipClass(ClassType.Solo);

        //Beauty Comes At a Price (7819)
        Story.KillQuest(7819, "towerofmirrors", "Scarletta");

        //Bloody Skulls (7820)
        Story.KillQuest(7820, "epicvordred", "Ultra Vordred");

        //Making The World a Cleaner Place (7821)
        Story.KillQuest(7821, "palace", "Misery Eel");

        //Big and Deadly (7822)
        Bot.Quests.UpdateQuest(4361);
        Story.KillQuest(7822, "treetitanbattle", "Dakka the Dire Dragon");

        //A Hunting We Will Go (7823)
        Story.KillQuest(7823, "darkoviaforest", "Lich Of The Stone");

        //Returning to Oblivion (7824)
        if (!Story.QuestProgression(7824))
        {
            Core.EnsureAccept(7824);
            Core.HuntMonster("underworld", "Dreadfiend of Nulgath", "Dreadfiend Gone", 5);
            Core.HuntMonster("underworld", "Infernalfiend", "Infernalfiend Mauled", 5);
            Core.HuntMonster("underworld", "Bloodfiend", "Bloodfiend Destroyed", 5);
            Core.EnsureComplete(7824);
        }

        //Both Sides are Guilty (7825)
        Story.KillQuest(7825, "judgement", new[] { "Aeacus", "Minos", "Rhadamanthys" });

        //Bait and Switch (7826)
        Story.KillQuest(7826, "doomvault", "Princess Angler");

        //What Chaos Touches, We Destroy (7827)
        Story.KillQuest(7827, "orecavern", "Naga Baas");

        //A Finale to Remember (7828)
        Bot.Quests.UpdateQuest(2814);
        Story.KillQuest(7828, "stormtemple", "Chaos Lord Lionfang");
    }

    public void GlaceTomb()
    {
        if (Core.isCompletedBefore(9506) || !Core.isSeasonalMapActive("frostvale"))
            return;
        if (!Core.isCompletedBefore(7828))
            BowJangles();

        Story.PreLoad(this);
        Core.EquipClass(ClassType.Farm);

        // PTA Meeting 9497
        Story.MapItemQuest(9497, "glacetomb", new[] { 12421, 12422 });

        // Bear Essentials 9498
        Story.KillQuest(9498, "glacetomb", "Auberon");

        // Powder Sugar Faeries 9499
        Story.KillQuest(9499, "glacetomb", "Snow Fairy");

        // Water Intoxication 9500
        Story.KillQuest(9500, "glacetomb", "Auberon");

        // Wet Pages 9501
        Story.MapItemQuest(9501, "glacetomb", 12423, 7);
        Story.MapItemQuest(9501, "glacetomb", new[] { 12424, 12425 });

        // IceBox Break In 9502
        Story.MapItemQuest(9502, "glacetomb", 12426);
        Story.KillQuest(9502, "glacetomb", "Snow Fairy");

        // Necrocollege Rejects 9503
        Story.MapItemQuest(9503, "glacetomb", new[] { 12427, 12428 });
        Story.KillQuest(9503, "glacetomb", "Draugr");

        // Finger Paintings 9504
        Story.MapItemQuest(9504, "glacetomb", 12429, 5);

        // Exhibit on Ice 9505
        Story.MapItemQuest(9505, "glacetomb", 12430, 3);
        Story.KillQuest(9505, "glacetomb", "Draugr");

        Core.EquipClass(ClassType.Solo);
        // Academic Probation 9506
        Story.KillQuest(9506, "glacetomb", "Kriomein");
    }

    public void Fimbultomb()
    {
        if (Core.isCompletedBefore(9518) || !Core.isSeasonalMapActive("fimbultomb"))
            return;
        if (!Core.isCompletedBefore(9506))
            GlaceTomb();


        // Hold the Door 9509
        Story.MapItemQuest(9509, "fimbultomb", new[] { 12490, 12491 });
        Story.KillQuest(9509, "fimbultomb", "Draugr");

        // Floral Remedy 9510
        Story.MapItemQuest(9510, "fimbultomb", 12492, 7);
        Story.KillQuest(9510, "fimbultomb", "Sullied Auberon");

        // Caving Hazards 9511
        Story.KillQuest(9511, "fimbultomb", new[] { "Sullied Auberon", "Draugr" });

        // Poetic Ettin 9512
        Story.MapItemQuest(9512, "fimbultomb", 12493);
        Story.KillQuest(9512, "fimbultomb", "Ettin Golem");

        // In the Field 9513
        Story.MapItemQuest(9513, "fimbultomb", new[] { 12494, 12495, 12496 });

        // Nectar Tea 9514
        Story.MapItemQuest(9514, "fimbultomb", 12497, 7);
        Story.KillQuest(9514, "fimbultomb", "Ettin Golem");

        // Copied Homework 9515
        Story.KillQuest(9515, "fimbultomb", "Daselm");

        // Nepomancer 9516
        Story.KillQuest(9516, "fimbultomb", "Peter");

        // Invert the Cycle 9517
        Story.MapItemQuest(9517, "fimbultomb", 12498, 2);
        Story.KillQuest(9517, "fimbultomb", "Ettin Golem");

        // Death Squall 9518
        Story.KillQuest(9518, "fimbultomb", "Fimbulventr Witch");
    }

    public void MountOtzi()
    {
        if (Core.isCompletedBefore(8444) || !Core.isSeasonalMapActive("MountOtzi"))
            return;
        if (!Core.isCompletedBefore(9518))
            Fimbultomb();

        Story.PreLoad(this);

        // Light Midnight
        Story.MapItemQuest(8434, "MountOtzi", 9437, 7);

        // Actaeon Stew
        Story.KillQuest(8435, "MountOtzi", "Stitched Stag");

        // Vain Howl
        Story.KillQuest(8436, "MountOtzi", "Gauden Hound");

        // Holle's Meal
        if (!Story.QuestProgression(8437))
        {
            Story.MapItemQuest(8437, "MountOtzi", 9388);
            Story.MapItemQuest(8437, "MountOtzi", 9387, 6);
            Story.KillQuest(8437, "MountOtzi", "Stitched Stag");
        }

        // The Hidden One
        if (!Story.QuestProgression(8438))
        {
            Story.MapItemQuest(8438, "MountOtzi", 9389);
            Story.KillQuest(8438, "MountOtzi", "Gauden Hound");
        }

        //MountOtzi's Stones
        if (!Story.QuestProgression(8439))
        {
            Story.MapItemQuest(8439, "MountOtzi", 9390, 7);
            Story.KillQuest(8439, "MountOtzi", new[] { "Gauden Hound", "Mangled Stag" });
        }

        //Faceless Hunters
        if (!Story.QuestProgression(8440))
        {
            Story.KillQuest(8440, "MountOtzi", "Sluagh Warrior");
            Story.MapItemQuest(8440, "MountOtzi", 9391);
        }

        //Stitch Work
        if (!Story.QuestProgression(8441))
        {
            Story.KillQuest(8441, "MountOtzi", "Mangled Stag");
            Story.MapItemQuest(8441, "MountOtzi", 9392);
        }

        //Killer Promotion
        if (!Story.QuestProgression(8442))
        {
            Story.KillQuest(8442, "MountOtzi", "Sluagh Warrior");
            Story.MapItemQuest(8442, "MountOtzi", 9393, 7);
        }

        //Cold Pleasures
        if (!Story.QuestProgression(8443))
        {
            Story.KillQuest(8443, "MountOtzi", "Sluagh Warrior");
            Story.MapItemQuest(8443, "MountOtzi", 9394);
        }

        //Corvus Mellori
        Story.KillQuest(8444, "MountOtzi", "Sluagh Mellori", AutoCompleteQuest: false);
    }

    public void Otziwar()
    {
        if (Core.isCompletedBefore(8451))
            return;

        if (!Core.isCompletedBefore(8444))
            MountOtzi();

        Story.PreLoad(this);

        // 8446 and 8447 => Sluagh Medals && Mega Sluagh Medals
        if (!Core.isCompletedBefore(8448))
        {
            Core.EnsureAcceptmultiple(new[] { 8446, 8447 });
            Core.HuntMonster("otziwar", "Sluagh Warrior", "Sluagh Medals", 5);
            Core.EnsureComplete(8446);
            Core.HuntMonster("otziwar", "Sluagh Warrior", "Mega Sluagh Medals", 3);
            Core.EnsureComplete(8447);
        }

        // Glacial Archaeology 8448
        Story.KillQuest(8448, "otziwar", "Sluagh Warrior");

        // Calcium Dating 8449
        Story.KillQuest(8449, "otziwar", "Gauden Hound");

        // Circling Crows 8450
        Story.KillQuest(8450, "otziwar", "Sluagh Mellori");


        // Powder Snow 8451         
        Story.KillQuest(8451, "otziwar", "Huntress Valais");
    }

    public void HolidayHotel()
    {
        if (Core.isCompletedBefore(10003) || !Core.isSeasonalMapActive("holidayhotel"))
            return;
        if (!Core.isCompletedBefore(8451))
            Otziwar();

        Story.PreLoad(this);

        #region Useable Monsters
        string[] UseableMonsters = new[]
        {
    "Hydrochloric Acid", // UseableMonsters[0],
	"Lost Giftbox", // UseableMonsters[1],
	"Cold Apparition", // UseableMonsters[2],
	"Hotel Guest", // UseableMonsters[3],
	"Memory Leech", // UseableMonsters[4]
};
        #endregion Useable Monsters

        // 9993 | Mouth of a Home
        if (!Story.QuestProgression(9993))
        {
            Core.HuntMonsterQuest(9993,
                ("holidayhotel", UseableMonsters[0], ClassType.Farm));
        }


        // 9994 | Windpipe Hallway
        Story.MapItemQuest(
            9994, new[]
        {
                (13977, 5, "holidayhotel"),
                (13967, 1, "holidayhotel"),
                (13968, 1, "holidayhotel")
            }
        );

        // 9995 | Foreign Body Aspiration
        if (!Story.QuestProgression(9995))
        {
            Core.HuntMonsterQuest(9995,
                ("holidayhotel", UseableMonsters[1], ClassType.Farm));
        }


        // 9996 | Left Arm Vein
        Story.MapItemQuest(9996, "holidayhotel", new[] { 13969, 13970 });
        Story.KillQuest(9996, "holidayhotel", UseableMonsters[2]);


        // 9997 | Left Arm Artery
        Story.MapItemQuest(9997, "holidayhotel", new[] { 13971, 13972 });
        Story.KillQuest(9997, "holidayhotel", UseableMonsters[2]);


        // 9998 | Right Arm Vein
        Story.MapItemQuest(9998, "holidayhotel", new[] { 13973, 13974, 13975 });


        // 10001 | Right Arm Artery
        if (!Story.QuestProgression(10001))
        {
            Core.HuntMonsterQuest(10001,
                ("holidayhotel", UseableMonsters[3], ClassType.Farm));
        }


        // 10002 | Cryophobia
        Story.MapItemQuest(10002, "holidayhotel", 13976);



        // 10003 | Maceration
        if (!Story.QuestProgression(10003))
        {
            Core.HuntMonsterQuest(10003,
                ("holidayhotel", UseableMonsters[4], ClassType.Solo));
        }
    }

    public void HolidayHorror()
    {
        if (Core.isCompletedBefore(10014) || !Core.isSeasonalMapActive("holidayhorror"))
            return;
        if (!Core.isCompletedBefore(10003))
            HolidayHotel();

        Story.PreLoad(this);

        #region Useable Monsters
        string[] UseableMonsters = new[]
        {
    "Trey Simulacrum", // UseableMonsters[0],
	"Hydrochloric Acid", // UseableMonsters[1],
	"Alteon Simulacrum", // UseableMonsters[2],
	"Lynaria Simulacrum", // UseableMonsters[3],
	"Brittany Simulacrum", // UseableMonsters[4],
	"Brentan Simulacrum", // UseableMonsters[5],
	"La Simulacrum", // UseableMonsters[6],
	"Re Simulacrum", // UseableMonsters[7],
	"Cold Apparition", // UseableMonsters[8],
	"Hotel Guest", // UseableMonsters[9],
	"Yaga", // UseableMonsters[10],
	"Mockingbird", // UseableMonsters[11],
	"Cold Grudge", // UseableMonsters[12]
};
        #endregion Useable Monsters

        // 10005 | Chilblain
        if (!Story.QuestProgression(10005))
        {
            Core.HuntMonsterQuest(10005,
                ("holidayhorror", UseableMonsters[8], ClassType.Farm));
        }


        // 10006 | Fool's Gold
        Story.KillQuest(10006, "holidayhorror", UseableMonsters[0]);
        Story.MapItemQuest(10006, "holidayhorror", 13994);



        // 10007 | Acid Reflux
        Story.KillQuest(10007, "holidayhorror", UseableMonsters[1]);
        Story.MapItemQuest(10007, "holidayhorror", 13995, 4);


        // 10008 | Sour Notes
        if (!Story.QuestProgression(10008))
        {
            Core.HuntMonsterQuest(10008,
                ("holidayhorror", UseableMonsters[2], ClassType.Solo),
                ("holidayhorror", UseableMonsters[3], ClassType.Solo));
        }


        // 10009 | Phantom Pain
        if (!Story.QuestProgression(10009))
        {
            Core.HuntMonsterQuest(10009,
                ("holidayhorror", UseableMonsters[4], ClassType.Solo),
                ("holidayhorror", UseableMonsters[5], ClassType.Solo));
        }


        // 10010 | Kleptothermy
        if (!Story.QuestProgression(10010))
        {
            Core.EnsureAccept(10010);
            Core.KillMonster("holidayhorror", "r7", "Left", UseableMonsters[6], "La's Shard");
            Core.KillMonster("holidayhorror", "r7", "Left", UseableMonsters[7], "Re's Shard");
            Story.MapItemQuest(10010, "holidayhorror", 13996);
        }

        // 10011 | Fie Fie
        Story.MapItemQuest(10011, new[] {
            (13997, 1, "holidayhorror"),
            (13998, 5, "holidayhorror") });



        // 10012 | Here of Free Will?
        Story.MapItemQuest(10012, "holidayhorror", 14000);
        Story.KillQuest(10012, "holidayhorror", UseableMonsters[9]);


        // 10013 | Arrived by Compulsion?
        Story.KillQuest(10013, "holidayhorror", UseableMonsters[10]);
        Story.MapItemQuest(10013, "holidayhorror", 13999);


        // 10014 | Empty Nest
        if (!Story.QuestProgression(10014))
        {
            Core.CutSceneFixer("holidayhorror", "r12", "Cut3");
            Core.HuntMonsterQuest(10014,
                ("holidayhorror", UseableMonsters[11], ClassType.Solo));
        }

    }



        // if (!Core.isCompletedBefore(10003))
        //     HolidayHorror();
    // --------------------------------------------------------------------------------------------------------------------------

    // The rest of the Frostval quests are not necessary for Frostval Barbarian. Can skip and farm Frozen Orb directly using jump.

    // --------------------------------------------------------------------------------------------------------------------------
}
