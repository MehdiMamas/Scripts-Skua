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
        Core.Join("archmage");

        Army.DivideOnCells("r2");
        Army.AggroMonCells("r2");
        Army.AggroMonStart("archmage", "r2", "left");

        bool sellBindings = Bot.Config.Get<bool>("GoldFarm");

        while (!Bot.ShouldExit) // Infinite loop
        {
            foreach (Monster mon in Bot.Monsters.MapMonsters.Where(x => x.ID == 1 || x.ID == 2))
            {
                while (!Bot.ShouldExit && mon.HP > 0)
                {
                    if (!Bot.Player.Alive)
                    {
                        Bot.Wait.ForTrue(() => Bot.Player.Alive, 20);
                        continue;
                    }

                    // Ensure player is in the correct cell
                    while (!Bot.ShouldExit && Bot.Player.Cell != "r2")
                    {
                        Core.Jump("r2", "Right");
                        Core.Sleep();
                    }

                    // Attack logic
                    if (!Bot.Player.HasTarget)
                        Bot.Combat.Attack(mon.MapID);

                    Bot.Sleep(500);

                    // Determine stacking vs selling
                    bool startStackingBindings = Bot.Player.Gold >= 96_000_000;

                    // Exit if we need to sell
                    if (sellBindings && !startStackingBindings && Core.CheckInventory("Elemental Binding", 1000))
                        break;
                }

                // Sell bindings if needed and the option is enabled
                if (sellBindings && Core.CheckInventory("Elemental Binding", 1000) && Bot.Player.Gold < 96_000_000)
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
