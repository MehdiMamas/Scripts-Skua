/*
name: 0EvolvedOrb
description: null
tags: null
*/
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/EvolvedOrb/EvolvedBloodOrb.cs
//cs_include Scripts/Nation/EvolvedOrb/EvolvedHexOrb.cs
//cs_include Scripts/Nation/EvolvedOrb/EvolvedShadowOrb[Mem].cs
//cs_include Scripts/Nation/EvolvedOrb/EvolvedShadowOrbItems[Mem].cs
//cs_include Scripts/Other/Classes/REP-based/Bard.cs
//cs_include Scripts/Other/MergeShops/BattleConGearMerge.cs
//cs_include Scripts/Other/Various/Potions.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class EvolvedOrb
{
    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public EvolvedBloodOrb EBO
{
    get => _EBO ??= new EvolvedBloodOrb();
    set => _EBO = value;
}
public EvolvedBloodOrb _EBO;

public EvolvedHexOrb EHO
{
    get => _EHO ??= new EvolvedHexOrb();
    set => _EHO = value;
}
public EvolvedHexOrb _EHO;

public EvolvedShadowOrb ESO
{
    get => _ESO ??= new EvolvedShadowOrb();
    set => _ESO = value;
}
public EvolvedShadowOrb _ESO;

public EvolvedShadowOrbItems ESOItems
{
    get => _ESOItems ??= new EvolvedShadowOrbItems();
    set => _ESOItems = value;
}
public EvolvedShadowOrbItems _ESOItems;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoBoth();

        Core.SetOptions(false);
    }

    public void DoBoth()
    {
        GetAllOrb();
        GetAllItems();
    }

    public void GetAllOrb()
    {
        EBO.GetEvolvedBloodOrb();
        EHO.GetEvolvedHexOrb();
        ESO.GetEvolvedShadowOrb();
        Core.Logger($"Done, you have the balls");
    }

    public void GetAllItems()
    {
        ESOItems.GetItems();
        Core.Logger($"Done, you have hatched the balls");
    }
}
