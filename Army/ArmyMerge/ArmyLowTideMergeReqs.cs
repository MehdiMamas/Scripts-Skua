/*
name: Army LowTide Merge Reqs
description: Gets the Merge item requirements for the Low Tide merge shop.
tags: merge, shop, low tide, rquirements
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class ArmyLowTideMergeReqs
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

    public CoreAdvanced Adv => new();
public CoreArmyLite Army
{
    get => _Army ??= new CoreArmyLite();
    set => _Army = value;
}
public CoreArmyLite _Army;


public static CoreBots sCore
{
    get => _sCore ??= new CoreBots();
    set => _sCore = value;
}
public static CoreBots _sCore;

public static CoreArmyLite sArmy
{
    get => _sArmy ??= new CoreArmyLite();
    set => _sArmy = value;
}
public static CoreArmyLite _sArmy;


    public string OptionsStorage = "ArmyLowTideMergeReqs";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
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
        Core.BankingBlackList.AddRange(Loot);

        Core.SetOptions();

        Setup();

        Core.SetOptions(false);
    }

    public void Setup()
    {
        Core.PrivateRooms = true;
        Core.PrivateRoomNumber = Army.getRoomNr();

        Core.OneTimeMessage("Only for army", "This is intended for use with an army, not for solo players.");

        Army.AggroMonPacketDelay = Bot.Config!.Get<int>("PacketDelay");

        Core.AddDrop(Loot);
        Core.EquipClass(ClassType.Farm);

        Army.AggroMonMIDs(5, 6, 7, 8, 9, 10);
        Army.AggroMonStart("lowtide");
        Army.DivideOnCells("r4", "r5", "r6");

        Core.RegisterQuests(8846);
        
        
            
        while (!Bot.ShouldExit)
            Bot.Combat.Attack("*");

        Army.AggroMonStop(true);
        Core.CancelRegisteredQuests();
    }

    private string[] Loot = { "Evidence Tag" };
}
