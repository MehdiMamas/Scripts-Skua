/*
name: Faerie Court REP
description: This will farm Faerie Court REP.
tags: reputation, faerie, court, seasonal, lucky
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;
public class FaerieCourtREP
{
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Farm.FaerieCourtREP();

        Core.SetOptions(false);
    }
}
