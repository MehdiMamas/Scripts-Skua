/*
name: VoucherItemChoose
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class VoucherItem
{
    public IScriptInterface Bot => IScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public string OptionsStorage = "VoucherItem";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<VoucherItemTotem>("VoucherItem", "Choose Your Item", "Extra stuff to choose, if you have any suggestions -form in disc, and put it under request. or dm Tato(the retarded one on disc)", VoucherItemTotem.Totem_of_Nulgath),
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Choose();

        Core.SetOptions(false);
    }

    public void Choose()
    {
        Nation.VoucherItemTotemofNulgath(Bot.Config!.Get<VoucherItemTotem>("VoucherItem"));
    }
}
