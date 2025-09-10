/*
name: Complete All Seasonal Story
description: This will finish all of seasonal story on current month.
tags: seasonal, story, complete, all
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Seasonal/AprilFools/DERP!Badge.cs
//cs_include Scripts/Seasonal/AprilFools/MeateorHunt.cs
//cs_include Scripts/Seasonal/AprilFools/SuperSLAYIN'Badge(GardenQuest).cs
//cs_include Scripts/Seasonal/AprilFools/Mmmm,Meaty(or)(MeatyShard).cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
//cs_include Scripts/Seasonal/HerosHeartDay/Fezzini.cs
//cs_include Scripts/Seasonal/HerosHeartDay/LoveSpellStory.cs
//cs_include Scripts/Seasonal/HerosHeartDay/WheelOfLove.cs
//cs_include Scripts/Seasonal/LuckyDay/Pooka.cs
//cs_include Scripts/Seasonal/MayThe4th/DarkLord.cs
//cs_include Scripts/Seasonal/MayThe4th/MurderMoonStory.cs
//cs_include Scripts/Seasonal/MayThe4th/MurderMoonMerge.cs
//cs_include Scripts/Story/MemetsRealm/CoreMemet.cs
//cs_include Scripts/Seasonal/Mogloween/CoreMogloween.cs
//cs_include Scripts/Seasonal/Mogloween/VampireLord(Class).cs
//cs_include Scripts/Seasonal/StaffBirthdays/DageTheEvil/CoreDageBirthday.cs
//cs_include Scripts/Seasonal/StarFestival/StarFestival.cs
//cs_include Scripts/Seasonal/SummerBreak/BeachPartyTokenItems.cs
//cs_include Scripts/Seasonal/SummerBreak/BlazingBeach.cs
//cs_include Scripts/Seasonal/SummerBreak/BlazingBeachMerge.cs
//cs_include Scripts/Seasonal/SummerBreak/BurningBeach.cs
//cs_include Scripts/Seasonal/SummerBreak/CoralBeachMerge.cs
//cs_include Scripts/Story/Summer2015AdventureMap/CoreSummer.cs
//cs_include Scripts/Seasonal/SummerBreak/LunaCoveMerge.cs
//cs_include Scripts/Seasonal/SummerBreak/SweetSummerTreats.cs
//cs_include Scripts/Seasonal/SummerBreak/Un-LifeguardQuest.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/CelestialPirateCommander[PollyRogers].cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/KaijuWar.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/HeartOfTheSeaStory.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/CetoleonWarStory.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/DragonPirateStory.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/DragonCapitalStory.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/AluteaNursery.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/BlazeBeardStory.cs
//cs_include Scripts/Seasonal/TalkLikeaPirateDay/LowTideStory.cs
//cs_include Scripts/Story/Legion/DageRecruit.cs
using Skua.Core.Interfaces;

public class AllSeasonal
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public DERPBadge Derp
{
    get => _Derp ??= new DERPBadge();
    set => _Derp = value;
}
public DERPBadge _Derp;

public MeateorHunt MeateorHunt
{
    get => _MeateorHunt ??= new MeateorHunt();
    set => _MeateorHunt = value;
}
public MeateorHunt _MeateorHunt;

public SuperSLAYINBadge SSB
{
    get => _SSB ??= new SuperSLAYINBadge();
    set => _SSB = value;
}
public SuperSLAYINBadge _SSB;

public CoreFrostvale Frostvale
{
    get => _Frostvale ??= new CoreFrostvale();
    set => _Frostvale = value;
}
public CoreFrostvale _Frostvale;

public FezziniStory Fezzini
{
    get => _Fezzini ??= new FezziniStory();
    set => _Fezzini = value;
}
public FezziniStory _Fezzini;

public LoveSpell LoveSpell
{
    get => _LoveSpell ??= new LoveSpell();
    set => _LoveSpell = value;
}
public LoveSpell _LoveSpell;

public WheeleOfLove WheeleOfLove
{
    get => _WheeleOfLove ??= new WheeleOfLove();
    set => _WheeleOfLove = value;
}
public WheeleOfLove _WheeleOfLove;

public PookaStory Pooka
{
    get => _Pooka ??= new PookaStory();
    set => _Pooka = value;
}
public PookaStory _Pooka;

public MmmmMeatyQuest Meaty
{
    get => _Meaty ??= new MmmmMeatyQuest();
    set => _Meaty = value;
}
public MmmmMeatyQuest _Meaty;

public DarkLord DarkLord
{
    get => _DarkLord ??= new DarkLord();
    set => _DarkLord = value;
}
public DarkLord _DarkLord;

public MurderMoon MurderMoon
{
    get => _MurderMoon ??= new MurderMoon();
    set => _MurderMoon = value;
}
public MurderMoon _MurderMoon;

public CoreMogloween CoreMogloween
{
    get => _CoreMogloween ??= new CoreMogloween();
    set => _CoreMogloween = value;
}
public CoreMogloween _CoreMogloween;


public VampireLord VPL
{
    get => _VPL ??= new VampireLord();
    set => _VPL = value;
}
public VampireLord _VPL;

public DageRecruitStory DageRecruit
{
    get => _DageRecruit ??= new DageRecruitStory();
    set => _DageRecruit = value;
}
public DageRecruitStory _DageRecruit;

private CoreDageBirthday Dage
{
    get => _Dage ??= new CoreDageBirthday();
    set => _Dage = value;
}
private CoreDageBirthday _Dage;

public StarFestival StarFestival
{
    get => _StarFestival ??= new StarFestival();
    set => _StarFestival = value;
}
public StarFestival _StarFestival;

public BeachPartyTokenItems BeachPartyTokenItems
{
    get => _BeachPartyTokenItems ??= new BeachPartyTokenItems();
    set => _BeachPartyTokenItems = value;
}
public BeachPartyTokenItems _BeachPartyTokenItems;

public BlazingBeachStory BlazingBeach
{
    get => _BlazingBeach ??= new BlazingBeachStory();
    set => _BlazingBeach = value;
}
public BlazingBeachStory _BlazingBeach;

    // public BlazingBeachMerge BlazingBeachMerge = new();
public BurningBeachStory BurningBeach
{
    get => _BurningBeach ??= new BurningBeachStory();
    set => _BurningBeach = value;
}
public BurningBeachStory _BurningBeach;

    // public CoralBeachMerge CoralBeachMerge = new();
public CoreSummer LunaCove
{
    get => _LunaCove ??= new CoreSummer();
    set => _LunaCove = value;
}
public CoreSummer _LunaCove;

    // public LunaCoveMerge LunaCoveMerge = new();
public SweetSummerTreats SweetSummerTreats
{
    get => _SweetSummerTreats ??= new SweetSummerTreats();
    set => _SweetSummerTreats = value;
}
public SweetSummerTreats _SweetSummerTreats;

public UnLifeGuardQuest UnLifeguardQuest
{
    get => _UnLifeguardQuest ??= new UnLifeGuardQuest();
    set => _UnLifeguardQuest = value;
}
public UnLifeGuardQuest _UnLifeguardQuest;

public CelestialPirateCommander CelestialPirateCommander
{
    get => _CelestialPirateCommander ??= new CelestialPirateCommander();
    set => _CelestialPirateCommander = value;
}
public CelestialPirateCommander _CelestialPirateCommander;

public KaijuWar KaijuWar
{
    get => _KaijuWar ??= new KaijuWar();
    set => _KaijuWar = value;
}
public KaijuWar _KaijuWar;

public HeartOfTheSeaStory HeartOfTheSeaStory
{
    get => _HeartOfTheSeaStory ??= new HeartOfTheSeaStory();
    set => _HeartOfTheSeaStory = value;
}
public HeartOfTheSeaStory _HeartOfTheSeaStory;

public CetoleonWarStory CetoleonWarStory
{
    get => _CetoleonWarStory ??= new CetoleonWarStory();
    set => _CetoleonWarStory = value;
}
public CetoleonWarStory _CetoleonWarStory;

public DragonPirateStory DragonPirateStory
{
    get => _DragonPirateStory ??= new DragonPirateStory();
    set => _DragonPirateStory = value;
}
public DragonPirateStory _DragonPirateStory;

public DragonCapitalStory DragonCapitalStory
{
    get => _DragonCapitalStory ??= new DragonCapitalStory();
    set => _DragonCapitalStory = value;
}
public DragonCapitalStory _DragonCapitalStory;

public LowTideStory LowTideStory
{
    get => _LowTideStory ??= new LowTideStory();
    set => _LowTideStory = value;
}
public LowTideStory _LowTideStory;

public AluteaNursery AluteaNursery
{
    get => _AluteaNursery ??= new AluteaNursery();
    set => _AluteaNursery = value;
}
public AluteaNursery _AluteaNursery;

public BlazeBeard BlazeBeard
{
    get => _BlazeBeard ??= new BlazeBeard();
    set => _BlazeBeard = value;
}
public BlazeBeard _BlazeBeard;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Seasonals();

        Core.SetOptions(false);
    }

    public void Seasonals()
    {
        switch (DateTime.Now.Month)
        {
            default:
                DageRecruit.CompleteDageRecruit();
                if (Bot.Quests.IsAvailable(7713))
                    CelestialPirateCommander.GetCPC(true);
                break;

            case 1:
                Core.Logger("Starting Scripts for January");
                //insert script voids here
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 2:
                Core.Logger("Starting Scripts for Febuary");
                //insert script voids here
                Fezzini.FezziniScript();
                LoveSpell.LoveSpellScript();
                WheeleOfLove.DoWheeleOfLove();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 3:
                Core.Logger("Starting Scripts for March");
                //insert script voids here
                Pooka.CompletePooka();
                DarkLord.GetDL();
                MurderMoon.MurderMoonStory();
                Dage.DoAll();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");

                break;

            case 4:
                Core.Logger("Starting Scripts for April");
                //insert script voids here
                Derp.GetBadge();
                MeateorHunt.StoryLine();
                SSB.GetBadgeANDDoStory();
                Meaty.CompleteQuests();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 5:
                Core.Logger("Starting Scripts for May");
                //insert script voids here
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 6:
                Core.Logger("Starting Scripts for June");
                // BeachPartyTokenItems.TokenItems();
                BlazingBeach.StoryLine();
                // BlazingBeachMerge.BuyAllMerge();
                BurningBeach.Storyline();
                // CoralBeachMerge.BuyAllMerge();
                LunaCove.LunaCove();
                // LunaCoveMerge.BuyAllMerge();
                // SweetSummerTreats.GetTreats();
                // UnLifeguardQuest.GetItems();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 7:
                Core.Logger("Starting Scripts for July");
                Frostvale.DoAll();
                // BeachPartyTokenItems.TokenItems();
                BlazingBeach.StoryLine();
                // BlazingBeachMerge.BuyAllMerge();
                BurningBeach.Storyline();
                // CoralBeachMerge.BuyAllMerge();
                LunaCove.LunaCove();
                // LunaCoveMerge.BuyAllMerge();
                // SweetSummerTreats.GetTreats();
                // UnLifeguardQuest.GetItems();
                StarFestival.StoryLine();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 8:
                Core.Logger("Starting Scripts for August");
                //insert script voids here
                Frostvale.DoAll();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 9:
                Core.Logger("Starting Scripts for September");
                //insert script voids here
                CelestialPirateCommander.GetCPC(true);
                KaijuWar.KaijuItems();
                HeartOfTheSeaStory.HeartOfTheSea();
                CetoleonWarStory.CetoleonWar();
                DragonPirateStory.DragonPirate();
                DragonCapitalStory.DragonCapital();
                LowTideStory.Storyline();
                AluteaNursery.DoAll();
                BlazeBeard.TokenQuests();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 10:
                Core.Logger("Starting Scripts for October");
                CoreMogloween.DoAll();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 11:
                Core.Logger("Starting Scripts for November");
                //insert script voids here
                VPL.GetClass(false);
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;

            case 12:
                Core.Logger("Starting Scripts for December");
                //insert script voids here
                Frostvale.DoAll();
                Core.Logger($"Scripts Finished for {DateTime.Now:MMMM}");
                break;
        }
    }
}
