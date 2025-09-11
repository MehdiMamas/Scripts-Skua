/*
name: (VHL) Void Crystals
description: This will farm only the void crystals of Void Highlord class.
tags: farm, merge, nation, VHL, void, highlord, roentgenium, void-crystal-a, void-crystal-b
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/AssistingCragAndBamboozle[Mem].cs
//cs_include Scripts/Nation/VHL/CoreVHL.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class VoidCrystals
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreVHL VHL { get => _VHL ??= new CoreVHL(); set => _VHL = value; }    private static CoreVHL _VHL;
public static CoreVHL sVHL
{
    get => _sVHL ??= new CoreVHL();
    set => _sVHL = value;
}
public static CoreVHL _sVHL;

    private static CoreNation Nation { get => _Nation ??= new CoreNation(); set => _Nation = value; }    private static CoreNation _Nation;

    public string OptionsStorage = sVHL.OptionsStorage;
    public bool DontPreconfigure = true;
    public List<IOption> Options = sVHL.Options;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        VHL.VHLCrystals();

        Core.SetOptions(false);
    }
}
