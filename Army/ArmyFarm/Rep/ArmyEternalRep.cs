/*
name: Army Eternal Rep
description: Farm reputation with your army. Faction: Eternal
tags: army, reputation, eternal
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/Story/RavenlossSaga.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
//cs_include Scripts/Army/ArmyFarm/Rep/CoreArmyRep.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Models.Quests;
using Skua.Core.Options;

public class ArmyEternalRep
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }
    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }
    private static CoreAdvanced _Adv;
    private static CoreArmyRep CAR { get => _CAR ??= new CoreArmyRep(); set => _CAR = value; }
    private static CoreArmyRep _CAR;
private static CoreBots sCore { get => _sCore ??= new CoreBots(); set => _sCore = value; }
private static CoreBots _sCore;

private static CoreArmyLite sArmy { get => _sArmy ??= new CoreArmyLite(); set => _sArmy = value; }

private static CoreArmyLite _sArmy;


    public string OptionsStorage = "ArmyEternalRep";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        new Option<int>("armysize","Players", "Input the minimum of players to wait for", 4),
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6,
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Setup();

        Core.SetOptions(false);
    }

    public void Setup() => CAR.ArmyEternalRep();
}
