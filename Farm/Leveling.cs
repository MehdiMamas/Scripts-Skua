/*
name: Leveling [1-100]
description: This script will farm XP to max level.
tags: levelling, leveling, level, xp, experience, farm, exp
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class Leveling
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


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoLeveling();

        Core.SetOptions(false);
    }

    public void DoLeveling()
    {
        //Adv.BestGear(GenericGearBoost.exp);
        Farm.Experience();
    }
}
