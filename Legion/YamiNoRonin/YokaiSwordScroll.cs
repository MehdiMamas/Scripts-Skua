/*
name: Yokai Sword Scroll
description: This bot will farm the Yokai Sword Scroll, used in Yami no Ronin.
tags: yami, no, ronin, YNR, legion, yokai sword scroll
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Legion/SwordMaster.cs
//cs_include Scripts/Legion/YamiNoRonin/CoreYnR.cs
using Skua.Core.Interfaces;

public class YokaiSwordScroll
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreYnR YNR
{
    get => _YNR ??= new CoreYnR();
    set => _YNR = value;
}
public CoreYnR _YNR;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        YNR.YokaiSwordScroll();

        Core.SetOptions(false);
    }
}
