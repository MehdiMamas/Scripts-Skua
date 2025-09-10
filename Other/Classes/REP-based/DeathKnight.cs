/*
name: DeathKnight
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class DeathKnight
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

        GetDK();

        Core.SetOptions(false);
    }

    public void GetDK(bool rankUpClass = true)
    {
        if (Core.CheckInventory("DeathKnight") || !Core.IsMember)
            return;

        Farm.DoomWoodREP();

        Core.BuyItem("necropolis", 408, "DeathKnight", shopItemID: 8079);

        if (rankUpClass)
            Adv.RankUpClass("DeathKnight");
    }
}
