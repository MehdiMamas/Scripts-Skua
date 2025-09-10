/*
name: Shaman
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class Shaman
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

        GetShaman();

        Core.SetOptions(false);
    }

    public void GetShaman(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Shaman"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Shaman");
            return;
        }

        Adv.BuyItem("arcangrove", 214, 5765, shopItemID: 4799);

        if (rankUpClass)
            Adv.RankUpClass("Shaman");
    }
}
