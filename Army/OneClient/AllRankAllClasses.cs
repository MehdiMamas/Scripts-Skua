/*
name: All accs bank all
description: banks all items on all accs in the "thefamily.txt" file.
tags: bank, army, all
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/Tools/RankUpAllClasses.cs
using Skua.Core.Interfaces;

public class AllRankAllClasses
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreArmyLite Army
{
    get => _Army ??= new CoreArmyLite();
    set => _Army = value;
}
private CoreArmyLite _Army;

private RankUpAll RUA
{
    get => _RUA ??= new RankUpAll();
    set => _RUA = value;
}
private RankUpAll _RUA;

    
    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        DoTheThing();

        Core.SetOptions(false);
    }

    public void DoTheThing()
    {
        while (!Bot.ShouldExit && Army.doForAll())
            RUA.RankUpAllClasses();
    }
}
