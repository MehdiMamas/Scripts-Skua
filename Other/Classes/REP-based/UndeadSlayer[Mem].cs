/*
name: UndeadSlayer[Mem]
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class UndeadSlayer
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

        GetUS();

        Core.SetOptions(false);
    }

    public void GetUS(bool rankUpClass = true)
    {
        if (Core.CheckInventory("UndeadSlayer"))
            return;
        if (!Core.IsMember)
            return;

        Farm.DoomWoodREP();

        Core.BuyItem("necropolis", 408, "UndeadSlayer");

        if (rankUpClass)
            Adv.RankUpClass("UndeadSlayer");
    }
}
