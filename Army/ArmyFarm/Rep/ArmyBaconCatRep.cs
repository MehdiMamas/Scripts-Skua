/*
name: Army BaconCat Rep
description: Farm reputation with your army. Faction: baconcat
tags: army, reputation, baconcat
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/Story/RavenlossSaga.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class ArmyBaconCatRep
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
private CoreFarms _Farm;

    private CoreAdvanced Adv => new();
private CoreArmyLite Army
{
    get => _Army ??= new CoreArmyLite();
    set => _Army = value;
}
private CoreArmyLite _Army;

private CoreArmyRep CAR
{
    get => _CAR ??= new CoreArmyRep();
    set => _CAR = value;
}
private CoreArmyRep _CAR;

private CoreToD TOD
{
    get => _TOD ??= new CoreToD();
    set => _TOD = value;
}
private CoreToD _TOD;


private static CoreBots sCore
{
    get => _sCore ??= new CoreBots();
    set => _sCore = value;
}
private static CoreBots _sCore;

private static CoreArmyLite sArmy
{
    get => _sArmy ??= new CoreArmyLite();
    set => _sArmy = value;
}
private static CoreArmyLite _sArmy;


    public string OptionsStorage = "ArmyBaconCatRep";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6, //adjust if needed, check maps limit on wiki
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Setup();

        Core.SetOptions(false);
    }

    public void Setup() => CAR.ArmyBaconCatRep();
}
