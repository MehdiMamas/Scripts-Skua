/*
name: Army Approval Favour
description: Uses army to Farm Archfiend's Favor and Nulgath's Approval.
tags: archfiend's favor, nulgath's approval, army
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class ArmyApprovalFavour
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;
    private static CoreArmyLite Army { get => _Army ??= new CoreArmyLite(); set => _Army = value; }
    private static CoreArmyLite _Army;

private static CoreBots sCore { get => _sCore ??= new CoreBots(); set => _sCore = value; }

private static CoreBots _sCore;

private static CoreArmyLite sArmy { get => _sArmy ??= new CoreArmyLite(); set => _sArmy = value; }

private static CoreArmyLite _sArmy;


    public string OptionsStorage = "ArmyApprovalFavour";
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

        Core.AddDrop(Loot);
        Core.EquipClass(ClassType.Farm);
        var player4 = Bot.Config?.Get<string>("player4");
        if (string.IsNullOrEmpty(player4))
            Army.AggroMonMIDs(1, 2, 3, 4, 5, 6, 7, 8, 9);
        else Army.AggroMonMIDs(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        Army.AggroMonStart("evilwarnul");
        Army.DivideOnCells("r2", "r3", "r4", "r5", "r6");

        

        while (!Bot.ShouldExit)
            Bot.Combat.Attack("*");
        Army.AggroMonStop(true);
    }

    private string[] Loot = { "Archfiend's Favor", "Nulgath's Approval" };
}
