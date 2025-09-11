/*
name: BloodSorceress
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class BloodSorceress
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetBSorc();

        Core.SetOptions(false);
    }

    public void GetBSorc(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Blood Sorceress"))
        {
            if (rankUpClass)
            {
                Adv.RankUpClass("Blood Sorceress");
            }
            return;
        }

        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("towerofmirrors", "Scarletta", "Blood Sorceress", isTemp: false);
        Core.JumpWait();
        Bot.Wait.ForPickup("Blood Sorceress");

        if (rankUpClass)
            Adv.RankUpClass("Blood Sorceress");
    }
}
