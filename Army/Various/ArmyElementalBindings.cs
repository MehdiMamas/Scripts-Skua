/*
name: Army Elemental Binding & Gold Farm
description: Farms Elemental Bindings and optionally gold using your army setup.
tags: army, elemental binding, gold farm
*/

//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Monsters;
using Skua.Core.Options;

public class ArmyElementalBinding
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv => new();
    private CoreArmyLite Army = new();
    private static CoreArmyLite sArmy = new();

    public string OptionsStorage = "ArmyElementalBindings";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        new Option<bool>("Sell Bindings", "GoldFarm", "Sell the bindings to max gold, then stack bindings. Otherwise stack for Providence", true),
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

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        ArmyBits();

        Core.SetOptions(false);
    }


    public void ArmyBits()
    {
        Core.PrivateRooms = true;
        Core.PrivateRoomNumber = Army.getRoomNr();

        Core.EquipClass(ClassType.Solo);
        Core.AddDrop("Elemental Binding");

        Army.AggroMonStart("archmage");
        Army.DivideOnCells("r2");

        bool startStackingBindings = false;
        bool sellBindings = Bot.Config.Get<bool>("GoldFarm");

        while (!Bot.ShouldExit && !Core.CheckInventory("Elemental Binding", 2500))
        {
            while (!Bot.ShouldExit && Bot.Player.Cell != "r2")
            {
                Core.Jump("r2");
                Core.Sleep();
            }

            foreach (Monster mon in Bot.Monsters.MapMonsters.Where(x => x.ID == 1 || x.ID == 2))
            {
                while (!Bot.ShouldExit && mon.HP > 0)
                {
                    Bot.Combat.Attack(mon.MapID);
                    Core.Sleep();

                    startStackingBindings = Bot.Player.Gold >= 96_000_000;

                    // Exit if we need to sell
                    if (sellBindings && !startStackingBindings && Core.CheckInventory("Elemental Binding", 1000))
                        break;
                }

                // Sell bindings if needed and the option is enabled
                if (sellBindings && !startStackingBindings && Core.CheckInventory("Elemental Binding", 1000))
                {
                    Core.Jump("Enter", "Spawn");
                    Core.SellItem("Elemental Binding", all: true);
                    Core.Jump("r2");
                    break; // Exit foreach, selling done
                }
            }
        }

        Army.AggroMonStop(true);
        Core.CancelRegisteredQuests();
    }
}
