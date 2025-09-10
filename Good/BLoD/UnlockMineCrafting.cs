/*
name: Unlock MineCrafting
description: This bot will unlock the Mine Crafting quest, this is needed to farm the metals needed for BLoD
tags: blinding, light, destiny, BLOD, mine, crafting, metals
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class UnlockMineCrafting
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


    string[] MineCaftingItems = 
    {
        "Blinding Light of Destiny Handle",
        "Bonegrinder Medal",
        "Bone Dust",
        "Undead Essence",
        "Undead Energy",
        "Spirit Orb",
        "Loyal Spirit Orb"
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(MineCaftingItems);
        Core.SetOptions();

        DoUnlockMineCrafting();

        Core.SetOptions(false);
    }

    public void DoUnlockMineCrafting()
    {
        Core.AddDrop(MineCaftingItems);

        BLOD.UnlockMineCrafting();

        Core.ToBank(MineCaftingItems);
    }
}
