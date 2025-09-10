/*
name: SoulForge Hammer
description: This script will get SoulForge Hammer.
tags: soul, forge, soulforge, hammer, unlock soul forge, soul forge hammer, legion, dage, underworld
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
using Skua.Core.Interfaces;

public class SoulForgeHammer
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreLegion Legion
{
    get => _Legion ??= new CoreLegion();
    set => _Legion = value;
}
public CoreLegion _Legion;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Legion.SoulForgeHammer();

        Core.SetOptions(false);
    }
}
