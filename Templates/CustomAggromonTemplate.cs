/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class CustomAggroMonTemplate
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreArmyLite Army { get => _Army ??= new CoreArmyLite(); set => _Army = value; }
    private static CoreArmyLite _Army;
private static CoreArmyLite sArmy { get => _sArmy ??= new CoreArmyLite(); set => _sArmy = value; }
private static CoreArmyLite _sArmy;


    public string OptionsStorage = "CustomAggroMon";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6,
        sArmy.player7,
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        CustomAggroMon();
        Core.SetOptions(false);
    }

    public void CustomAggroMon()
        => Army.RunGeneratedAggroMon(map, monNames, questIDs, classtype, drops);
    private static readonly int[] questIDs={ };
    private static readonly string[] monNames={ };
    private static readonly string[] drops={ };
    private string map = "";
    private ClassType classtype = ClassType.None;
}