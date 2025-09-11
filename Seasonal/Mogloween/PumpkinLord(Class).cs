/*
name: (Class) Pumpkin Lord
description: This script will get Pumpkin Lord class.
tags: class, mogloween, seasonal, pumpkin, pumpkin lord, pumpkinlord
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class PumpkinLord
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetClass(true);

        Core.SetOptions(false);
    }

    public void GetClass(bool rankUpClass = false)
    {
        if (!Core.isSeasonalMapActive("mogloween") || Core.CheckInventory("Pumpkin Lord", toInv: false))
            return;

        Core.EquipClass(ClassType.Solo);

        Core.HuntMonster("mogloween", "Great Pumpkin King", "Pumpkin Lord", isTemp: false);

        if (rankUpClass)
            Adv.RankUpClass("Pumpkin Lord");
    }
}
