/*
name: Beach Party Token Items
description: This will farm Tiki Tokens and buy the items from the Beach Party Token Shop.
tags: farm, beach, party, tiki, tokens, items, shop
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/MemetsRealm/CoreMemet.cs
using Skua.Core.Interfaces;

public class BeachPartyTokenItems
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static MemetsRealm Memet { get => _Memet ??= new MemetsRealm(); set => _Memet = value; }    private static MemetsRealm _Memet;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        TokenItems();

        Core.SetOptions(false);
    }

    public void TokenItems()
    {
        if (!Core.isSeasonalMapActive("beachparty"))
            return;

        string[] rewards = Core.EnsureLoad(7010).Rewards.Where(x => Core.IsMember ? true : !x.Upgrade).Select(x => x.Name).ToArray();
        if (Core.CheckInventory(rewards, toInv: false))
            return;

        Core.AddDrop("Tiki Tokens");
        Core.AddDrop(rewards);
        Memet.BeachParty();

        Core.RegisterQuests(7010);
        while (!Bot.ShouldExit && !Core.CheckInventory(rewards, toInv: false))
        {
            Core.KillMonster("beachparty", "r3", "Left", "*", "Tiki Tokens", 5, false);
            Core.Sleep();
        }
        Core.CancelRegisteredQuests();
        Core.ToBank(rewards);
    }
}
