/*
name: Army Pet Tamer Rep
description: Farms reputation for the Pet Tamer faction
tags: army pet tamer reputation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/PockeymogsStory.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs

using Skua.Core.Interfaces;

public class Generated_ArmyPetTamerRep
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static PockeyMogsStory lite { get => _lite ??= new PockeyMogsStory(); set => _lite = value; }
    private static PockeyMogsStory _lite;
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
    };

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();
        lite.PockeyMogs();

        ArmyPetTamerRep();
        Core.SetOptions(false);
    }

    public void ArmyPetTamerRep()
        => Army.RunGeneratedAggroMon(map, monNames, questIDs, classtype, drops);
    private static readonly int[] questIDs={ 5268, 5269, 5270, 5271, 5272, 5273 };
    private static readonly string[] monNames={ "Moglurker", "Zaplin", "Blood Moggot", "Flamog", "Vizally", "Toglin" };
    private static readonly string[] drops={ "" };
    private string map = "pockeymogs";
    private ClassType classtype = ClassType.Solo;
}
