/*
name: EmpoweringItems
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class EmpoweringItems
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

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;

public CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
public CoreDailies _Daily;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        EmpoweringStuff();

        Core.SetOptions(false);
    }
    public void EmpoweringStuff()
    {
        if (Core.CheckInventory("Death Scythe of Nulgath"))
            return;

        Core.AddDrop("Death Scythe of Nulgath");

        Core.EnsureAccept(558);
        Nation.FarmUni13(1);
        Nation.FarmDiamondofNulgath(10);
        if (!Core.CheckInventory(4867))
        {
            Core.EnsureAccept(623);
            Nation.FarmUni13(1);
            Core.HuntMonster("willowcreek", "Hidden Spy", "The Secret 1", isTemp: false);
            Core.EnsureComplete(623);
            Bot.Wait.ForPickup(4867);
        }
        Core.HuntMonster("underworld", "Undead Bruiser", "Undead Bruiser Sigil");
        Core.EnsureComplete(558);
        Bot.Wait.ForPickup("Death Scythe of Nulgath");
    }
}
