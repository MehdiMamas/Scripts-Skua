/*
name: RandomWeaponOfNulgath
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;

public class RandomWepofNul
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetWep();

        Core.SetOptions(false);
    }

    public void GetWep()
    {
        if (Core.CheckInventory("Random Weapon of Nulgath"))
            return;

        Nation.Supplies("Random Weapon of Nulgath");
    }
}
