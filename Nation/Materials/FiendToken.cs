/*
name: FiendToken
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/Various/HanzoOrbQuest.cs
//cs_include Scripts/Nation/VoidKnightSwordQuest.cs
using Skua.Core.Interfaces;

public class FiendToken
{
    public CoreBots Core => CoreBots.Instance;
public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;

public HanzoOrbQuest HanzoOrbQuest
{
    get => _HanzoOrbQuest ??= new HanzoOrbQuest();
    set => _HanzoOrbQuest = value;
}
public HanzoOrbQuest _HanzoOrbQuest;

public VoidKnightSword VoidKnightSword
{
    get => _VoidKnightSword ??= new VoidKnightSword();
    set => _VoidKnightSword = value;
}
public VoidKnightSword _VoidKnightSword;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        FarmFiendToken();

        Core.SetOptions(false);
    }

    public void FarmFiendToken()
    {
        if (!Core.IsMember)
            HanzoOrbQuest.HanzoOrb("FiendToken, 30");
        Nation.FarmFiendToken();

    }
}
