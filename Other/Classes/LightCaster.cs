/*
name: LightCaster
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Other/Classes/LightMage.cs
//cs_include Scripts/Other/Weapons/AvatarOfDeathsScythe.cs
//cs_include Scripts/Other/Weapons/GuardianOfSpiritsBlade.cs
//cs_include Scripts/Other/Weapons/LanceOfTime.cs
//cs_include Scripts/Other/Weapons/BurningBlade.cs
//cs_include Scripts/Other/Weapons/BurningBladeOfAbezeth.cs
//cs_include Scripts/Story/QueenofMonsters/Extra/CelestialArena.cs
//cs_include Scripts/Other/MergeShops/CelestialChampMerge.cs
using Skua.Core.Interfaces;
public class LightCaster
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreAdvanced Adv
{
    get => _Adv ??= new CoreAdvanced();
    set => _Adv = value;
}
public CoreAdvanced _Adv;

public LightMage LM
{
    get => _LM ??= new LightMage();
    set => _LM = value;
}
public LightMage _LM;

public AvatarOfDeathsScythe AODS
{
    get => _AODS ??= new AvatarOfDeathsScythe();
    set => _AODS = value;
}
public AvatarOfDeathsScythe _AODS;

public GuardianOfSpiritsBlade GOSB
{
    get => _GOSB ??= new GuardianOfSpiritsBlade();
    set => _GOSB = value;
}
public GuardianOfSpiritsBlade _GOSB;

public LanceOfTime LOT
{
    get => _LOT ??= new LanceOfTime();
    set => _LOT = value;
}
public LanceOfTime _LOT;

public BurningBlade BB
{
    get => _BB ??= new BurningBlade();
    set => _BB = value;
}
public BurningBlade _BB;

public BurningBladeOfAbezeth BBOA
{
    get => _BBOA ??= new BurningBladeOfAbezeth();
    set => _BBOA = value;
}
public BurningBladeOfAbezeth _BBOA;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetLC();

        Core.SetOptions(false);
    }

    public void GetLC(bool rankUpClass = true)
    {
        if (Core.CheckInventory("LightCaster"))
        {
            if (rankUpClass && !Core.CheckInventory("LightCaster", 10))
                Adv.RankUpClass("LightCaster");
            return; // Already have the class, no need to
        }

        Core.AddDrop("LightCaster", "Aranx's Pure Light");

        Farm.Experience(80);
        GOSB.GetGoSB();
        AODS.GetAoDS();
        LOT.GetLoT();
        BB.GetBurningBlade();
        LM.GetLM(false);
        BBOA.GetBBoA();


        Core.EquipClass(ClassType.Solo);
        Core.EnsureAccept(6495);
        Core.HuntMonster("celestialarenad", "Aranx", "Aranx's Pure Light", isTemp: false);
        Core.EnsureComplete(6495);
        Bot.Wait.ForPickup("LightCaster");

        if (rankUpClass)
            Adv.RankUpClass("LightCaster");
    }
}
