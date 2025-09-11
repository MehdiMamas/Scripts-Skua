/*
name: VoucherofNulgath(non-member)
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class VoucherofNulgathNonMem
{
    public CoreBots Core => CoreBots.Instance;
    private static CoreNation Nation { get => _Nation ??= new CoreNation(); set => _Nation = value; }    private static CoreNation _Nation;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Nation.FarmVoucher(false);

        Core.SetOptions(false);
    }
}
