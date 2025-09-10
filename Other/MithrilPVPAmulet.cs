/*
name: Mithril PvP Amulet
description: Farms "Mithril PvP Amulet" From Mob: "Reaper".
tags: mitril pvp amulet, diamoind pvp amulet, pvp, amulet
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class MitrilPvPAmulet
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetAmulet();

        Core.SetOptions(false);
    }

    public void GetAmulet()
    {
        if (Core.CheckInventory(59667))
            return;

        Core.HuntMonster("thevoid", "Reaper", "Diamond PvP Amulet +5500", isTemp: false);
        Core.HuntMonster("thevoid", "Reaper", "Platinum PvP Amulet +5000", isTemp: false);

        Core.BuyItem(Bot.Map.Name, 222, "Mithril PvP Amulet +15000");
    }
}
