/*
name: (Pax) Death Pit Story
description: This will finish the Death Pit story.
tags: death, pit, farm, story, pax, throne, darkness
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;

public class DeathPit
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreToD TOD
{
    get => _TOD ??= new CoreToD();
    set => _TOD = value;
}
public CoreToD _TOD;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        TOD.DeathPit();

        Core.SetOptions(false);
    }
}
