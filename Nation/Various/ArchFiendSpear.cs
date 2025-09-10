/*
name: ArchFiendSpear
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Nation/AFDL/WillpowerExtraction.cs
//cs_include Scripts/Nation/Various/ArchFiendEnchantedOrbs.cs
using Skua.Core.Interfaces;

public class ArchFiendSpear
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public CoreHollowborn HB
{
    get => _HB ??= new CoreHollowborn();
    set => _HB = value;
}
public CoreHollowborn _HB;

public WillpowerExtraction Will
{
    get => _Will ??= new WillpowerExtraction();
    set => _Will = value;
}
public WillpowerExtraction _Will;

public ArchFiendEnchantedOrbs AFEO
{
    get => _AFEO ??= new ArchFiendEnchantedOrbs();
    set => _AFEO = value;
}
public ArchFiendEnchantedOrbs _AFEO;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops.Concat(Nation.tercessBags).Concat(new[] {"Unidentified 34", "Unidentified 19", "Necrot", "Chaoroot", "Doomatter",
            "Mortality Cape of Revontheus", "Facebreakers of Nulgath", "SightBlinder Axes of Nulgath", "Mystic Tribal Sword",
            "King Klunk's Crown", "Golden Shadow Breaker", "Shadow Terror Axe"}));
        Core.SetOptions();

        GetAFS();

        Core.SetOptions(false);
    }

    public void GetAFS()
    {
        if (Core.CheckInventory("ArchFiend Spear"))
            return;

        Adv.BuyItem("tercessuinotlim", 1951, "Unidentified 25");
        AFEO.GetAFEO();
        Will.Unidentified34(1);
        Nation.FarmDiamondofNulgath(200);
        HB.FreshSouls(1, 100); // Also has the uni36
        Nation.FarmBloodGem(20);
        Nation.FarmVoucher(false);

        Core.BuyItem("tercessuinotlim", 1820, "ArchFiend Spear");
    }
}
