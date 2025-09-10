/*
name: Seven Circles War XP + Gold
description: This script will farm XP and Gold using SevenCirclesWar method.
tags: seven, 7, circles, war, gold, xp, exp, experience, farm, max, 100, level, leveling
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Legion/SevenCircles(War).cs
using Skua.Core.Interfaces;

public class SevenCirclesWarXP
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public SevenCircles SC
{
    get => _SC ??= new SevenCircles();
    set => _SC = value;
}
public SevenCircles _SC;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoSevenCirclesWarXP();

        Core.SetOptions(false);
    }

    public void DoSevenCirclesWarXP()
    {
        SC.CirclesWar(true, true);

        //Adv.BestGear(GenericGearBoost.exp);
        //Adv.BestGear(GenericGearBoost.gold);
        //Farm.UseBoost(ChangeToBoostID, Skua.Core.Models.Items.BoostType.Experience, true);

        Farm.SevenCirclesWar(Bot.Player.Level == 100 ? 101 : 100, 100000000);

    }
}
