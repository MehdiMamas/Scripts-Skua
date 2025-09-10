/*
name: (Stranger) Antique Shop Story
description: This will finish the Antique Shop story.
tags: antique, shop, farm, story, throne, darkness, stranger
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;

public class AntiqueShop
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

        TOD.AntiqueShop();

        Core.SetOptions(false);
    }
}
