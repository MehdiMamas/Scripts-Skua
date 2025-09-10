/*
name: BlindingScytheofDestiny
description: This bot will do the entire farm for the Blinding Scythe of Destiny *Note*: it uses dailies!
tags: BLOD, blinding, scythe, destiny, undead, 75, damage, good, soul searching, minecrafting, metals, spirit orb, aura, loyal, blinding, bright, brilliant, weapon kit, finding fragments, bone some dust, essential essences, light merge, blinding light fragments, Blinding Scythe of Destiny
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class BlindingScytheofDestiny
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
private CoreBLOD BLOD
{
    get => _BLOD ??= new CoreBLOD();
    set => _BLOD = value;
}
private CoreBLOD _BLOD;


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        BLOD.GetBlindingWeapon(WeaponOfDestiny.Scythe);

        Core.SetOptions(false);
    }
}
