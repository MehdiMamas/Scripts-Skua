/*
name: MasterRanger
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class MasterRanger
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


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetMR();

        Core.SetOptions(false);
    }

    public void GetMR(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Master Ranger"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Master Ranger");
            return;
        }

        Adv.BuyItem("sandsea", 242, 7260, shopItemID: 5682);

        if (rankUpClass)
            Adv.RankUpClass("Master Ranger");
    }
}
