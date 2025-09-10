/*
name: LegionFealty3
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/Revenant/CoreLR.cs
//cs_include Scripts/Legion/InfiniteLegionDarkCaster.cs
//cs_include Scripts/Story/Legion/SeraphicWar.cs
using Skua.Core.Interfaces;

public class LegionFealty3
{
    private CoreBots Core => CoreBots.Instance;
private CoreLR LR
{
    get => _LR ??= new CoreLR();
    set => _LR = value;
}
private CoreLR _LR;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LR.ExaltedCrown();

        Core.SetOptions(false);
    }
}
