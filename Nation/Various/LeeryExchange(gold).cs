/*
name: LeeryExchange(gold)
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/CoreFarms.cs


using Skua.Core.Interfaces;

public class leeryExchange
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { Nation.Uni(13), "Diamond of Nulgath", "Relic of Chaos" });
        Core.SetOptions();

        Nation.LeeryExchangeGold();

        Core.SetOptions(false);
    }
}
