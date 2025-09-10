/*
name: NecroticBladeoftheUnderworld
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Story/Legion/DageChallengeStory.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Good/BLOD/CoreBLOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/Legion/SevenCircles(War).cs
//cs_include Scripts/Legion/HeadOfTheLegionBeast.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
using Skua.Core.Interfaces;

public class NecroticBladeoftheUnderworld
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreNSOD NSoD
{
    get => _NSoD ??= new CoreNSOD();
    set => _NSoD = value;
}
public CoreNSOD _NSoD;

public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;

public DageChallengeStory DageChallenge
{
    get => _DageChallenge ??= new DageChallengeStory();
    set => _DageChallenge = value;
}
public DageChallengeStory _DageChallenge;

public AnotherOneBitesTheDust SoulSand
{
    get => _SoulSand ??= new AnotherOneBitesTheDust();
    set => _SoulSand = value;
}
public AnotherOneBitesTheDust _SoulSand;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Legion Token", "Beast Soul", "Soul Sand", "Dage the Evil Insignia" });
        Core.SetOptions();

        GetNBoU();

        Core.SetOptions(false);
    }

    public void GetNBoU()
    {
        //Item Check
        if (Core.CheckInventory("Necrotic Blade of the Underworld"))
            return;

        //Necessary AddDrops
        Core.AddDrop(new[] { "Necrotic Blade of the Underworld", "Underworld Blade of DOOM", "Necrotic Sword of Doom", "Legion Token", "Beast Soul", "Soul Sand", "Dage the Evil Insignia" });

        //Leveling to 95
        Farm.Experience(95);

        //Unlocking Quest
        DageChallenge.DageChallengeQuests();

        Core.EnsureAccept(8548);

        //Get Necrotic Sword of Doom
        if (!Core.CheckInventory("Necrotic Sword of Doom"))
        {
            Core.Logger("Getting Necrotic Sword of Doom (This Will Take a LONG Time");
            NSoD.GetNSOD();
        }

        //Underworld Blade of DOOM
        if (!Core.CheckInventory("Underworld Blade of DOOM"))
        {
            Core.HuntMonster("Dage", "Dage the Evil", "Underworld Blade of DOOM", isTemp: false, publicRoom: false);
            Bot.Wait.ForPickup("Underworld Blade of DOOM");
        }

        //Farm 25,000 Legion Tokens
        Legion.FarmLegionToken(25000);

        //Beast Souls
        Adv.BoostKillMonster("SevenCirclesWar", "r17", "Left", "The Beast", "Beast Soul", 25, isTemp: false, publicRoom: false);

        //Soul Sand
        SoulSand.SoulSand(7);

        //Dage the Evil Insignia
        Bot.Events.RunToArea += Event_RunToArea;
        if (!Core.CheckInventory("Dage the Evil Insignia", 5))
        {
            if (Bot.Quests.IsDailyComplete(8547))
            {
                Core.Logger("Can't accept quest 8547 because the weekly is complete", messageBox: true);
                return;
            }
            Core.EnsureAccept(8547);
            Core.EquipClass(ClassType.Solo);

            Adv.BoostKillMonster("UltraDage", "Boss", "Right", "Dage the Dark Lord", "Dage the Dark Lord Defeated", isTemp: false, publicRoom: false);

            Core.EnsureComplete(8547);
            Bot.Wait.ForPickup("Dage the Evil Insignia");
        }
        Bot.Events.RunToArea -= Event_RunToArea;

        Core.EnsureComplete(8548);
        Bot.Wait.ForPickup("Necrotic Blade of the Underworld");

        void Event_RunToArea(string zone)
        {
            switch (zone.ToLower())
            {
                case "a":
                    //Move to the left
                    Bot.Player.WalkTo(Bot.Random.Next(40, 175), Bot.Random.Next(400, 410), speed: 8);
                    break;
                case "b":
                    //Move to the right
                    Bot.Player.WalkTo(Bot.Random.Next(760, 930), Bot.Random.Next(410, 415), speed: 8);
                    break;
                default:
                    //Move to the center
                    Bot.Player.WalkTo(Bot.Random.Next(480, 500), Bot.Random.Next(300, 420), speed: 8);
                    break;
            }
        }

    }
}
