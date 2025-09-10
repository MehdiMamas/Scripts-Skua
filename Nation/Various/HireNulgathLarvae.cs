/*
name: HireNulgathLarvae
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class HireNulgathLarvae
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        getthething();

        Core.SetOptions(false);
    }

    public void getthething()
    {
        if (Core.CheckInventory("Nulgath Larvae"))
            return;

        Nation.HireNulgathLarvae();
    }
}
