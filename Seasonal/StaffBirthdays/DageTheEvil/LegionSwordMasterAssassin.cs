/*
name: Legion Sword Master Assassin
description: farms the required materials for the class: "legion swordmaster assassin"
tags: legion, class, darkbirthday, legion swordmaster assassin
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/LegionMaterials/SoulSand.cs
//cs_include Scripts/Legion/Various/LegionBonfire.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class LegionSwordMasterAssassin
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public AnotherOneBitesTheDust SSand
{
    get => _SSand ??= new AnotherOneBitesTheDust();
    set => _SSand = value;
}
public AnotherOneBitesTheDust _SSand;

public LegionBonfire Bon
{
    get => _Bon ??= new LegionBonfire();
    set => _Bon = value;
}
public LegionBonfire _Bon;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetClass();

        Core.SetOptions(false);
    }


    public void GetClass(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Legion SwordMaster Assassin") || !Core.isSeasonalMapActive("darkbirthday"))
            return;

        Core.AddDrop("Soul Essence");

        Legion.ObsidianRock(300);
        Legion.FarmLegionToken(5000);

        Adv.BuyItem("darkbirthday", 1697, "Legion SwordMaster Assassin");

        if (rankUpClass)
            Adv.RankUpClass("Legion SwordMaster Assassin");
    }
}
