/*
name: Smart Enhance
description: This script will enhance your equipped gear with optimal enhancements.
tags: smart, enhancement, enhance, enh, gear, equip
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class SmartEnhance
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    private static CoreFarms Farm { get => _Farm ??= new CoreFarms(); set => _Farm = value; }    private static CoreFarms _Farm;
    private static CoreAdvanced Adv { get => _Adv ??= new CoreAdvanced(); set => _Adv = value; }    private static CoreAdvanced _Adv;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions(disableClassSwap: true);

        DoSmartEnhance();

        Core.SetOptions(false);
    }

    public void DoSmartEnhance()
    {
        if (Core.CBOBool("DisableAutoEnhance", out bool _disableAutoEnhance) && _disableAutoEnhance)
            return;

        string className = Bot.Player.CurrentClass?.Name ?? string.Empty;
        Adv.SmartEnhance(className);
    }
}
