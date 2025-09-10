/*
name: DragonBlade[mem]
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class DragonBladeofNulgath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public readonly string[] TwistedItems =
    {
        "DragonFire of Nulgath",
        "Crimson Plate of Nulgath",
        "Crimson Face Plate of Nulgath"
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.BankingBlackList.AddRange(TwistedItems);
        Core.BankingBlackList.AddRange(new[] { "DragonBlade of Nulgath", "Combat Trophy", "Basic War Sword", "Behemoth Blade of Shadow", "Behemoth Blade of Light" });
        Core.SetOptions();

        GetDragonBlade();

        Core.SetOptions(false);
    }

    public void GetDragonBlade()
    {
        if (Core.CheckInventory("DragonBlade of Nulgath") || (!Core.IsMember))
        {
            Core.Logger($"{(Core.CheckInventory("DragonBlade of Nulgath") ? "\"DragonBlade of Nulgath\" owned" : "Not an Member cannot get \"DragonBlade of Nulgath\"")}");
            return;
        }

        Core.AddDrop(Nation.bagDrops.Concat(TwistedItems).ToArray().Concat(new[] { "DragonBlade of Nulgath", "Combat Trophy", "Basic War Sword", "Behemoth Blade of Shadow", "Behemoth Blade of Light" }).ToArray());

        BehemothBladeof("Shadow");
        BehemothBladeof("Light");

        while (!Bot.ShouldExit && !Core.CheckInventory(TwistedItems))
        {
            Core.EnsureAccept(765);
            Nation.FarmTotemofNulgath(3);
            Core.HuntMonster("underworld", "Skull Warrior", "Skull Warrior Rune");
            Core.EnsureCompleteChoose(765);
        }

        Nation.FarmTotemofNulgath(3);

        Core.EnsureAccept(766);
        Core.HuntMonster("underworld", "Legion Fenrir", "Legion Fenrir Rune");
        Core.EnsureComplete(766, 5483);
        Bot.Wait.ForPickup("DragonBlade of Nulgath");
    }

    public void BehemothBladeof(string blade)
    {
        if (Core.CheckInventory($"Behemoth Blade of {blade}"))
            return;

        Core.EquipClass(ClassType.Solo);
        if (!Core.CheckInventory("Basic War Sword"))
        {
            Farm.BludrutBrawlBoss(quant: 50);
            Core.BuyItem("battleon", 222, "Basic War Sword");
        }
        if (!Core.CheckInventory("Steel Afterlife"))
        {
            Farm.BludrutBrawlBoss(quant: 50);
            Core.BuyItem("battleon", 222, "Steel Afterlife");
        }
        Farm.BludrutBrawlBoss(quant: 500);
        Core.BuyItem("battleon", 222, $"Behemoth Blade of {blade}");
    }
}
