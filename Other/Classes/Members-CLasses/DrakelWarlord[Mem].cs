/*
name: Drakel Warlord (Member) Class
description: This script farms the Drakel Warlord class.
tags: warlord, member, class, deathpitarena
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Other/MergeShops/DeathPitArenaRepMerge.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class DrakelWarlord
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
private CoreAdvanced _Adv;

private DeathPitArenaRepMerge DPARM
{
    get => _DPARM ??= new DeathPitArenaRepMerge();
    set => _DPARM = value;
}
private DeathPitArenaRepMerge _DPARM;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        GetClass();
        Core.SetOptions(false);
    }

    public void GetClass(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Drakel Warlord") || !Core.IsMember)
        {
            Core.Logger(Core.CheckInventory("Drakel Warlord") ? "You already own Drakel Warlord class." : "Membership is required for this class.");
            if (rankUpClass)
                Adv.RankUpClass("Drakel Warlord");
            return;
        }

        DPARM.BuyAllMerge("Drakel Warlord");

        if (rankUpClass)
            Adv.RankUpClass("Drakel Warlord");
    }
}
