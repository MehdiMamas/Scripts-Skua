/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Army/CoreArmyLite.cs
using Skua.Core.Interfaces;
using Skua.Core.Models;
using Skua.Core.Models.Auras;
using Skua.Core.Options;

public class OneClientTemplate
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

private CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
private CoreDailies _Daily;

    public CoreAdvanced Adv => new();
private CoreArmyLite Army
{
    get => _Army ??= new CoreArmyLite();
    set => _Army = value;
}
private CoreArmyLite _Army;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Template();

        Core.SetOptions(false);
    }

    public void Template()
    {
        while (!Bot.ShouldExit && Army.doForAll())
        {
            // Insert what you want all the accs to do here. this will just once per account (for every account) in the manager.
            // No actualy army stuff here, just things that can be run solo, but are needed for all the accounts.
        }
    }
}
