/*
name: Dark War Legion Gold
description: Gold farm using Dark War Legion Method
tags: gold, farm, dark, war, legion
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Story/Legion/DarkWarLegionandNation.cs
using Skua.Core.Interfaces;

public class DarkWarLegionGold
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

public DarkWarLegionandNation DWLaN
{
    get => _DWLaN ??= new DarkWarLegionandNation();
    set => _DWLaN = value;
}
public DarkWarLegionandNation _DWLaN;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions(disableClassSwap: true);

        DoDarkWarLegionGold();

        Core.SetOptions(false);
    }

    public void DoDarkWarLegionGold()
    {
        Core.EquipClass(ClassType.Farm);
        //Adv.BestGear(GenericGearBoost.gold);

        Core.Logger("Doing quest requirements.");
        DWLaN.DarkWarLegion();

        Farm.DarkWarLegion();
    }
}
