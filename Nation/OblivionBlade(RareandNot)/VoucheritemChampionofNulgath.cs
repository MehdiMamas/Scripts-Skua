/*
name: VoucheritemChampionofNulgath
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/OblivionBlade(RareandNot)/CoreOblivionBladeofNulgath.cs
using Skua.Core.Interfaces;

public class VoucheritemChampionofNulgath
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreOblivionBladeofNulgath COBoN
{
    get => _COBoN ??= new CoreOblivionBladeofNulgath();
    set => _COBoN = value;
}
public CoreOblivionBladeofNulgath _COBoN;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        COBoN.VoucheritemChampionofNulgath();

        Core.SetOptions(false);
    }
}
