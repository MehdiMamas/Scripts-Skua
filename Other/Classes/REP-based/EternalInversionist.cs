/*
name: EternalInversionist
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class EternalInversionist
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

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

public CoreToD TOD
{
    get => _TOD ??= new CoreToD();
    set => _TOD = value;
}
public CoreToD _TOD;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetEI();

        Core.SetOptions(false);
    }

    public void GetEI(bool rankUpClass = true)
    {
        if (Core.CheckInventory(35602))
            return;

        TOD.FourthDimensionalPyramid();
        Adv.BuyItem("fourdpyramid", 1275, "Eternal Inversionist", shopItemID: 21138);
        if (rankUpClass)
        {
            Adv.GearStore();
            Core.Equip("Eternal Inversionist");
            Adv.RankUpClass("Eternal Inversionist");
            Adv.GearStore(true);
        }

    }
}
