/*
name: Ultimate Weapon Kit
description: This script farms the max quantity of Ultimate Weapon Kits.
tags: ultimate, weapon, kit, BLOD, blinding, light, destiny
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
using Skua.Core.Interfaces;

public class UltimateWeaponKit
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreBLOD BLOD
{
    get => _BLOD ??= new CoreBLOD();
    set => _BLOD = value;
}
public CoreBLOD _BLOD;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        BLOD.UltimateWK(quant: 10000);

        Core.SetOptions(false);
    }
}
