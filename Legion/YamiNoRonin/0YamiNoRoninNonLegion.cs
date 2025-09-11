/*
name: Yami no Ronin Full (Non-Legion Variant)
description: This bot will farm and rank up Yami no Ronin for you, fully. But can be used whilst not being in Legion (longer farm)
tags: yami, no, ronin, YNR, legion, yokai sword scroll, blademaster sword scroll, folded steel, flame-forged metal
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

public class YamiNoRoninNonLegion
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreYnR YNR { get => _YNR ??= new CoreYnR(); set => _YNR = value; }    private static CoreYnR _YNR;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        YNR.GetYnR();

        Core.SetOptions(false);
    }
}
