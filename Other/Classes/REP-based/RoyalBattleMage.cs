/*
name: RoyalBattleMage
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class RoyalBattleMage
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

        GetRBM();

        Core.SetOptions(false);
    }

    public void GetRBM(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Royal BattleMage"))
            return;

        Adv.BuyItem("castle", 702, "Royal BattleMage");

        if (rankUpClass)
            Adv.RankUpClass("Royal BattleMage");
    }
}
