/*
name: Unidentified10
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class Uni10
{
    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Nation.FarmUni10();

        Core.SetOptions(false);
    }
}
