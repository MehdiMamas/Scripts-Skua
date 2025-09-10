/*
name: Arachnomancer
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/RavenlossSaga.cs

using Skua.Core.Interfaces;

public class Arachnomancer
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

public RavenlossSaga RavenlossSaga
{
    get => _RavenlossSaga ??= new RavenlossSaga();
    set => _RavenlossSaga = value;
}
public RavenlossSaga _RavenlossSaga;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetArach();

        Core.SetOptions(false);
    }

    public void GetArach(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Arachnomancer"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Arachnomancer");
            return;
        }

        RavenlossSaga.DoAll();
        Farm.RavenlossREP();

        Core.BuyItem("ravenloss", 850, "Arachnomancer", shopItemID: 14837);

        if (rankUpClass)
            Adv.RankUpClass("Arachnomancer");
    }
}
