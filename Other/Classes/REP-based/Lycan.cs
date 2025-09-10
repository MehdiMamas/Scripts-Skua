/*
name: Lycan
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class Lycan
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public Core13LoC LOC
{
    get => _LOC ??= new Core13LoC();
    set => _LOC = value;
}
public Core13LoC _LOC;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetLycan();

        Core.SetOptions(false);
    }

    public void GetLycan(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Lycan"))
            return;

        LOC.Wolfwing();
        Farm.LycanREP();

        Core.BuyItem("lycan", 161, "Lycan");

        if (rankUpClass)
            Adv.RankUpClass("Lycan");
    }
}
