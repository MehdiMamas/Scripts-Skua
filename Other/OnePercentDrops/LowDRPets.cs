/*
name: LowDRPets
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class LowDRPets
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;


    public string OptionsStorage = "1%Pets";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<Pets>("Pets", "Choose Your Pets", "Extra Pets can be added as long as they are 1% or lower drop chance.", Pets.None),
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetItem();

        Core.SetOptions(false);
    }

    public void GetItem()
    {
        Pets? petConfig = Bot.Config?.Get<Pets>("Pets");

        if (petConfig == null || petConfig == Pets.None)
        {
            Core.Logger($"\"None\" Selected, Stopping.");
            return;
        }

        Core.FarmingLogger($"{petConfig}", 1);

        if ((petConfig == Pets.Akriloth_Pet || petConfig == Pets.All) && !Core.CheckInventory("Akriloth Pet"))
        {
            Core.HuntMonster("gravestrike", "Ultra Akriloth", "Akriloth Pet", isTemp: false);
        }

        // if (Bot.Config.Get<Pets>("Pets") == Pets.Insert || Bot.Config.Get<Pets>("Pets") == Pets.All && !Core.CheckInventory("Insert"))
        // {
        //     Core.HuntMonster("Map", "Mob", "Item", isTemp: false);
        // }

        // case "item":
        // Code goes here
        // break;

    }
}

public enum Pets
{
    Akriloth_Pet,
    All,
    None
}
